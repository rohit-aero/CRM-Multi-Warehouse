
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inv_Warehouse', @level2type=N'COLUMN',@level2name=N'StateId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inv_Warehouse', @level2type=N'COLUMN',@level2name=N'CountryId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inv_Warehouse', @level2type=N'COLUMN',@level2name=N'WarehouseName'
GO
/****** Object:  StoredProcedure [dbo].[INV_PartsMaintainance]    Script Date: 10/31/2025 03:23:24 PM ******/
DROP PROCEDURE [dbo].[INV_PartsMaintainance]
GO
/****** Object:  Table [dbo].[Inv_Warehouse]    Script Date: 10/31/2025 03:23:24 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inv_Warehouse]') AND type in (N'U'))
DROP TABLE [dbo].[Inv_Warehouse]
GO
/****** Object:  Table [dbo].[Inv_Warehouse]    Script Date: 10/31/2025 03:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Warehouse](
	[Id] [int] NOT NULL,
	[WarehouseName] [varchar](50) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[City] [varchar](50) NULL,
	[Address] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Inv_Warehouse] ([Id], [WarehouseName], [CountryId], [StateId], [City], [Address]) VALUES (1, N'Canada', 1, NULL, NULL, N'Aerowerks Inc.
6625 Millcreek Drive, Mississauga, ON L5N 5M4, Canada
Tel.: 905-363-6999 Fax.: 905-363-6998
Attn: Raman')
GO
INSERT [dbo].[Inv_Warehouse] ([Id], [WarehouseName], [CountryId], [StateId], [City], [Address]) VALUES (2, N'Agilent', 13, 0, NULL, N'Agilent Conveyor System Co. Ltd.                          Room 101, Building A1, 223 Huanguan Road Mid, Guanlan, Longhua  District, Shenzhen City, Guangdong 518110, China  Contact: Smile Fung')
GO
INSERT [dbo].[Inv_Warehouse] ([Id], [WarehouseName], [CountryId], [StateId], [City], [Address]) VALUES (3, N'Triflex', 19, 112, N'Mohali', N'Tri-flex Systems Pvt. Ltd.                                          Plot No. C-3 Industrial Focal Point, Derabassi, Punjab – 140507, India  Tel.: +917018587177; +919034018199')
GO
INSERT [dbo].[Inv_Warehouse] ([Id], [WarehouseName], [CountryId], [StateId], [City], [Address]) VALUES (4, N'Caddy', 2, NULL, NULL, N'Caddy Corporation of America                                          509 Sharptown Road, Bridgeport, NJ 08014-0345, Phone: 856-467-4222, Fax: 856-467-5511')
GO
INSERT [dbo].[Inv_Warehouse] ([Id], [WarehouseName], [CountryId], [StateId], [City], [Address]) VALUES (5, N'Gaffney', 2, NULL, NULL, N'330, Huntington Road                                          Gaffney, South Caroline')
GO
/****** Object:  StoredProcedure [dbo].[INV_PartsMaintainance]    Script Date: 10/31/2025 03:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ALTER TABLE Inv_parts ADD CompanyId INT NULL
CREATE PROCEDURE [dbo].[INV_PartsMaintainance]
@Operation INT = NULL,
@msg VARCHAR(50) = '' OUTPUT,
@PartNumber VARCHAR(50) = NULL,
@PartDes VARCHAR(250) = NULL,
@DepartmentId INT = NULL,
@Typeid INT = NULL,
@stockinhand INT = NULL,
@min INT = NULL,
@max INT = NULL,
@reorderpoint INT = NULL,
@reorderqty INT = NULL,
@leadtime INT = NULL,
@PartInfo VARCHAR(50) = NULL,
@partid INT = NULL,
@revisionnum CHAR(1) = NULL,
@PartStatus INT = NULL,
@partimage VARCHAR(500) = NULL,
@shopdrawing VARCHAR(500) = NULL,
@Drawingid INT = NULL,
@UMId INT = NULL,
@StockItem BIT = NULL,
@ForecastItem BIT = NULL,
@LoginUserID INT = NULL,
@LineStopper BIT = NULL,
@productcode INT = NULL,
@ProductID INT = NULL,
@customerpartnumber VARCHAR(50) = NULL,
@sourceid INT = NULL,
@CategoryID INT = NULL,
@Size INT = NULL,
@Direction VARCHAR(5) = NULL,	
@OptionID INT = NULL,
@LineStopperPriority VARCHAR(1) = NULL,
@CompanyId INT = NULL,
@MOQ INT = NULL,
@EAU INT = NULL,
@Batch INT = NULL
AS
BEGIN

SET NOCOUNT ON;
IF(@Operation = 1)
BEGIN
	--TABLE 0
	SELECT id AS productcodeid, [name] AS productcode  
	FROM Inv_ProductCode 
	ORDER BY sortorder ASC

	--TABLE 1
	SELECT id, Department 
	FROM Inv_Department 
	ORDER BY sortorder

	--TABLE 2
	SELECT id, [Source]
	FROM Inv_Source
	ORDER BY [Source] ASC

	--TABLE 3
	SELECT id, UM
	FROM Inv_UM
	ORDER BY UM	

	--TABLE 4
	SELECT Inv_Parts.id AS Partid, 	
	CASE WHEN (CustomerPartNumber IS NULL OR CustomerPartNumber = '') 
	THEN CONCAT(PartNumber + ', ', PartDes) 
	ELSE
	CONCAT(PartNumber + ', ', CustomerPartNumber + ', ', PartDes) 
	END AS PartDes 
	FROM Inv_Parts		
	ORDER BY [PartNumber] ASC	

	--Table 5
	SELECT [id], [name]
	FROM TW_Category
	ORDER BY [name]

	SELECT id, Company AS [text]
	FROM TW_Company
	ORDER BY Company
END

ELSE IF(@Operation = 2)
BEGIN
	IF NOT EXISTS(SELECT PartNumber FROM Inv_Parts WHERE LOWER(TRIM(Inv_Parts.PartNumber)) = LOWER(TRIM(@PartNumber)))
		BEGIN
			BEGIN TRY
			BEGIN TRANSACTION

			INSERT INTO Inv_Parts
			(productcode,PartNumber,CustomerPartNumber,ProductId,PartDes,DepartmentId,Typeid,
			revisionno,SourceId,[min],[max],reorderpoint,reorderqty,leadtime,PartStatus,UMId,Partimage,StockItem,ForecastItem,LineStopper,
			CategoryId, SizeID, Direction, OptionID, LineStopperPriority, CompanyId, MOQ, EAU, Batch)
			VALUES
			(@productcode, TRIM(@PartNumber), @customerpartnumber, @ProductID, dbo.ProperCase(@PartDes), @DepartmentId, @Typeid,
			@revisionnum, @sourceid, @min, @max, @reorderpoint, @reorderqty, @leadtime, @PartStatus, @UMId, @partimage, @StockItem, @ForecastItem, @LineStopper, 
			@CategoryID, @Size, @Direction, @OptionID, @LineStopperPriority, @CompanyId, @MOQ, @EAU, @Batch)

			SET @msg = SCOPE_IDENTITY()

			IF (@shopdrawing IS NOT NULL)
			BEGIN
				DECLARE @id AS INT = NULL
				SET @id = SCOPE_IDENTITY()

				INSERT INTO INV_PartsDWG (partid, revisionno, drawingname)
				VALUES (@id, @revisionnum, @shopdrawing)
			END

			IF @@TRANCOUNT > 0
					COMMIT
 
			END TRY

			BEGIN CATCH 
			IF @@TRANCOUNT > 0
					ROLLBACK
					Set @msg = ''
			END CATCH				
				
		END	
		ELSE
		BEGIN
			SET @msg = 'Duplicate Aerowerks Part No!!'
		END
	END

ELSE IF(@Operation = 3)
BEGIN
	SELECT Inv_Parts.id AS partid, ISNULL(PartNumber, '')  AS PartNumber, ISNULL(CustomerPartNumber, '') AS CustomerPartNumber,
	isnull(PartDes,'') AS PartDes, ISNULL(SourceId, '') AS SourceId, ISNULL(DepartmentId, '') AS DepartmentId,
	ISNULL((SELECT SUM(Inv_Parts_StockInHand.StockInHand)
		FROM Inv_Parts_StockInHand
		WHERE PartId = @partid
		GROUP BY PartId
	), 0) AS stockinhand, 
	(SELECT STRING_AGG(CONCAT(WarehouseName, ': ', ISNULL(StockInHand, 0)), ', ') AS Info
		FROM Inv_Parts_StockInHand
		INNER JOIN Inv_Warehouse ON Inv_Warehouse.Id = Inv_Parts_StockInHand.WarehouseId
		WHERE Inv_Parts_StockInHand.PartId = @partid) AS StockInHandToolTip,
	Inv_Parts.revisionno,
	CASE WHEN [min] <> 0 THEN [min] ELSE NULL END AS [min],
	CASE WHEN [max] <> 0 THEN [max] ELSE NULL END AS [max],
	CASE WHEN reorderpoint <> 0 THEN reorderpoint ELSE NULL END AS reorderpoint,
	CASE WHEN reorderqty <> 0 THEN reorderqty ELSE NULL END AS reorderqty,
	CASE WHEN leadtime <> 0 THEN leadtime ELSE NULL END AS leadtime ,
	ISNULL(Inv_Parts.PartStatus, 0) AS PartStatus, ISNULL(Inv_Parts.UMId, 0) AS UMId, Inv_Parts.Partimage,
	CASE WHEN Inv_Parts.StockItem IS NULL THEN '0'
	WHEN Inv_Parts.StockItem = 0 THEN '0'
	WHEN Inv_Parts.StockItem = 1 THEN '1' END AS StockItem,
	CASE WHEN Inv_Parts.ForecastItem IS NULL THEN '0'
	WHEN Inv_Parts.ForecastItem = 0 THEN '0'
	WHEN Inv_Parts.ForecastItem = 1 THEN '1' END AS ForecastItem,
	CASE WHEN Inv_Parts.LineStopper IS NULL THEN '0'
	WHEN Inv_Parts.LineStopper = 0 THEN '0'
	WHEN Inv_Parts.LineStopper = 1 THEN '1' END AS LineStopper,
	Inv_Parts.productcode AS productcode,
	Inv_Parts.ProductId AS ProductLineID, Inv_Parts.CategoryId, Inv_Parts.SizeID, Inv_Parts.OptionID, Inv_Parts.Direction,
	ISNULL(Inv_Parts.LineStopperPriority, '') AS LineStopperPriority, ISNULL(Inv_Parts.CompanyId, 0) AS CompanyId,
	ISNULL(Inv_Parts.MOQ, 0) AS MOQ, ISNULL(Inv_Parts.EAU, 0) AS EAU, ISNULL(Inv_Parts.Batch, 0) AS Batch
	FROM Inv_Parts 
	LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id = Inv_Parts.productcode
	LEFT JOIN Inv_Department ON Inv_Department.id = Inv_Parts.DepartmentId
	LEFT JOIN Inv_Product ON Inv_Product.id = Inv_Parts.ProductId
	WHERE Inv_Parts.id = @partid

	SELECT WarehouseName AS [Warehouse Name], ISNULL(StockInHand, 0) AS [Stock In Hand]
	FROM Inv_Parts_StockInHand
	INNER JOIN Inv_Warehouse ON Inv_Warehouse.Id = Inv_Parts_StockInHand.WarehouseId
	WHERE Inv_Parts_StockInHand.PartId = @partid
	ORDER BY Inv_Warehouse.WarehouseName
END

ELSE IF(@Operation = 5)
BEGIN
	IF NOT EXISTS(SELECT PartNumber FROM Inv_Parts WHERE LOWER(TRIM(Inv_Parts.PartNumber)) = LOWER(TRIM(@PartNumber)) AND id != @partid)
	BEGIN
		BEGIN TRY
		BEGIN TRANSACTION

		UPDATE Inv_Parts SET productcode = @productcode, PartNumber = TRIM(@PartNumber), CustomerPartNumber = dbo.ProperCase(@customerpartnumber), ProductId = @ProductID, PartDes = dbo.ProperCase(@PartDes),
		DepartmentId = @DepartmentId, Typeid = @Typeid, revisionno = @revisionnum,
		SourceId = @sourceid,
		[min] = @min, [max] = @max, reorderpoint = @reorderpoint, reorderqty = @reorderqty,
		leadtime = @leadtime, PartStatus = @PartStatus, UMId = @UMId, Partimage = @partimage, StockItem = @StockItem,
		ForecastItem = @ForecastItem, LineStopper = @LineStopper, CategoryId = @CategoryID, SizeID = @Size, OptionID = @OptionID, Direction = @Direction,
		LineStopperPriority = @LineStopperPriority, CompanyId = @CompanyId, MOQ = @MOQ, EAU = @EAU, Batch = @Batch
		WHERE id = @partid
 
		IF(@shopdrawing IS NOT NULL)
		BEGIN
			IF EXISTS(SELECT partid,revisionno FROM INV_PartsDWG WHERE partid = @partid AND revisionno = @revisionnum)
			BEGIN
				UPDATE INV_PartsDWG SET partid = @partid, revisionno = @revisionnum, drawingname = @shopdrawing
				WHERE partid = @partid AND revisionno = @revisionnum
			END
			ELSE
			BEGIN
				INSERT INTO INV_PartsDWG (partid, revisionno, drawingname)
				VALUES (@partid, @revisionnum, @shopdrawing)
			END
		END

		IF @@TRANCOUNT > 0
				COMMIT
			SET @msg = 'Records Updated Successfully !!'
		END TRY

		BEGIN CATCH 
		IF @@TRANCOUNT > 0
				ROLLBACK
				SET @msg = ''
		END CATCH							
	END	
	ELSE
	BEGIN
		SET @msg = 'Duplicate Aerowerks Part No!!'
	END		
END

ELSE IF(@Operation = 6)
BEGIN
	DELETE INV_PartsDWG 
	WHERE id = @partid
	SET @msg = 'Records Deleted Successfully !!!'
END

ELSE IF(@Operation = 7)
BEGIN
	SELECT Partimage 
	FROM Inv_Parts 
	WHERE id = @partid

	SELECT drawingname
	FROM INV_PartsDWG
	WHERE partid = @partid
END

ELSE IF(@Operation = 9)
BEGIN
	SELECT INV_PartsDWG.id AS Drawingid, INV_PartsDWG.revisionno, INV_PartsDWG.stockinhand,
	INV_PartsDWG.drawingname
	FROM Inv_Parts 
	INNER JOIN INV_PartsDWG ON INV_PartsDWG.partid = Inv_Parts.id
	WHERE INV_PartsDWG.partid = @partid AND INV_PartsDWG.revisionno = @revisionnum
	ORDER BY revisionno
END

ELSE IF(@Operation = 10)
BEGIN
	SELECT INV_PartsDWG.id AS Drawingid, INV_PartsDWG.revisionno, INV_PartsDWG.stockinhand,
	INV_PartsDWG.drawingname
	FROM Inv_Parts 
	INNER JOIN INV_PartsDWG ON INV_PartsDWG.partid=Inv_Parts.id
	WHERE INV_PartsDWG.partid = @partid
	ORDER BY revisionno
END

ELSE IF(@Operation = 14)
BEGIN
	SELECT ISNULL(Inv_Source.[Source], '') AS [Source], ISNULL(Inv_Department.Department, '') AS Department,
	CASE WHEN stockinhand <> 0 THEN stockinhand ELSE NULL END AS stockinhand,revisionno,
	CASE WHEN [min] <> 0 THEN [min] ELSE NULL END AS [min],
	CASE WHEN [max] <> 0 THEN [max] ELSE NULL END AS [max],
	CASE WHEN reorderpoint <> 0 THEN reorderpoint ELSE NULL END AS reorderpoint,
	CASE WHEN reorderqty <> 0 THEN reorderqty ELSE NULL END AS reorderqty,
	CASE WHEN leadtime <> 0 THEN leadtime ELSE NULL END AS leadtime,
	CASE WHEN ISNULL(Inv_Parts.PartStatus, 0) = 1 THEN 'Current'
	WHEN ISNULL(Inv_Parts.PartStatus, 0) = 2 THEN 'Obsolute' ELSE NULL END AS PartStatus,
	ISNULL(PartNumber, '') AS PartNumber, ISNULL(CustomerPartNumber, '') AS CustomerPartNumber,
	Inv_Parts.PartDes AS PartDes, ISNULL(Inv_UM.UM, '') AS UM,
	Inv_Parts.Partimage AS PartImage,Inv_Parts.LineStopper,
	Inv_ProductCode.[name] AS productcode, Inv_Product.[Product] AS ProductLine
	FROM Inv_Parts
	LEFT JOIN Inv_Source ON Inv_Source.id = Inv_Parts.SourceId
	LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id = Inv_Parts.productcode
	LEFT JOIN Inv_Department ON Inv_Department.id = Inv_Parts.DepartmentId
	LEFT JOIN Inv_UM ON Inv_UM.id = Inv_Parts.UMId	
	LEFT JOIN Inv_Product ON Inv_Product.id = Inv_Parts.ProductId
	WHERE Inv_Parts.id = @partid
END

ELSE IF(@Operation = 15)
BEGIN
	SET @msg = (SELECT TOP(1)Partimage
	FROM Inv_Parts 
	WHERE Inv_Parts.productcode = @partid)
END

ELSE IF(@Operation = 16)
BEGIN
	SELECT Inv_Parts.id AS Partid, 	
	CASE WHEN (CustomerPartNumber IS NULL OR CustomerPartNumber = '') 
	THEN CONCAT(PartNumber + ', ', PartDes) 
	ELSE
	CONCAT(PartNumber + ', ', CustomerPartNumber + ', ', PartDes) 
	END AS PartDes
	FROM Inv_Parts
	WHERE Inv_Parts.productcode = @productcode
	ORDER BY [PartNumber] ASC
END

ELSE IF(@Operation = 17)
BEGIN
	SELECT productcode
	FROM Inv_Parts 
	LEFT JOIN Inv_ProductCode ON Inv_ProductCode.id = Inv_Parts.productcode
	WHERE Inv_Parts.id = @partid	
END

ELSE IF(@Operation = 18)
BEGIN
	SELECT id AS ProductID, Product  
	FROM Inv_Product
	WHERE Inv_Product.ProductLineSubID = @productcode
	ORDER BY Product ASC
END	

ELSE IF(@Operation = 19)
BEGIN
	SELECT [ID], SizeName
	FROM TW_Size
	WHERE CategoryID = @CategoryID
	ORDER BY [SizeName]
END

ELSE IF (@Operation = 20)
BEGIN
	DECLARE @CheckUser AS INT = NULL
	SET @CheckUser = (SELECT EmployeeID FROM tblEmployees WHERE EmployeeID = @LoginUserID)
	IF(@CheckUser IN (1382, 1383))
	BEGIN
		SELECT 1 AS [CheckAccess]
	END
	ELSE
	BEGIN
		SELECT 0 AS [CheckAccess]
	END
END
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aerowerks US/Aerowerks CAD/Tragenflex' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inv_Warehouse', @level2type=N'COLUMN',@level2name=N'WarehouseName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'tblCountries.CountryID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inv_Warehouse', @level2type=N'COLUMN',@level2name=N'CountryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'tblStates.StateID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inv_Warehouse', @level2type=N'COLUMN',@level2name=N'StateId'
GO
