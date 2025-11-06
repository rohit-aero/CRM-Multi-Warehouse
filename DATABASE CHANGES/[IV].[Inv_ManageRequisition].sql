ALTER PROCEDURE [IV].[Inv_ManageRequisition]
-- Add the parameters for the stored procedure here
@Operation int=NULL,
@msg varchar(500)='' output,
@ReqNo varchar(50)=NULL,
@ReqForId int=NULL,
@PreparedBy int=NULL,
@AppBy int=NULL,
@TentativeShipDate date=NULL,
@ActualShipDate date=NULL,
@ReqStatus int=NULL,
@Reqid int=NULL,
@Partid int=NULL,
@Qty int=NULL,
@Issubmitted bit=null,
@UserID int=null,
@ReqDetails RequisitionDetails readonly,
@LoginUserId int=null,
@Productid INT=NULL,
@OrderType	INT=NULL,
@ShipBy		INT=NULL,
@Requestor	INT=NULL,
@PartQty	INT=NULL,
@Priority	BIT=NULL,
@Remarks	Varchar(500)= NULL,
@ReqDetailId	int= NULL,
@VendorID		int=NULL,
@dtPopUpParts	[INV_RequisitionPopUpParts] ReadOnly
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;
-- Insert statements for procedure here
IF(@Operation=1)
BEGIN
		--Table 0
		SELECT tblEmployees.EmployeeID,
		CONCAT(tblEmployees.FirstName + ' ', tblEmployees.LastName) AS FirstName FROM tblEmployees 
		WHERE FirstName IS NOT NULL AND tblEmployees.EngDepID=7 
		order by FirstName
		--SELECT tblEmployees.EmployeeID,
		--CONCAT(tblEmployees.FirstName + ' ', tblEmployees.LastName) AS FirstName FROM tblEmployees 
		--WHERE FirstName IS NOT NULL AND tblEmployees.EmployeeID IN  (1343,309)
		--order by FirstName				

		--Table 1
		SELECT tblEmployees.EmployeeID,CONCAT(tblEmployees.FirstName  + ' ', tblEmployees.LastName) AS FirstName
		FROM tblEmployees
		WHERE FirstName IS NOT NULL 
		AND tblEmployees.EmployeeID IN (110,44)
		order by FirstName		
		
		
		--table 2
		SELECT Inv_Parts.id AS Partid, 
		CONCAT(PartNumber + '/' ,  PartDes) AS PartNumber,
		Inv_Parts.PartDes AS PartDescription,Inv_Parts.SourceId
		FROM Inv_Parts 
		WHERE PartNumber IS NOT NULL
		and PartNumber NOT Like '%NotInUse%' 
		ORDER BY SourceId,PartNumber asc		

		--table 3
		Select Inv_OrderType.id as OrderTypeId,
		Inv_OrderType.OrderType
		from Inv_OrderType 
		Order by sortorder

		--Table 4
		SELECT EmployeeID, FirstName 
		FROM RequestorForPOPart()
		ORDER BY FirstName

		--table 5
		SELECT Id AS InvSourceid, Inv_Source.[Source] AS InvSource 
		FROM Inv_Source
		ORDER BY InvSource

END

--Ticket Generate
ELSE IF(@Operation=2)
BEGIN
		DECLARE @intCounetr INT=0;
		DECLARE @PID VARCHAR(10)='';
		DECLARE @intTotalRecords INT=10000;
		SET @intTotalRecords=(SELECT COUNT(ReqNo) FROM Inv_Requisition);
		SET @intCounetr=@intCounetr + @intTotalRecords +1 + 10000;
		DECLARE @strYear VARCHAR(5)=RIGHT(YEAR(GETDATE()),2);
		SET @msg='Req-' + @strYear + RIGHT(@intCounetr,5);

END

--Insert Requition Information
ELSE IF(@Operation=3)
BEGIN

