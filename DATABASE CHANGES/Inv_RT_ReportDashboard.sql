--EXEC [Inv_RT_ReportDashboard] 4, ' And Inv_Parts.id = 2 ' 
ALTER PROCEDURE [IV].[Inv_RT_ReportDashboard] 
	@Operation	INT = NULL,
	@searchvar VARCHAR(MAX) = NULL,
	@ProductLine INT = 0,
	@ProductCode	INT=0,
	@SourceID	INT=NULL,
	@ReportTypeID INT=NULL
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @STARTDATE DATE = GETDATE(), @ENDDATE DATE = DATEADD(MONTH, 6, GETDATE()) 
	IF(@Operation = 1)
	BEGIN
		SELECT Id as [SourceID],
		Inv_Warehouse.[WarehouseName] AS [Source] 		
		FROM Inv_Warehouse
		Order by Inv_Warehouse.[WarehouseName] ASC

		SELECT id, Product AS [text]
		FROM Inv_Product
		ORDER BY Product

		SELECT ID, CONCAT(PartNumber, ', ' + PartDes) AS [text]
		FROM Inv_Parts
		WHERE ID IS NOT NULL
		ORDER BY PartNumber

		SELECT ID, [name] AS [text]
		FROM Inv_ProductCode
		ORDER BY [sortorder]
	END

	ELSE IF(@Operation = 2)
	BEGIN
		DECLARE @Qry AS VARCHAR(MAX)='
		SELECT  
			Inv_Container.id AS [Container ID], 
			MIN(InvoiceNo) AS [Invoice No], 
			MIN(ContainerNo) AS [Container No],
			CASE WHEN MAX(Inv_Container.Shipmentby)=1 Then ''By Sea''
			WHEN MAX(Inv_Container.Shipmentby)=2 Then ''By Air'' End as [Shipment By],
			(SELECT TOP 1  CASE WHEN [Status]=1 Then ''On the water'' 
			When [Status]=2 Then ''At the port''
			When [Status]=3 Then ''On the rail'' End as [Status]
			FROM Inv_ContainerShipmentStatus		
			WHERE Inv_ContainerShipmentStatus.ContainerID=Inv_Container.id
			ORDER BY Inv_ContainerShipmentStatus.RevisedETA DESC) AS [Status],
			MIN(Inv_Source.[WarehouseName]) AS [Source], 
			MIN(Inv_Warehouse.[WarehouseName]) AS [Destination],
			MIN(Convert(Varchar(10), Inv_Container.ArrivalInAerowerks, 101)) AS [Tentative Arrival In Aerowerks], 
			(SELECT TOP 1 CONVERT(Varchar(20),Inv_ContainerShipmentStatus.RevisedETA,101) as ETA FROM Inv_ContainerShipmentStatus		
			WHERE Inv_ContainerShipmentStatus.ContainerID=Inv_Container.id
			ORDER BY Inv_ContainerShipmentStatus.RevisedETA DESC) AS [ETA],
			(SELECT TOP 1 Inv_ContainerShipmentStatus.Comments FROM Inv_ContainerShipmentStatus		
			WHERE Inv_ContainerShipmentStatus.ContainerID=Inv_Container.id
			ORDER BY Inv_ContainerShipmentStatus.RevisedETA DESC) AS [Comments]				
		FROM Inv_Container 
		LEFT JOIN Inv_ContainerShipmentStatus ON Inv_ContainerShipmentStatus.ContainerID = Inv_Container.id
		LEFT JOIN Inv_Warehouse as Inv_Source ON Inv_Source.id = Inv_Container.Sourceid     
		LEFT JOIN tblShipmentLogs ON tblShipmentLogs.Containerid=Inv_Container.id
		LEFT JOIN Inv_Warehouse ON Inv_Warehouse.Id=Inv_Container.WareHouseID
		WHERE IsSubmitted=1 AND IsStockIn IS NULL AND ReceivedDate IS NULL'+ @searchvar
		Exec (@Qry)
	END

	ELSE IF(@Operation = 3)
	BEGIN
		DECLARE @ArrivedContainerQry as Varchar(MAX)='DECLARE @ArrivedTableData as Table (
				ContainerID		int,
				InvoiceNo		Varchar(50),
				ContainerNo		Varchar(50),
				[Source]		Varchar(50),
				[Destination]		Varchar(50),
				TentativeSentDate DATE,
				ReceivedDate	Date,
				StockIn			Varchar(50)			
			)

			INSERT INTO @ArrivedTableData
			SELECT  Inv_Container.id,InvoiceNo,ContainerNo,Inv_Source.[WarehouseName],
			Inv_Warehouse.[WarehouseName] as [Destination]
			,TentativeSentDate,ReceivedDate,NULL			
			FROM Inv_Container
			LEFT JOIN Inv_Warehouse as Inv_Source ON Inv_Source.id=Inv_Container.Sourceid
			LEFT JOIN Inv_Warehouse ON Inv_Warehouse.Id=Inv_Container.WareHouseID
			WHERE IsSubmitted=1 AND ReceivedDate IS NOT NULL AND (IsStockIn<>-1 OR IsStockIn IS NULL)
			Order by ReceivedDate desc

			DECLARE @ContainerID INT
			DECLARE CUR_PART CURSOR	

			STATIC FOR
			SELECT ContainerID FROM @ArrivedTableData
			OPEN CUR_PART

			IF @@CURSOR_ROWS > 0
			BEGIN
			FETCH NEXT FROM CUR_PART INTO @ContainerID

			WHILE @@FETCH_STATUS = 0
			BEGIN
				DECLARE @StockInData AS int
				SET @StockInData=(
					SELECT IsStockIn FROM Inv_Container where id=@ContainerID			
				)

				if(@StockInData>0)
				BEGIN
					UPDATE @ArrivedTableData SET StockIn=''Yes'' where ContainerID=@ContainerID
				END
				ELSE
				BEGIN
					UPDATE @ArrivedTableData SET StockIn=''No'' where ContainerID=@ContainerID
				END

			FETCH NEXT FROM CUR_PART INTO @ContainerID
			END
			END		
			CLOSE CUR_PART
			DEALLOCATE CUR_PART


			SELECT ContainerID as [Container ID],InvoiceNo as [Invoice No],
			ContainerNo as [Container No],[Source],[Destination],Convert(Varchar(20),TentativeSentDate,101) as [Ship Date],
			Convert(Varchar(20),ReceivedDate,101) as [Received Date],StockIn as [Stock In]			
			FROM @ArrivedTableData WHERE ContainerID IS NOT NULL' + @searchvar

			EXEC(@ArrivedContainerQry)

	END

	ELSE IF(@Operation = 4)
	BEGIN
		DECLARE @InventoryParts AS VARCHAR(MAX)='
		SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [SrNo], *
		FROM
		(
		SELECT DISTINCT Inv_Parts.id, CONCAT(PartNumber, '', '' + PartDes) AS [PartNo], 
			(SELECT [dbo].[InStockCalculations] (Inv_Parts.id)) AS [StockInHand], 
			(SELECT [dbo].[InTransitCalculation] (Inv_Parts.id)) AS [InTransit],
			(SELECT CASE WHEN SUM(InShop) <= 0 Then NULL ELSE SUM(InShop) END AS InShop
				FROM Inv_PurchaseOrderDetails_InShop(Inv_Parts.id)
				GROUP BY PartID) AS [InProduction], 
			(
				SELECT CAST(SUM(Inv_AWProduct_Projects.Qty) AS INT) AS Qty
				FROM Inv_AWProduct_Parts
				INNER JOIN Inv_AWProduct_Projects ON Inv_AWProduct_Projects.AWProductPartsID = Inv_AWProduct_Parts.id
				INNER JOIN tblProjects on tblProjects.JobID = Inv_AWProduct_Projects.JobID					
				WHERE 
					CASE WHEN ISNULL(Inv_AWProduct_Parts.ChildPartID, 0) = 0 THEN Inv_AWProduct_Parts.ParentPartID ELSE Inv_AWProduct_Parts.ChildPartID END = Inv_Parts.ID
					 AND ProjectStatus NOT IN (2, 3) AND tblProjects.ShipDate BETWEEN ''' + CONVERT(VARCHAR, @STARTDATE, 101) + ''' AND ''' + CONVERT(VARCHAR, @ENDDATE, 101) + ''' 
				) AS [InForcast]
			FROM Inv_Parts		
			LEFT JOIN Inv_Parts_StockInHand ON Inv_Parts_StockInHand.PartId=Inv_Parts.id
			LEFT JOIN Inv_Product ON Inv_Product.ID = Inv_Parts.ProductID
			LEFT JOIN Inv_ContainerDetail ON Inv_Parts.id = Inv_ContainerDetail.PartId 
			LEFT JOIN Inv_Container ON Inv_Container.id = Inv_ContainerDetail.ContainerId 
			LEFT JOIN Inv_Warehouse on   Inv_Warehouse.id = Inv_Parts.SourceId
			WHERE Inv_Parts.ID IS NOT NULL ' + @searchvar + '
			) AS MAINQUERY ORDER BY PartNo'

	EXEC(@InventoryParts)
	END

	ELSE IF(@Operation = 5)
	BEGIN
		IF(@ProductCode>0 AND @ProductLine=0)
		BEGIN
			SELECT ID, CONCAT(PartNumber, ', ' + PartDes) AS [text]
			FROM Inv_Parts
			WHERE ID IS NOT NULL AND Inv_Parts.productcode=@ProductCode
			ORDER BY PartNumber
		END
		ELSE IF(@ProductCode>0 AND @ProductLine>0)
		BEGIN
			SELECT ID, CONCAT(PartNumber, ', ' + PartDes) AS [text]
			FROM Inv_Parts
			WHERE ID IS NOT NULL AND productcode=@ProductCode AND ProductId=@ProductLine
			ORDER BY PartNumber
		END
		ELSE
		BEGIN
			SELECT ID, CONCAT(PartNumber, ', ' + PartDes) AS [text]
			FROM Inv_Parts
			WHERE ID IS NOT NULL AND (@ProductLine = 0 OR ProductId = @ProductLine)
			ORDER BY PartNumber
		END
	END

	ELSE IF(@Operation = 6)
	BEGIN
		SELECT [Month Name], SUM(qty) AS Qty 
	FROM
	(
		SELECT DATENAME(MONTH, ShipDate) AS [Month Name], CAST(Inv_AWProduct_Projects.Qty AS INT) AS Qty
		FROM Inv_AWProduct_Projects
		INNER JOIN tblProjects ON tblProjects.JobID = Inv_AWProduct_Projects.JobID
		INNER JOIN Inv_AWProduct_Parts ON Inv_AWProduct_Parts.id = Inv_AWProduct_Projects.AWProductPartsID
		WHERE tblProjects.ShipDate BETWEEN @STARTDATE AND @ENDDATE AND ProjectStatus NOT IN (2, 3)
		AND CASE WHEN ISNULL(Inv_AWProduct_Parts.ChildPartID, 0) = 0 THEN Inv_AWProduct_Parts.ParentPartID ELSE Inv_AWProduct_Parts.ChildPartID END = @ProductLine
	) AS p
	GROUP BY [Month Name]
	ORDER BY 
	CASE [Month Name] WHEN 'January' THEN 1 WHEN 'February' THEN 2 WHEN 'March' THEN 3 WHEN 'April' THEN 4 WHEN 'May' THEN 5 WHEN 'June' THEN 6 WHEN 'July' THEN 7 WHEN 'August' THEN 8 WHEN 'September' THEN 9
		WHEN 'October' THEN 10 WHEN 'November' THEN 11 WHEN 'December' THEN 12 ELSE 0 
	END

	SELECT ID, CONCAT(PartNumber, ', ' + PartDes) AS [text]
	FROM Inv_Parts
	WHERE ID = @ProductLine
	END

	ELSE IF(@Operation = 7)
	BEGIN
		SELECT id, Product AS [text]
		FROM Inv_Product
		WHERE ProductLineSubID = @ProductLine OR @ProductLine = 0
		ORDER BY Product
	END

	ELSE IF(@Operation=8)
	BEGIN
		DECLARE @InventoryPartsExcel AS VARCHAR(MAX)='
		SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Sr. No], *
		FROM
		(
		SELECT DISTINCT Inv_Parts.id, CONCAT(PartNumber, '', '' + PartDes) AS [Part No], 
			(SELECT [dbo].[InStockCalculations] (Inv_Parts.id)) AS [Stock In Hand], 
			(SELECT [dbo].[InTransitCalculation] (Inv_Parts.id)) AS [In Transit],
			(SELECT CASE WHEN SUM(InShop) <= 0 Then NULL ELSE SUM(InShop) END AS InShop
				FROM Inv_PurchaseOrderDetails_InShop(Inv_Parts.id)
				GROUP BY PartID) AS [In Production], 
			(
				SELECT CAST(SUM(Inv_AWProduct_Projects.Qty) AS INT) AS Qty
				FROM Inv_AWProduct_Parts
				INNER JOIN Inv_AWProduct_Projects ON Inv_AWProduct_Projects.AWProductPartsID = Inv_AWProduct_Parts.id
				INNER JOIN tblProjects on tblProjects.JobID = Inv_AWProduct_Projects.JobID					
				WHERE 
					CASE WHEN ISNULL(Inv_AWProduct_Parts.ChildPartID, 0) = 0 THEN Inv_AWProduct_Parts.ParentPartID ELSE Inv_AWProduct_Parts.ChildPartID END = Inv_Parts.ID
					 AND ProjectStatus NOT IN (2, 3) AND tblProjects.ShipDate BETWEEN ''' + CONVERT(VARCHAR, @STARTDATE, 101) + ''' AND ''' + CONVERT(VARCHAR, @ENDDATE, 101) + ''' 
				) AS [In Forcast]
			FROM Inv_Parts		
			LEFT JOIN Inv_Parts_StockInHand ON Inv_Parts_StockInHand.PartId=Inv_Parts.id
			LEFT JOIN Inv_Product ON Inv_Product.ID = Inv_Parts.ProductID
			LEFT JOIN Inv_ContainerDetail ON Inv_Parts.id = Inv_ContainerDetail.PartId 
			LEFT JOIN Inv_Container ON Inv_Container.id = Inv_ContainerDetail.ContainerId 
			LEFT JOIN Inv_Warehouse as Inv_Source ON Inv_Source.id = Inv_Parts.SourceId
			WHERE Inv_Parts.ID IS NOT NULL ' + @searchvar + '
			) AS MAINQUERY ORDER BY [Part No]'

			EXEC(@InventoryPartsExcel)

	END

	ELSE IF(@Operation=9)
	BEGIN
		IF(@ReportTypeID IN (1,2))
		BEGIN
			SELECT Id as [SourceID],
			Inv_Warehouse.[WarehouseName] AS [Source] 		
			FROM Inv_Warehouse
			Order by Inv_Warehouse.[WarehouseName] ASC
		END
		ELSE
		BEGIN
			SELECT Id as [SourceID],
			Inv_Source.[Source] AS [Source] 		
			FROM Inv_Source
			Order by Inv_Source.Id ASC
		END
	END
END
