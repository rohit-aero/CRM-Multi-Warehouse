ALTER FUNCTION [dbo].[Inv_PurchaseOrderDetails_InShop]
(	
@partid			int
)
RETURNS 
@TEMP  Table  (
	PartID			int,
	PartNumber		varchar(50),
	PurchaseOrderId	int,
	PONumber		varchar(50),
	PreparedBy		varchar(50),
	IssueDate		varchar(20),
	[Source]		varchar(20),
	[DestWarehouse] varchar(20),
	OrderQty		int,
	ShipQty			int,
	InShop			int
)
AS
BEGIN

insert into @TEMP
SELECT Inv_PurchaseOrderDetail_Manual.PartId,
MIN(Inv_Parts.PartNumber) AS Partnumber,
Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,
MIN(Inv_PurchaseOrder_Manual.PONumber) AS PONumber,
MIN(CONCAT(EmpPreparedBy.FirstName + ' ', EmpPreparedBy.LastName)) AS PreparedBy,
MIN(CONVERT(VARCHAR(10),Inv_PurchaseOrder_Manual.IssueDate,101)) AS IssueDate,
MIN(Inv_Source.[WarehouseName]) AS [Source],
MIN(Inv_Warehouse.WarehouseName) as [Destination],
SUM(OrderQty) AS OrderQty,NULL AS ShipQty,NULL AS InShop
FROM  Inv_PurchaseOrderDetail_Manual
INNER JOIN Inv_PurchaseOrder_Manual ON Inv_PurchaseOrder_Manual.id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
LEFT JOIN tblEmployees AS EmpPreparedBy ON EmpPreparedBy.EmployeeID=Inv_PurchaseOrder_Manual.PreparedBy
LEFT JOIN Inv_Warehouse AS Inv_Source ON Inv_Source.id=Inv_PurchaseOrder_Manual.SourceId
LEFT JOIN Inv_Warehouse ON Inv_Warehouse.Id=Inv_PurchaseOrder_Manual.WareHouseID
INNER JOIN Inv_Parts ON Inv_Parts.id=Inv_PurchaseOrderDetail_Manual.PartId
WHERE Inv_PurchaseOrderDetail_Manual.PartID=@partid
AND Inv_PurchaseOrder_Manual.IsSubmitted=1
GROUP BY Inv_PurchaseOrderDetail_Manual.PartId,Inv_PurchaseOrderDetail_Manual.PurchaseOrderId

DECLARE @PART_ID INT
DECLARE @PurchaseOrder_ID INT
	DECLARE CUR_PART CURSOR		

	STATIC FOR
	SELECT PartID,PurchaseOrderId FROM @TEMP
	OPEN CUR_PART

	IF @@CURSOR_ROWS > 0
	BEGIN
		FETCH NEXT FROM CUR_PART INTO @PART_ID,@PurchaseOrder_ID

		WHILE @@FETCH_STATUS = 0
		BEGIN
					
				Update @TEMP SET ShipQty=
				(
					Select 
					SUM(ISNULL(ShipQty,0)) AS [ShipQty] from Inv_ContainerDetail	
					INNER JOIN Inv_Container ON Inv_Container.id=Inv_ContainerDetail.ContainerId
					WHERE Inv_ContainerDetail.POId=@PurchaseOrder_ID AND PartID=@PART_ID		
				)
				WHERE PurchaseOrderId=@PurchaseOrder_ID AND PartID=@PART_ID

				Update @TEMP SET InShop=
				(
					Select 						
					CASE WHEN (ISNULL(OrderQty,0)-ISNULL(ShipQty,0))<=0 THEN NULL ELSE  
					(ISNULL(OrderQty,0)-ISNULL(ShipQty,0)) END AS InShop
					from @TEMP where PurchaseOrderId=@PurchaseOrder_ID and PartID=@PART_ID
					
				)
				WHERE PurchaseOrderId=@PurchaseOrder_ID AND PartID=@PART_ID

			FETCH NEXT FROM CUR_PART INTO @PART_ID,@PurchaseOrder_ID
		END
	END		
	CLOSE CUR_PART
	DEALLOCATE CUR_PART
RETURN 
END