BEGIN TRY    
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT ReqNo FROM Inv_Requisition WHERE ReqNo=@ReqNo)
		BEGIN
		INSERT INTO Inv_Requisition (ReqNo,ReqDate,PreparedBy,AppBy,TentativeShipDate
		,IsSubmitted,ReqStatus)
		VALUES (@ReqNo,GETDATE(),@PreparedBy,@AppBy,
		@TentativeShipDate,0,@ReqStatus)
		
		DECLARE @reqinsid as int
		SET @reqinsid=SCOPE_IDENTITY()	
		
		--INSERT INTO Inv_RequisitionDetail (ReqId,PartId,OrderType,ShipmentBy,PartQty,Requestor,[Priority],Comments)
		--VALUES (@Reqid,@Partid,@OrderType,@ShipBy,@PartQty,@Requestor,@Priority,@Remarks)

		INSERT INTO [dbo].[Inv_RequisitionLogs]
		([ReqId], [CreatedDate], [CreatedBy])
		VALUES
		(@reqinsid,GETDATE(),@LoginUserId)		
		
		SET @msg=@reqinsid
		END
		COMMIT TRANSACTION  
		END TRY
		BEGIN CATCH   
		IF @@TRANCOUNT > 0  
				SET @msg=Error_Number()
				ROLLBACK TRANSACTION  	
		END CATCH 

END

--Bind Info and Grid View
ELSE IF(@Operation=4)
BEGIN

	Select Inv_Requisition.ReqNo,
	Inv_Requisition.PreparedBy,Inv_Requisition.AppBy,
	CONVERT(Varchar(20),Inv_Requisition.TentativeShipDate,101) as TentativeShipDate,
	Inv_Requisition.[ReqStatus]
	from Inv_Requisition 
	where Inv_Requisition.id=@Reqid 


		DECLARE @TEMP AS TABLE
		(		
			ReqId	INT,
			ReqDetailid INT,
			Partid  INT,
			[Source] Varchar(10),
			[SourceID] INT,
			Partnumber VARCHAR(250),		
			PartDesc VARCHAR(500),	
			ProductCode VARCHAR(50),
			UM VARCHAR(10),
			Department VARCHAR(50),
			OrderType	VARCHAR(50),
			Requestor	VARCHAR(50),
			ShipBy	VARCHAR(20),
			InStock		int,
			Intransit	int,
			InShop		int,
			[PartQty] INT,
			[Priority]	VARCHAR(10),
			Comments VARCHAR(500)
		)


		INSERT INTO @TEMP
		SELECT Inv_RequisitionDetail.ReqId,Inv_RequisitionDetail.id, Inv_Parts.id as Partid,
		Inv_Source.[Source],Inv_Parts.SourceId,
		Inv_Parts.PartNumber + '/' + Inv_Parts.PartDes AS Partnumber,
		Inv_Parts.PartDes AS PartDesc,Inv_ProductCode.[name] as ProductCode,
		Inv_UM.UM,Inv_Department.Department,
		Inv_OrderType.OrderType,
		CONCAT(EmpRequestor.FirstName + ' ', EmpRequestor.LastName),
		CASE WHEN Inv_RequisitionDetail.ShipmentBy=1 THEN 'By Sea'
		 WHEN Inv_RequisitionDetail.ShipmentBy=2 THEN 'By Air'
		END AS ShipBy,
		NULL AS stockinhand,
		Null as Intransit,NULL AS InShop,
		Inv_RequisitionDetail.[PartQty],
		CASE WHEN Inv_RequisitionDetail.[Priority]=1 THEN 'Urgent' ELSE 'Normal' END as [Priority],Inv_RequisitionDetail.[Comments]
		FROM Inv_Parts
		LEFT JOIN Inv_RequisitionDetail ON Inv_RequisitionDetail.PartId=Inv_Parts.id
		LEFT JOIN Inv_Requisition ON Inv_Requisition.id=Inv_RequisitionDetail.ReqId			
		LEFT JOIN Inv_Department ON Inv_Department.id=Inv_Parts.DepartmentId
		left join Inv_UM ON Inv_UM.id=Inv_Parts.UMId
		LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id=Inv_Parts.productcode
		LEFT JOIN tblEmployees AS EmpRequestor ON EmpRequestor.EmployeeID=Inv_RequisitionDetail.Requestor
		LEFT JOIN Inv_OrderType ON Inv_OrderType.id=Inv_RequisitionDetail.OrderType
		LEFT JOIN Inv_Source ON Inv_Source.id=Inv_Parts.SourceId
		Where ReqId=@Reqid
		
		DECLARE @PART_ID INT
		DECLARE CUR_PART CURSOR		

		STATIC FOR
		SELECT Partid FROM @TEMP
		OPEN CUR_PART

		IF @@CURSOR_ROWS > 0
		BEGIN
			FETCH NEXT FROM CUR_PART INTO @PART_ID

			WHILE @@FETCH_STATUS = 0
			BEGIN
					
				UPDATE @TEMP SET InTransit = (SELECT ShipQty FROM Inv_PurchaseOrderDetails_Transit(@PART_ID)
					WHERE Inv_PurchaseOrderDetails_Transit.PartId = @PART_ID
				)
				WHERE PartId = @PART_ID

				Update @TEMP set InShop= (
					Select CASE WHEN SUM(InShop)<=0 Then NULL ELSE SUM(InShop) END AS InShop from Inv_PurchaseOrderDetails_InShop(@PART_ID)
					GROUP BY PartID	
				)
				WHERE PartId=@PART_ID

				UPDATE @TEMP SET InStock=(
					SELECT SUM(Inv_Parts_StockInHand.StockInHand) FROM Inv_Parts_StockInHand WHERE PartId=@PART_ID 
					GROUP BY PartId
				)
				WHERE PARTID=@PART_ID

				FETCH NEXT FROM CUR_PART INTO @PART_ID
			END
		END		
		CLOSE CUR_PART
		DEALLOCATE CUR_PART

		SELECT ReqId,
		ReqDetailid,Partid,[Source],[SourceID],Partnumber,PartDesc,
		ProductCode,UM,Department,OrderType,Requestor,ShipBy,
		InStock,Intransit,InShop,PartQty,
		[Priority],
		Comments
		FROM @TEMP 
		Where ReqId=@Reqid
		ORDER BY [Priority] desc
END


ELSE IF(@Operation=5)
BEGIN
	DECLARE @TempTablePart as table 
		(
				PartId		int,
				[Source]	nvarchar(10),
				[SourceID]	int,
				Department	Varchar(50),
				UM			varchar(10),
				productcode	Varchar(50),
				stockinhand	int,
				ReOrder		int,
				InShop		int,
				InTransit	int,
				ReOrderQty	int
		)
		INSERT INTO @TempTablePart
		Select Inv_Parts.id as PartId,
		MIN(Inv_Source.[Source]) as [Source],
		MIN(Inv_Parts.SourceId) AS SourceId
		,MIN(Inv_Department.Department) AS Department,
		MIN(Inv_UM.UM) AS UM,MIN(Inv_ProductCode.[name]) as ProductCode,
		SUM(Inv_Parts_StockInHand.stockinhand) AS stockinhand,
		MIN(reorderqty) as reorder,
		NULL AS InShop,
		NULL AS InTransit,MIN(Inv_Parts.reorderqty) AS reorderqty
		from Inv_Parts
		LEFT JOIN Inv_UM ON INV_UM.id=inv_parts.umid
		LEFT JOIN Inv_Department on Inv_Department.id=Inv_Parts.DepartmentId
		LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id=Inv_Parts.productcode
		LEFT JOIN Inv_Source ON Inv_Source.id=Inv_Parts.SourceId
		LEFT JOIN Inv_Parts_StockInHand ON Inv_Parts.id=Inv_Parts_StockInHand.PartId	
		where Inv_Parts.id=@Partid
		Group by Inv_Parts.id


	DECLARE @PART_ID1 INT
		DECLARE CUR_PART CURSOR		

		STATIC FOR
		SELECT PartId FROM @TempTablePart
		OPEN CUR_PART

		IF @@CURSOR_ROWS > 0
		BEGIN
			FETCH NEXT FROM CUR_PART INTO @PART_ID1

			WHILE @@FETCH_STATUS = 0
			BEGIN
					
				UPDATE @TempTablePart SET InTransit = (
					SELECT ShipQty FROM Inv_PurchaseOrderDetails_Transit(@PART_ID1)
					WHERE Inv_PurchaseOrderDetails_Transit.PartId = @PART_ID1
				)
				WHERE PartId = @PART_ID1


				Update @TempTablePart set InShop= (			
					Select CASE WHEN SUM(InShop)<=0 Then NULL ELSE SUM(InShop) END AS InShop from Inv_PurchaseOrderDetails_InShop(@PART_ID1)
					where PartId=@PART_ID1
					GROUP BY PartID	
				)
				WHERE PartId=@PART_ID1

				FETCH NEXT FROM CUR_PART INTO @PART_ID1
			END
		END		
		CLOSE CUR_PART
		DEALLOCATE CUR_PART

		SELECT * FROM @TempTablePart
	
END

ELSE IF(@Operation=6)
BEGIN
	SELECT Inv_Requisition.id as Requisitionid,ReqNo FROM Inv_Requisition WHERE Inv_Requisition.PreparedBy=@PreparedBy and (Inv_Requisition.IsSubmitted=0 or  Inv_Requisition.IsSubmitted is null)
	Order by ReqNo ASC

END
ELSE IF(@Operation=7)
BEGIN
			Select Inv_Requisition.id as Requisitionid,
			Inv_Requisition.ReqNo as ReqNo from Inv_Requisition		
			WHERE (Inv_Requisition.IsSubmitted=0 or  Inv_Requisition.IsSubmitted is null)
			Order by Inv_Requisition.ReqNo
END
ELSE IF(@Operation=8)
BEGIN

	Update Inv_Requisition SET IsSubmitted=1 WHERE id=@Reqid 

	INSERT INTO [dbo].[Inv_RequisitionLogs]
		([ReqId], [SubmitedDate], [SubmitedBY])
		VALUES
		(@Reqid,GETDATE(),@LoginUserId)

	set @msg='Requisition Submitted Successfully !!'
END
ELSE IF(@Operation=9)
BEGIN
	DECLARE @CheckStatus as INT=0
	DECLARE @CheckEngDepID AS INT=0
	SET @CheckEngDepID=(SELECT EngDepID FROM tblEmployees WHERE EmployeeID=@LoginUserId)
	SET @CheckStatus=(SELECT ReqStatus FROM Inv_Requisition WHERE Inv_Requisition.id=@Reqid)
	IF(@CheckEngDepID IN (2,7) and @CheckStatus=3)
	BEGIN
		SET @msg='1'
	END
	ELSE
	BEGIN
		SET @msg='2'
	END

END
ELSE IF(@Operation=10)
BEGIN
	DECLARE @TempRequisitionGridTable as Table (
	ReqId	int,
	ReqDetailid	int,
	PartId	int,
	[Source] nvarchar(10),
	[SourceID] int,
	PartQty	int,	
	Department varchar(50),
	UM Varchar(10),
	ProductCode varchar(50),
	OrderType	int,
	Requestor	int,
	ShipmentBy	int,
	stockinhand	int,
	reorderqty	int,
	InTransit	int,	
	InShop	int,
	[Priority]	bit,
	Comments	varchar(500)
	)

	INSERT INTO @TempRequisitionGridTable
	Select Inv_RequisitionDetail.ReqId,
	Inv_RequisitionDetail.id as ReqDetailid,
	Inv_RequisitionDetail.PartId,
	Inv_Source.[Source],Inv_Parts.SourceId,
	Inv_RequisitionDetail.PartQty,
	Inv_Department.Department,
	Inv_UM.UM,Inv_ProductCode.[name] as ProductCode,
	Inv_RequisitionDetail.OrderType,
	Inv_RequisitionDetail.Requestor as Requestor,
	Inv_RequisitionDetail.ShipmentBy,	
	Inv_Parts.stockinhand,Inv_Parts.reorderqty,0 as InTransit,0 AS InShop,	
	Inv_RequisitionDetail.[Priority] as [Priority],
	Inv_RequisitionDetail.Comments	
	from Inv_RequisitionDetail
	INNER JOIN Inv_Requisition ON
	Inv_Requisition.id=Inv_RequisitionDetail.ReqId
	LEFT JOIN Inv_Parts ON Inv_Parts.id=Inv_RequisitionDetail.PartId
	LEFT JOIN Inv_UM ON INV_UM.id=inv_parts.umid
	LEFT JOIN Inv_Department on Inv_Department.id=Inv_Parts.DepartmentId
	LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id=Inv_Parts.productcode
	LEFT join Inv_OrderType on Inv_OrderType.id=Inv_RequisitionDetail.OrderType
	LEFT join tblEmployees as EmpRequestor ON EmpRequestor.EmployeeID=Inv_RequisitionDetail.Requestor
	LEFT JOIN Inv_Source ON Inv_Source.id=Inv_Parts.SourceId
	Where Inv_RequisitionDetail.id=@ReqDetailId


	DECLARE @PART_IDGrid INT
		DECLARE CUR_PART CURSOR		

		STATIC FOR
		SELECT PartId FROM @TempRequisitionGridTable
		OPEN CUR_PART

		IF @@CURSOR_ROWS > 0
		BEGIN
			FETCH NEXT FROM CUR_PART INTO @PART_IDGrid

			WHILE @@FETCH_STATUS = 0
			BEGIN
					
				UPDATE @TempRequisitionGridTable SET InTransit = (
					SELECT ShipQty FROM Inv_PurchaseOrderDetails_Transit(@PART_IDGrid)
					WHERE Inv_PurchaseOrderDetails_Transit.PartId = @PART_IDGrid
				)
				WHERE PartId = @PART_IDGrid


				
				Update @TempRequisitionGridTable set InShop= (
					SELECT CASE WHEN SUM(InShop)<=0 Then NULL ELSE SUM(InShop) END AS InShop FROM Inv_PurchaseOrderDetails_InShop(@PART_IDGrid)
					where PartId=@PART_IDGrid
					Group by PartId	
				)
				WHERE PartId=@PART_IDGrid

				FETCH NEXT FROM CUR_PART INTO @PART_IDGrid
			END
		END		
		CLOSE CUR_PART
		DEALLOCATE CUR_PART

		Select * from @TempRequisitionGridTable

END

ELSE IF(@Operation=11)
BEGIN
	IF NOT EXISTS(Select PartId from Inv_RequisitionDetail where ReqId=@Reqid and PartId=@Partid)
	BEGIN
	INSERT INTO Inv_RequisitionDetail (ReqId,PartId,VendorID,OrderType,ShipmentBy,PartQty,Requestor,[Priority],Comments)
		VALUES (@Reqid,@Partid,@VendorID,@OrderType,@ShipBy,@PartQty,@Requestor,@Priority,@Remarks)

		Insert into Inv_RequisitionLogs(ReqId,PartId,CreatedDate,CreatedBy)
		VALUES(@Reqid,@Partid,GETDATE(),@LoginUserId)

		Set @msg='Req Detail Added Successfully !!'
	END
	ELSE
	BEGIN
		SET @msg='Part No Already Exists !!'

	END

END
ELSE IF(@Operation=12)
BEGIN
		UPDATE Inv_RequisitionDetail SET ReqId=@Reqid,PartId=@Partid,VendorID=@VendorID,
		PartQty=@PartQty,[Priority]=@Priority,Comments=@Remarks,
		OrderType=@OrderType,ShipmentBy=@ShipBy,Requestor=@Requestor
		WHERE Inv_RequisitionDetail.id=@ReqDetailId	

		Insert into Inv_RequisitionLogs(ReqId,PartId,UpdatedDate,UpdatedBy)
		VALUES(@Reqid,@Partid,GETDATE(),@LoginUserId)

		Set @msg='Req Detail Updated Successfully !!'

END
ELSE IF(@Operation=13)
BEGIN
	DELETE Inv_RequisitionDetail WHERE Inv_RequisitionDetail.id=@ReqDetailId

	INSERT INTO Inv_RequisitionLogs(ReqId,PartID,DeletedBy,DeletedDate)
	VALUES (@Reqid,@Partid,@LoginUserId,GETDATE())
END

ELSE IF(@Operation=14)
BEGIN
		DECLARE @GetStatus as INT
		SET @GetStatus=(Select ReqStatus from Inv_Requisition Where id=@Reqid)

		IF(@GetStatus=3)
		BEGIN
			SET @msg=3
		END
		ELSE IF(@GetStatus=2)
		BEGIN
			SET @msg=2
		END
		ELSE IF(@GetStatus IN (4,5,6))
		BEGIN
			SET @msg=4
		END
		ELSE
		BEGIN
			SET @msg=0
		END
END

ELSE IF(@Operation=15)
BEGIN		

		--table 0
				Select Inv_RequisitionStatus.id as ReqStatusID,
				Inv_RequisitionStatus.[Status]
				from Inv_RequisitionStatus		
				Order by [Status] asc

		--table 1
			Select ReqStatus from Inv_Requisition where Inv_Requisition.id=@Reqid
		
END
ELSE IF(@Operation=16)
BEGIN
	
		DECLARE @GetStatusOnClickNo as INT
		SET @GetStatusOnClickNo=(Select ReqStatus from Inv_Requisition Where id=@Reqid)

		SET @msg=@GetStatusOnClickNo

END

ELSE IF(@Operation=17)
BEGIN
BEGIN TRY    
BEGIN TRANSACTION  
		UPDATE Inv_Requisition SET ReqNo=@ReqNo,PreparedBy=@PreparedBy,AppBy=@AppBy,
		TentativeShipDate=@TentativeShipDate,
		ActualShipDate=@ActualShipDate,ReqStatus=@ReqStatus WHERE id=@Reqid		

		INSERT INTO [dbo].[Inv_RequisitionLogs]
		([ReqId], [UpdatedDate], [UpdatedBy])
		VALUES
		(@Reqid,GETDATE(),@LoginUserId)
		SET @msg=@Reqid
COMMIT TRANSACTION  
END TRY

BEGIN CATCH   
IF @@TRANCOUNT > 0  
SET @msg=Error_Number()
		ROLLBACK TRANSACTION  	
END CATCH 
END


ELSE IF(@Operation=18)
BEGIN
	DECLARE @EngDepID AS INT=NULL
	SET @EngDepID=(SELECT EngDepID FROM tblEmployees WHERE EmployeeID=@LoginUserId)
	IF(@EngDepID=7)
	BEGIN
		SET @msg=@EngDepID
	END
	ELSE
	BEGIN
		SET @msg='0'
	END
END
	
ELSE IF(@Operation=19)
BEGIN
		SELECT tblEmployees.EmployeeID,
		CONCAT(tblEmployees.FirstName + ' ', tblEmployees.LastName) AS FirstName FROM tblEmployees 
		WHERE FirstName IS NOT NULL AND tblEmployees.EngDepID=7 
		order by FirstName


		--Table 1
		SELECT id AS RequisitionID,ReqNo
		FROM Inv_Requisition 
		Order by ReqNo ASC

		--Table 2
		Select Inv_RequisitionStatus.id as ReqStatusID,
		Inv_RequisitionStatus.[Status]
		from Inv_RequisitionStatus		
		Order by [Status] asc
END
ELSE IF(@Operation=20)
BEGIN
		SELECT id AS RequisitionID,ReqNo
		FROM Inv_Requisition 
		WHERE Inv_Requisition.PreparedBy=@PreparedBy
		Order by ReqNo ASC

END
ELSE IF(@Operation=21)
BEGIN
		SELECT Inv_Requisition.PreparedBy as EmployeeID
		FROM Inv_Requisition 
		WHERE Inv_Requisition.id=@Reqid
		Order by ReqNo ASC

END
ELSE IF(@Operation=22)
BEGIN
		--Show Parts Grid in Pop up
		With CTE AS(		
		SELECT Inv_Parts.id as Partid,
		MIN(Inv_Source.[Source]) AS [Source],
		MIN(Inv_Parts.SourceId) AS [SourceId],
		MIN(Inv_Parts.PartNumber)  AS Partnumber,
		MIN(Inv_Parts.PartDes) AS PartDesc,
		MIN(Inv_ProductCode.[name]) as ProductCode,
		MIN(Inv_UM.UM) AS [UM],
		MIN(Inv_Parts.[min]) AS MinQty,
		MIN(Inv_Parts.[max]) AS MaxQty,
		SUM(Inv_Parts.[stockinhand]) as [StockInHand],NULL AS PartQty,
		MIN(Inv_Department.Department) AS [Department]
		FROM Inv_Parts			
		LEFT JOIN Inv_Department ON Inv_Department.id=Inv_Parts.DepartmentId
		left join Inv_UM ON Inv_UM.id=Inv_Parts.UMId
		LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id=Inv_Parts.productcode		
		LEFT JOIN Inv_Source ON Inv_Source.id=Inv_Parts.SourceId		
		Group by Inv_Parts.id)

		Select * from CTE
		WHERE ((CTE.[stockinhand]<= CTE.MinQty  and (MinQty <> 0 AND MinQty IS NOT NULL))
		OR (CTE.[stockinhand]=0  and (MinQty <> 0 AND MinQty IS NOT NULL))
		OR (CTE.[stockinhand] IS NULL  and (MinQty <> 0 AND MinQty IS NOT NULL))
		)

END
ELSE IF(@Operation=23)
BEGIN
	INSERT INTO Inv_RequisitionDetail(ReqID,PartId,PartQty,OrderType,Requestor,ShipmentBy)
	SELECT ReqId,PartId,OrderQty,1,110,1 FROM @dtPopUpParts AS dtParts
	

	SET @msg='Parts Added Successfully !'
END
ELSE IF(@Operation=24)
BEGIN
	SELECT Distinct PartId AS ID FROM Inv_RequisitionDetail WHERE ReqId=@Reqid
END		
END

