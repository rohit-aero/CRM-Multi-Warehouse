/****** Object:  StoredProcedure [dbo].[Get_SalesWeekly]    Script Date: 11/01/2025 01:01:55 PM ******/
DROP PROCEDURE [dbo].[Get_SalesWeekly]
GO
/****** Object:  StoredProcedure [dbo].[Get_SalesUsaCanProduction]    Script Date: 11/01/2025 01:01:55 PM ******/
DROP PROCEDURE [dbo].[Get_SalesUsaCanProduction]
GO
/****** Object:  StoredProcedure [dbo].[Get_ChinaProjects]    Script Date: 11/01/2025 01:01:55 PM ******/
DROP PROCEDURE [dbo].[Get_ChinaProjects]
GO
/****** Object:  StoredProcedure [dbo].[aero_ManageForecasting]    Script Date: 11/01/2025 01:01:55 PM ******/
DROP PROCEDURE [dbo].[aero_ManageForecasting]
GO
/****** Object:  View [dbo].[qryNewProjects]    Script Date: 11/01/2025 01:01:55 PM ******/
DROP VIEW [dbo].[qryNewProjects]
GO
/****** Object:  View [dbo].[qryNewProjects]    Script Date: 11/01/2025 01:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[qryNewProjects]
AS
SELECT dbo.tblProjects.JobID, dbo.tblPFiles.City, dbo.tblStates.State, dbo.tblProjects.PORec, dbo.tblPFiles.OrderBelongsTo, dbo.tblProjects.OASentTo, dbo.tblProjects.OASentToContact, dbo.tblProjects.QuoteSelected, dbo.tblPFiles.DealerID, 
                  dbo.tblProjects.CustomerID, dbo.tblPFiles.ConveyorTypeID, dbo.tblProjects.ShipperID, dbo.tblProjects.SiteContact, dbo.tblProjects.SiteContactTelephone, dbo.tblProjects.ReleaseDate, dbo.tblProjects.DateAsBuiltDrgsSent, 
                  dbo.tblProjects.TestRunDate, dbo.tblProjects.ShipDate, dbo.tblProjects.ActualCompletionDate, dbo.tblProjects.ShipToArriveDate, dbo.tblProjects.ArrivalDate, dbo.tblProjects.InstallDate, dbo.tblProjects.InstallationCompletionDate, 
                  dbo.tblProjects.DemoDate, dbo.tblProjects.WarrantyStartDate, dbo.tblProjects.WarrantyEndDate, dbo.tblProjects.FollowUpDate, dbo.tblProjects.PONumber, dbo.tblProjects.InvoiceNumber, dbo.tblProjects.DateInvoiceSent, 
                  dbo.tblProjects.DatePaymentReceived, dbo.tblProjects.DateCommissionPaid, dbo.tblProjects.KflexCheckNumber, dbo.tblProjects.SalesSourceID, dbo.tblProjects.ProjectDesignerID, dbo.tblProjects.ShipToName, 
                  dbo.tblProjects.ShipToStreet, dbo.tblProjects.ShipToCity, dbo.tblProjects.ShipToState, dbo.tblProjects.ShipToCountry, dbo.tblProjects.ShipToZipCode, dbo.tblProjects.discount, dbo.tblProjects.fob, dbo.tblProjects.term, 
                  dbo.tblProjects.IndComDate, dbo.tblProjects.AeroChequeNum, dbo.tblProjects.PreInspectionDate, dbo.tblProjects.CheckedByOffice, dbo.tblProjects.CheckedByPlant, dbo.tblProjects.EstCompletionDate, dbo.tblProjects.ProposalID, 
                  dbo.tblPFiles.OriginRepID, dbo.tblPFiles.ConsultRepID, dbo.tblPFiles.RepID, dbo.tblPFiles.ConsultantID, dbo.tblPFiles.ModelID, dbo.tblPFiles.Price, dbo.tblPFiles.Freight, dbo.tblPFiles.Installation, dbo.tblPFiles.CurrencyID, 
                  dbo.tblProjects.CommissionType, dbo.tblProjects.SystemDesignA, dbo.tblProjects.SystemDesignB, dbo.tblProjects.SystemDesignC, dbo.tblPFiles.Specification, dbo.tblProjects.Quote, dbo.tblProjects.CustCarePackageSendDate, 
                  dbo.tblProjects.JobOrderDate, dbo.tblProjects.JobOrderAck, dbo.tblProjects.JobOADis, dbo.tblPFiles.CurrentStatus, dbo.tblPFiles.OrderProbabilityID, dbo.tblPFiles.DetailedQuote, dbo.tblPFiles.Specifications, 
                  dbo.tblProjects.InstallationBy, dbo.tblPFiles.DPics, dbo.tblPFiles.RefDrawing, dbo.tblProjects.DealerMember, dbo.tblCustomers.CompanyName + ', ' + ISNULL(dbo.tblCustomers.City, '') + ', ' + ISNULL(dbo.tblStates.State, NULL) 
                  AS ProjectName, dbo.tblProjects.ExWarrantyPrice, dbo.tblProjects.NetAmount, dbo.tblPFiles.NetEqPrice, dbo.tblPFiles.EqDisAmount, dbo.tblPFiles.EqDiscount, dbo.tblCustomers.SerRep, dbo.tblProjects.GST, dbo.tblPFiles.SiteFloor, 
                  dbo.tblPFiles.DoorOpen, dbo.tblPFiles.Width, dbo.tblPFiles.Height, dbo.tblPFiles.Depth, dbo.tblProjects.InstallatorA, dbo.tblProjects.InstallatorB, dbo.tblProjects.InstallatorC, dbo.tblProjects.ConCost, dbo.tblProjects.ConRoylAmt, 
                  dbo.tblProjects.ConCheckNo, dbo.tblProjects.ConChqPaidDt, dbo.tblProjects.Comments, dbo.tblProjects.ReviewedBy, dbo.tblProjects.ManualDispatchDate, dbo.tblProjects.DateAssigned, dbo.tblProjects.ProjDataPrepBy, 
                  dbo.tblProjects.ProjFormReviewByAI, dbo.tblProjects.ProjFormReviewByHO, dbo.tblProjects.PFRBAIDate, dbo.tblProjects.PFRBHODate, dbo.tblProjects.FeedBackConsultant, dbo.tblProjects.[FeedBack Dealer], 
                  dbo.tblProjects.[Summ of Sugg], dbo.tblProjects.FreightPaid, dbo.tblProjects.ProposalID AS Expr1, dbo.tblProjects.CommissionType AS Expr2, dbo.tblPFiles.NetEqPrice AS Expr3, dbo.tblPFiles.SpecCreditPercentID, 
                  dbo.tblPFiles.SpecCreditPercentID AS Expr4, dbo.tblPFiles.SpecCreditCheckNo, dbo.tblPFiles.SpecCreditPaidDate, dbo.tblPFiles.SpecCredits, dbo.tblPFiles.SpecCreditAmount, dbo.tblProjects.GSICommissionType, 
                  dbo.tblProjects.GSICommissionAmount, dbo.tblProjects.GSICommissionCheckNo, dbo.tblProjects.GSICommissionSentDate, dbo.tblHobartListing.FirstName + ' ' + dbo.tblHobartListing.LastName AS RepName, dbo.tblProjects.MfgFacilityID, 
                  dbo.tblProjects.ReleasedToShop, dbo.tblEmployees.FirstName, dbo.tblConveyorModel.ModelName, dbo.tblProjects.ConveyorTypeID AS Expr5, dbo.tblProjects.CheckNoOrgRep, dbo.tblProjects.CheckNoDesRep, 
                  dbo.tblProjects.ProjectStatus, dbo.tblProjects.JobType, dbo.tblProjects.ExistingJobID, dbo.tblProjects.ModelID AS Expr6, dbo.tblProjects.ServiceRepID, dbo.tblProjects.EstReleaseDate, dbo.tblProjects.NoInstallation, 
                  dbo.tblProjects.CommissionText, dbo.tblProjects.Specification AS Expr7, dbo.tblProjects.DigitalPicOnServer, dbo.tblProjects.ReferenceDrawing, dbo.tblProjects.BuyOutCost, dbo.tblProjects.RawMaterial, 
                  dbo.tblProjects.DrgSentOutforApproval, dbo.tblProjects.AppDrgWithFieldDimension, dbo.tblProjects.AppDrgAck, dbo.tblProjects.EquipDelConfirmed, dbo.tblProjects.AccReqFromCustomer, dbo.tblProjects.BuiltDrgWithUnderStruSent, 
                  dbo.tblProjects.FabDrgReviewByAI, dbo.tblProjects.FabDrgReviewByHO, dbo.tblProjects.ShippingCommit, dbo.tblProjects.ReleasedToNesting, dbo.tblProjects.NestingStatus, dbo.tblProjects.FabSentToCanada, 
                  dbo.tblProjects.CashDisAmt, dbo.tblProjects.CashDisPer, dbo.tblProjects.CashAmtRec, dbo.tblProjects.AmountForComission, dbo.tblProjects.Status, dbo.tblProjects.ExpectedArrivalDatefromChina, dbo.tblProjects.PurchasedItems, 
                  dbo.tblProjects.PurchasedItemsCAD, dbo.tblProjects.Issued, dbo.tblProjects.ReleaseDateChina, dbo.tblProjects.ProjectDesignerChinaID, dbo.tblProjects.filepath, dbo.tblProjects.CorrectedBy,
                  Inv_Warehouse.WarehouseName, tblProjects.WareHouseId
FROM     dbo.tblHobartListing RIGHT OUTER JOIN
                  dbo.tblProjects INNER JOIN
                  dbo.tblPFiles ON dbo.tblProjects.ProposalID = dbo.tblPFiles.PNumber LEFT OUTER JOIN
                  dbo.tblEmployees ON dbo.tblPFiles.projectmanagerid = dbo.tblEmployees.EmployeeID ON dbo.tblHobartListing.RepID = dbo.tblPFiles.RepID LEFT OUTER JOIN
                  dbo.tblConveyorModel ON dbo.tblPFiles.ModelID = dbo.tblConveyorModel.ModelID LEFT OUTER JOIN
                  dbo.tblCustomers ON dbo.tblProjects.CustomerID = dbo.tblCustomers.CustomerID LEFT OUTER JOIN
                  dbo.tblStates ON dbo.tblCustomers.StateID = dbo.tblStates.StateID
                  LEFT JOIN Inv_Warehouse ON Inv_Warehouse.Id = tblProjects.WareHouseId
WHERE  (dbo.tblProjects.ProjectStatus IN (0, 1))
GO
/****** Object:  StoredProcedure [dbo].[aero_ManageForecasting]    Script Date: 11/01/2025 01:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[aero_ManageForecasting]	
	@Operation INT,
	@StartDate NVARCHAR(10) = NULL,
	@EndDate NVARCHAR(10) = NULL,
	@Product INT = 0, 
	@MfgId INT = 0,
	@msg VARCHAR(50) = ''  OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF(@Operation = 1)
	BEGIN		
		--TABLE 0
		SELECT ID, [name] AS [Product]
		FROM Inv_AWProduct 
		WHERE IsActive = '1'
		ORDER BY [Product]	

		--TABLE 1
		SELECT ID, WarehouseName AS [text]
		FROM Inv_Warehouse		
		ORDER BY WarehouseName

		--TABLE 2
		SELECT Inv_Product.id, Product 
		FROM Inv_Product
		INNER JOIN INV_ProductLineSub Sub ON Sub.id = Inv_Product.ProductLineSubID
		INNER JOIN INV_ProductLine ON INV_ProductLine.id = Sub.ProductLineID
		WHERE Product IS NOT NULL AND INV_ProductLine.id = 1
		ORDER BY Product
	END

	ELSE IF(@Operation = 2)
	BEGIN
		DECLARE @SqlStatement NVARCHAR(MAX) = ''

		 SET @SqlStatement = ' Select distinct MONTH(tblProjects.ShipDate) AS ShipDateMonthNumber, FORMAT(tblProjects.ShipDate, ''MMMM'') AS _,  
		 CASE WHEN min(Inv_Parts.PartStatus)=2 THEN  ''(Obsolete) '' +  MIN(Inv_Parts.PartNumber) +'' ''+   MIN(ISNULL(Inv_Parts.revisionno,'''')) 
			ELSE MIN(Inv_Parts.PartNumber) +'' '' END  AS [Part No], MIN(Inv_Parts.PartDes) AS [Part Description], 
				(SELECT SUM(qty)
				FROM Inv_ProjectParts
				INNER JOIN tblProjects TQRP ON TQRP.JobID = Inv_ProjectParts.projectid
				INNER JOIN Inv_Parts INV ON INV.id = Inv_ProjectParts.partid
				WHERE Inv_ProjectParts.qty IS NOT NULL  
				AND TQRP.ProjectStatus NOT IN (2, 3) AND INV.StockItem = 1 
				AND  FORMAT(TQRP.ShipDate, ''MMMM'') = FORMAT(tblProjects.ShipDate, ''MMMM'')  AND TQRP.ShipDate BETWEEN ''' + @StartDate + ''' AND ''' + @EndDate + '''	
				'+ CASE WHEN @Product > 0 THEN ' AND Inv_Parts.ProductId = ' + CONVERT(VARCHAR(10), @Product) ELSE '' END + '
				'+ CASE WHEN @MfgId > 0 THEN ' AND TQRP.WareHouseId = ' + CONVERT(VARCHAR(10), @MfgId) ELSE '' END + '
				AND INV.id = Inv_Parts.id
				) AS [Qty]
			FROM Inv_Parts     
			INNER JOIN Inv_Product ON Inv_Product.id=Inv_Parts.ProductId  
			LEFT JOIN Inv_ProjectParts ON Inv_ProjectParts.partid=Inv_Parts.id     
			LEFT JOIN tblProjects ON Inv_ProjectParts.projectid=tblProjects.JobID   
			LEFT JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID    
			LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID    
			WHERE Inv_ProjectParts.qty IS NOT NULL  
					AND tblProjects.ProjectStatus NOT IN (2, 3) AND Inv_Parts.StockItem = 1    
					AND  tblProjects.ShipDate BETWEEN ''' + @StartDate + ''' AND ''' + @EndDate + '''		
					'+ CASE WHEN @Product > 0 THEN ' AND Inv_Parts.ProductId = ' + CONVERT(VARCHAR(10), @Product) ELSE '' END + '
					'+ CASE WHEN @MfgId > 0 THEN ' AND tblProjects.WareHouseId = ' + CONVERT(VARCHAR(10), @MfgId) ELSE '' END + '
			GROUP BY Inv_Parts.ProductId, Inv_Parts.id, PartNumber, Inv_Parts.PartDes, FORMAT(tblProjects.ShipDate, ''MMMM''), MONTH(tblProjects.ShipDate)
			ORDER BY MONTH(tblProjects.ShipDate), [Part No]
		'
		 EXEC sp_executesql @SqlStatement 
	END  
END
GO
/****** Object:  StoredProcedure [dbo].[Get_ChinaProjects]    Script Date: 11/01/2025 01:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_ChinaProjects] 	
	@FromDate		DATE = NULL,
	@ToDate			DATE = NULL,
	@Operation		INT = NULL,
	@For			INT = NULL-- 3: India. 2: China. 0: All
AS
BEGIN
	SET NOCOUNT ON;
	IF(@Operation = 1)
	BEGIN  
		SELECT tblProjects.JobID,tblCustomers.CompanyName AS [Customer],
		tblDealers.CompanyName AS Dealer, tblProjects.PONumber, 
		tblProjects.ShipDate,
		CASE WHEN tblProjects.ShippingCommit = 'F' THEN 'Firm'
		WHEN tblProjects.ShippingCommit = 'T' THEN 'Tentative' END AS ShippingCommit, 
		tblPFiles.NetEqPrice,
		tblEmployees.FirstName AS [Project Manager],
		CASE WHEN tblProjects.[Status] = 1 THEN 'In Production Canada'
		WHEN tblProjects.[Status] = 2 THEN 'Shipped'
		When tblProjects.[Status] = 3 THEN 'Arrived'
		When tblProjects.[Status] = 4 THEN 'In Production China'
		WHEN tblProjects.[Status] = 5 THEN 'Completed'
		WHEN tblProjects.[Status] = 6 THEN 'In Process'
		WHEN tblProjects.[Status] = 7 THEN 'Submit For Review' END AS [Fabrication Status]
		,ShipDateFromChina AS ShipDateFromChina,
		Inv_Warehouse.WarehouseName AS FacilityName,
		CONVERT(VARCHAR(10), ExpectedArrivalDatefromChina, 1) AS [ExpectedArrivalDatefromChina]
		FROM tblPFiles
		INNER JOIN tblProjects ON tblProjects.ProposalID = tblPFiles.PNumber
		INNER JOIN tblDealers ON tblDealers.DealerID = tblPFiles.DealerID
		INNER JOIN tblCustomers ON tblCustomers.CustomerID = tblProjects.CustomerID
		INNER JOIN tblEmployees ON tblEmployees.EmployeeID = tblPFiles.projectmanagerid
		LEFT JOIN Inv_Warehouse ON Inv_Warehouse.ID = tblProjects.WareHouseId
		WHERE ((@For = 0 AND tblProjects.WareHouseId IN (SELECT ID FROM Inv_Warehouse)) OR (tblProjects.WareHouseId = @For AND @For > 0))
		AND tblProjects.ShipDate BETWEEN @FromDate AND @ToDate
		ORDER BY [Fabrication Status],tblProjects.ShipDate
	END

	ELSE IF(@Operation = 2)
	BEGIN
		SELECT tblProjects.JobID AS [Job ID], tblCustomers.CompanyName AS [Customer],
		tblDealers.CompanyName AS Dealer, tblProjects.PONumber AS [PO #], 
		CONVERT(VARCHAR(10),tblProjects.ShipDate,101) AS [Ship Date Canada],
		Convert(VARCHAR(10), ShipDateFromChina, 101) AS [Ship Date China],
		CASE WHEN tblProjects.ShippingCommit = 'F' THEN 'Firm'
		WHEN tblProjects.ShippingCommit = 'T' THEN 'Tentative' END AS [Shipping Commit], 
		tblProjects.ContainerNo AS [Container No.],
		tblPFiles.NetEqPrice AS [Equipment Price],
		tblEmployees.FirstName AS [Project Manager],
		CASE WHEN tblProjects.[Status] = 1 THEN 'In Production Canada'
		WHEN tblProjects.[Status] = 2 THEN 'Shipped'
		When tblProjects.[Status] = 3 THEN 'Arrived'
		When tblProjects.[Status] = 4 THEN 'In Production China'
		WHEN tblProjects.[Status] = 5 THEN 'Completed'
		WHEN tblProjects.[Status] = 6 THEN 'In Process'
		WHEN tblProjects.[Status] = 7 THEN 'Submit For Review' END AS [Status],
		CONVERT(VARCHAR(10), ExpectedArrivalDatefromChina, 101) AS [Expected Arrival Date],
		Inv_Warehouse.WarehouseName AS FacilityName
		FROM tblPFiles
		INNER JOIN tblProjects ON tblProjects.ProposalID = tblPFiles.PNumber
		INNER JOIN tblDealers ON tblDealers.DealerID = tblPFiles.DealerID
		INNER JOIN tblCustomers ON tblCustomers.CustomerID = tblProjects.CustomerID
		INNER JOIN tblEmployees ON tblEmployees.EmployeeID = tblPFiles.projectmanagerid
		LEFT JOIN Inv_Warehouse ON Inv_Warehouse.ID = tblProjects.WareHouseId
		WHERE ((@For = 0 AND tblProjects.WareHouseId IN (SELECT ID FROM Inv_Warehouse)) OR (tblProjects.WareHouseId = @For AND @For > 0))
		AND tblProjects.ShipDate BETWEEN @FromDate AND @ToDate
		ORDER BY [Expected Arrival Date],tblProjects.ShipDate
	END

	ELSE IF(@Operation = 3)
	BEGIN
		SELECT ID, WarehouseName AS [text]
		FROM Inv_Warehouse
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Get_SalesUsaCanProduction]    Script Date: 11/01/2025 01:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_SalesUsaCanProduction]
    @FromDate DATE = NULL,
    @ToDate DATE = NULL,
	@Shopid INT,
	@IssuedFor CHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
	
	IF (@Shopid = 0)
	BEGIN
		SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
		qryNewProjects.PONumber,
		--   CASE WHEN qryNewProjects.ProjectDesignerID=1376 AND (qryNewProjects.ProjectDesignerChinaID = null OR qryNewProjects.ProjectDesignerChinaID=0 OR qryNewProjects.ProjectDesignerChinaID='') Then 'China'
		--WHEN qryNewProjects.ProjectDesignerID=1376 AND (qryNewProjects.ProjectDesignerChinaID != null  OR qryNewProjects.ProjectDesignerChinaID != 0 OR qryNewProjects.ProjectDesignerChinaID != '') THEN
		--tblEMPChina.FirstName
		--WHEN (qryNewProjects.ProjectDesignerID = NULL OR qryNewProjects.ProjectDesignerID=0 OR qryNewProjects.ProjectDesignerID='')
		--AND (qryNewProjects.ProjectDesignerChinaID != null OR  qryNewProjects.ProjectDesignerChinaID != 0 OR qryNewProjects.ProjectDesignerChinaID != '')
		--THEN tblEMPChina.FirstName
		--ELSE qryAeroDesigners.FirstName
		--END as Name,
		COALESCE((
			SELECT TOP 1 E.FirstName
			--SELECT TOP 1 isnull(E.Abbrivation,'')
			FROM tblProjects_FabricationCanada FC
			INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
			WHERE FC.JobId = qryNewProjects.JobID AND ISNULL(FC.IsDeleted, 0) = 0
			ORDER BY FC.Id DESC
			), 
		CASE
		-- Case 1: Designer = 1376 and ChinaDesigner is NULL/0/empty
		WHEN qryNewProjects.ProjectDesignerID = 1376
			 AND (qryNewProjects.ProjectDesignerChinaID IS NULL 
				  OR qryNewProjects.ProjectDesignerChinaID = 0 
				  OR qryNewProjects.ProjectDesignerChinaID = '') 
		THEN 'China'

		-- Case 2: Designer = 1376 and ChinaDesigner is set
		WHEN qryNewProjects.ProjectDesignerID = 1376
			 AND (qryNewProjects.ProjectDesignerChinaID IS NOT NULL 
				  AND qryNewProjects.ProjectDesignerChinaID <> 0 
				  AND qryNewProjects.ProjectDesignerChinaID <> '') 
		THEN CONCAT(
				tblEMPChina.Abbrivation,
				CASE 
					WHEN tblCorrectedBy.Abbrivation IS NOT NULL 
					THEN CONCAT(' / ', tblCorrectedBy.Abbrivation)
					ELSE ''
				END
			 )

		-- Case 3: Designer is NULL/0/empty, but ChinaDesigner exists
		WHEN (qryNewProjects.ProjectDesignerID IS NULL 
			  OR qryNewProjects.ProjectDesignerID = 0 
			  OR qryNewProjects.ProjectDesignerID = '') 
			 AND (qryNewProjects.ProjectDesignerChinaID IS NOT NULL 
				  AND qryNewProjects.ProjectDesignerChinaID <> 0 
				  AND qryNewProjects.ProjectDesignerChinaID <> '') 
		THEN CONCAT(
				tblEMPChina.Abbrivation,
				CASE 
					WHEN tblCorrectedBy.Abbrivation IS NOT NULL 
					THEN CONCAT(' / ', tblCorrectedBy.Abbrivation)
					ELSE ''
				END
			 )

		-- Default: Use AeroDesigners
		ELSE 
			qryAeroDesigners.Abbrivation					
		END ) AS [Name],
		qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
		qryNewProjects.ShipToArriveDate, qryNewProjects.ShipDate,qryNewProjects.JobOrderAck as OrderAckDate,
		CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
		CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
		WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
		WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
		WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
		WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
		END AS ShippingCommit,
		CASE WHEN (qryShpdrgsSales.MaxsDateReleasedToFab IS NOT NULL) THEN qryShpdrgsSales.MaxsDateReleasedToFab
		WHEN (qryShpdrgsSales.MaxsDateReleasedToFab IS NULL AND qryShpdrgsSales.MAXsReleasedToShopDate IS NULL)
		THEN qryShpdrgsSales.MAXsReleasedToFabDate END
		AS MaxsDateReleasedToFab,
		qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
		CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
		ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
		qryNewProjects.FabSentToCanada,
		qryNewProjects.ReleaseDate AS RD,
		(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
		COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop) AS ReleasedToShop,
		--qryNewProjects.ReleasedToShop, 
		(DateDiff("d", COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop),
		[qrynewprojects].[ShipDate])) AS LeadNest, 
		--(DateDiff("d", [qrynewprojects].[ReleasedToShop], [qrynewprojects].[ShipDate])) AS LeadNest, 
		[tblEmployees_1].[FirstName] AS Reviewed, 
		tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
		CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
		qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName, DATEADD(dd, 1, [qrynewprojects].[ShipDate]) AS gshipdate,
		(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
		qryNewProjects.PORec, CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production'
		WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
		WHEN qryNewProjects.[Status]=3 THEN 'Arrived'
		WHEN qryNewProjects.[Status]=4 THEN 'Ready to Ship'
		WHEN qryNewProjects.[Status]=5 THEN 'Completed'
		WHEN qryNewProjects.[Status]=8 THEN 'Review to India'
		ELSE ''
		END AS [Status], 
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.'
		END AS PurchasedItemsCAD, qryNewProjects.ShipDate AS ShipDate_Col,
		qryShpdrgsSales.MaxsReleasedTo AS sReleasedTo,
		Case When qryNewProjects.CorrectedBy IS Not NULL Then 
		CONCAT(tblEMPChina.Abbrivation + 
		'/' , tblCorrectedBy.Abbrivation)
		END AS CorrectedBy,
		(SELECT TOP 1 CONVERT(VARCHAR(10), sReleasedToFabDate, 101) AS sReleasedToFabDate FROM tblShpDrgs
			WHERE tblShpDrgs.sDrgJID = qryNewProjects.JobID AND ISNULL(sReleasedToFabDate, '') <> ''
			ORDER BY sReleasedToFabDate DESC
		) AS sReleasedToFabDate,
		(SELECT TOP 1 Convert(VARCHAR(10), sReleasedToShopDate, 101) AS sReleasedToShopDate FROM tblShpDrgs
			WHERE tblShpDrgs.sDrgJID = qryNewProjects.JobID AND ISNULL(sReleasedToShopDate, '') <> ''
			ORDER BY sReleasedToFabDate DESC
		) AS sReleasedToShopDate
		FROM Inv_Warehouse 
		RIGHT JOIN tblHobartBranchListing 
		INNER JOIN qryShpDrgsSales 
		RIGHT JOIN qryAeroDesigners 
		RIGHT JOIN tblStates 
		RIGHT JOIN tblCustomers 
		RIGHT JOIN tblDealers 
		RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
		ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
		LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
		LEFT JOIN tblEmployees as tblEMPChina ON tblEMPChina.EmployeeID=qryNewProjects.ProjectDesignerChinaID
		LEFT JOIN tblEmployees as tblCorrectedBy ON tblCorrectedBy.EmployeeID=qryNewProjects.CorrectedBy
		LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID		
		INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
		ON Inv_Warehouse.ID = qryNewProjects.WareHouseId
		WHERE qryNewProjects.ShipDate Between @FromDate And @ToDate AND ((qryNewProjects.CurrencyID=1) 
		Or qryNewProjects.CurrencyID=2)
		ORDER BY qryNewProjects.ShipDate,NJobID
	END

	ELSE IF (@Shopid = 2)
	BEGIN
		IF(@IssuedFor = 'B')
		BEGIN
			SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
			qryNewProjects.PONumber, CASE WHEN ISNULL(tblEmployees_2.FirstName, '') = '' THEN (
						SELECT TOP 1 CONCAT(E.FirstName, ' ' + E.LastName)
						FROM tblProjects_FabricationCanada FC
						INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
						WHERE FC.JobId = qryNewProjects.JobID AND ISNULL(FC.IsDeleted, 0) = 0
						ORDER BY FC.Id DESC
					)ELSE tblEmployees_2.FirstName END as Name, qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
			qryNewProjects.ShipToArriveDate, qryNewProjects.JobOrderAck as OrderAckDate,
			CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
			CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
			WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
			WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
			WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
			WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
			END AS ShippingCommit,
			qryShpdrgsSales.MaxsDateReleasedToFab,
			qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
			CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
			ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
			qryNewProjects.FabSentToCanada,
			qryNewProjects.ReleaseDate AS RD,
			(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
			COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop) AS ReleasedToShop,
			--qryNewProjects.ReleasedToShop, 
			(DateDiff("d", COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop),
			[qrynewprojects].[ShipDate])) AS LeadNest, 
			--(DateDiff("d", [qrynewprojects].[ReleasedToShop], [qrynewprojects].[ShipDate])) AS LeadNest, 
			[tblEmployees_1].[FirstName] AS Reviewed, 
			tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
			CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
			qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName,dateadd(dd,1,[qrynewprojects].[ShipDate])  as gshipdate,
			(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
			qryNewProjects.PORec,
			--CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production'
			--WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
			--WHEN qryNewProjects.[Status]=3 THEN 'Arrived'
			--WHEN qryNewProjects.[Status]=4 THEN 'Ready to Ship'
			--WHEN qryNewProjects.[Status]=5 THEN 'Completed'
			--ELSE 'Not Started'
			CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production Canada'
			WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
			When qryNewProjects.[Status]=3 THEN 'Arrived'
			When qryNewProjects.[Status]=4 THEN 'In Production China'
			WHEN qryNewProjects.[Status]=5 THEN 'Completed'
			WHEN qryNewProjects.[Status]=6 THEN 'In Process'
			WHEN qryNewProjects.[Status]=7 THEN 'Submit For Review'

			END AS [Status],qryNewProjects.[Status] AS [StatusID],
			FORMAT (qryNewProjects.ExpectedArrivalDatefromChina, 'MM/dd/yyyy') AS ExpectedArrivalDatefromChina, 

			--CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
			--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
			--WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
			--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,

			CASE WHEN qryNewProjects.Issued='D' THEN 'Drawings'
			WHEN qryNewProjects.Issued='P' THEN 'Production'
			WHEN qryNewProjects.Issued='B' THEN 'Drawings and Production'
			END AS PurchasedItems,

			CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
			WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' 
			END AS PurchasedItemsCAD, 
		
			--qryNewProjects.ReleaseDateChina AS ShipDate, 
			qryNewProjects.ShipDate AS ShipDate, 
			qryNewProjects.ReleaseDateChina, qryNewProjects.ShipDate AS ShipDate_Col,
			qryShpdrgsSales.MaxsReleasedTo AS sReleasedTo,
			Case When qryNewProjects.CorrectedBy IS Not NULL Then tblEmployees_2.Abbrivation + 
			'/' + tblCorrectedBy.Abbrivation		
			END AS CorrectedBy
			--,qryNewProjects.ShipDate
			FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
			RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
			ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
			LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
			LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
			LEFT JOIN tblEmployees AS tblEmployees_2 ON qryNewProjects.ProjectDesignerChinaID = tblEmployees_2.EmployeeID 
			LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID
			LEFT JOIN tblEmployees as tblCorrectedBy ON tblCorrectedBy.EmployeeID=qryNewProjects.CorrectedBy
			INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
			ON Inv_Warehouse.ID = qryNewProjects.WareHouseId					
			WHERE 
			--tblMfgFacility.ID=@Shopid AND 
			qryNewProjects.ReleaseDateChina Between @FromDate And @ToDate 
			--AND ((qryNewProjects.CurrencyID=1) Or qryNewProjects.CurrencyID=2) 
			--AND ((qryNewProjects.ProjectDesignerID=1376) OR qryAeroDesigners.EmployeeID IN (339,338))
			AND qryNewProjects.ProjectDesignerID=1376
			AND qryNewProjects.Issued IN ('D','B','P')
			ORDER BY qryNewProjects.ReleaseDateChina,NJobID
		END

		ELSE IF(@IssuedFor = 'P')
		BEGIN
			SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
			qryNewProjects.PONumber, CASE WHEN ISNULL(tblEmployees_2.FirstName, '') = '' THEN (
						SELECT TOP 1 CONCAT(E.FirstName, ' ' + E.LastName)
						FROM tblProjects_FabricationCanada FC
						INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
						WHERE FC.JobId = qryNewProjects.JobID AND ISNULL(FC.IsDeleted, 0) = 0
						ORDER BY FC.Id DESC
					)ELSE tblEmployees_2.FirstName END as Name, qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
			qryNewProjects.ShipToArriveDate, qryNewProjects.JobOrderAck as OrderAckDate,
			CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
			CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
			WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
			WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
			WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
			WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
			END AS ShippingCommit,
			qryShpdrgsSales.MaxsDateReleasedToFab,
			qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
			CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
			ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
			qryNewProjects.FabSentToCanada,
			qryNewProjects.ReleaseDate AS RD,
			(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
			COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop) AS ReleasedToShop,
			--qryNewProjects.ReleasedToShop, 
			(DateDiff("d", COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop),
			[qrynewprojects].[ShipDate])) AS LeadNest, 
			--(DateDiff("d", [qrynewprojects].[ReleasedToShop], [qrynewprojects].[ShipDate])) AS LeadNest, 
			[tblEmployees_1].[FirstName] AS Reviewed, 
			tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
			CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
			qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName,dateadd(dd,1,[qrynewprojects].[ShipDate])  as gshipdate,
			(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
			qryNewProjects.PORec,
			CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production Canada'
			WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
			When qryNewProjects.[Status]=3 THEN 'Arrived'
			When qryNewProjects.[Status]=4 THEN 'In Production China'
			WHEN qryNewProjects.[Status]=5 THEN 'Completed'
			WHEN qryNewProjects.[Status]=6 THEN 'In Process'
			WHEN qryNewProjects.[Status]=7 THEN 'Submit For Review'
			END AS [Status],qryNewProjects.[Status] AS [StatusID],
			FORMAT (qryNewProjects.ExpectedArrivalDatefromChina, 'MM/dd/yyyy') AS ExpectedArrivalDatefromChina, 

			--CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
			--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
			--WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
			--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,

			CASE WHEN qryNewProjects.Issued='D' THEN 'Drawings'
			WHEN qryNewProjects.Issued='P' THEN 'Production'
			WHEN qryNewProjects.Issued='B' THEN 'Drawings and Production'
			END AS PurchasedItems,

			CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
			WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' 
			END AS PurchasedItemsCAD, 
		
			--qryNewProjects.ReleaseDateChina AS ShipDate, 
			qryNewProjects.ReleaseDateChina, qryNewProjects.ShipDate AS ShipDate_Col
			,qryNewProjects.ShipDate,qryShpdrgsSales.MaxsReleasedTo AS sReleasedTo,
			Case When qryNewProjects.CorrectedBy IS Not NULL Then tblEmployees_2.Abbrivation + 
			'/' + tblCorrectedBy.Abbrivation		
			END AS CorrectedBy
			FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
			RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
			ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
			LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
			LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
			LEFT JOIN tblEmployees AS tblEmployees_2 ON qryNewProjects.ProjectDesignerChinaID = tblEmployees_2.EmployeeID 
			LEFT JOIN tblEmployees as tblCorrectedBy ON tblCorrectedBy.EmployeeID=qryNewProjects.CorrectedBy
			LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID 
			INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
			ON Inv_Warehouse.ID = qryNewProjects.WareHouseId
				
			WHERE 
			--tblMfgFacility.ID=@Shopid AND 
			qryNewProjects.ReleaseDateChina Between @FromDate And @ToDate 
			--AND ((qryNewProjects.CurrencyID=1) Or qryNewProjects.CurrencyID=2) 
			--AND ((qryNewProjects.ProjectDesignerID=1376) OR qryAeroDesigners.EmployeeID IN (339,338))
			AND qryNewProjects.ProjectDesignerID=1376
			AND qryNewProjects.Issued IN ('B','P')
			ORDER BY qryNewProjects.ReleaseDateChina,NJobID
		END

		ELSE
		BEGIN
			SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
			qryNewProjects.PONumber, (
				SELECT TOP 1 CONCAT(E.FirstName, ' ' + E.LastName)
				FROM tblProjects_FabricationCanada FC
				INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
				WHERE FC.JobId = qryNewProjects.JobID
				ORDER BY FC.Id DESC
			) as Name, qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
			qryNewProjects.ShipToArriveDate, qryNewProjects.JobOrderAck as OrderAckDate,
			CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
			CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
			WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
			WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
			WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
			WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
			END AS ShippingCommit,
			qryShpdrgsSales.MaxsDateReleasedToFab,
			qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
			CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
			ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
			qryNewProjects.FabSentToCanada,
			qryNewProjects.ReleaseDate AS RD,
			(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
			qryNewProjects.ReleasedToShop, (DateDiff("d",[qrynewprojects].[ReleasedToShop],[qrynewprojects].[ShipDate])) AS LeadNest, 
			[tblEmployees_1].[FirstName] AS Reviewed, 
			tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
			CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
			qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName,dateadd(dd,1,[qrynewprojects].[ShipDate])  as gshipdate,
			(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
			qryNewProjects.PORec,
			CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production Canada'
			WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
			When qryNewProjects.[Status]=3 THEN 'Arrived'
			When qryNewProjects.[Status]=4 THEN 'In Production China'
			WHEN qryNewProjects.[Status]=5 THEN 'Completed'
			WHEN qryNewProjects.[Status]=6 THEN 'In Process'
			WHEN qryNewProjects.[Status]=7 THEN 'Submit For Review'
			END AS [Status],qryNewProjects.[Status] AS [StatusID],
			FORMAT (qryNewProjects.ExpectedArrivalDatefromChina, 'MM/dd/yyyy') AS ExpectedArrivalDatefromChina, 

			--CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
			--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
			--WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
			--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,

			CASE WHEN qryNewProjects.Issued='D' THEN 'Drawings'
			WHEN qryNewProjects.Issued='P' THEN 'Production'
			WHEN qryNewProjects.Issued='B' THEN 'Drawings and Production'
			END AS PurchasedItems,

			CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
			WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' 
			END AS PurchasedItemsCAD, 
		
			--qryNewProjects.ReleaseDateChina AS ShipDate, 
			qryNewProjects.ReleaseDateChina, qryNewProjects.ShipDate AS ShipDate_Col
			,qryNewProjects.ShipDate,
			qryShpdrgsSales.MaxsReleasedTo AS sReleasedTo,
			Case When qryNewProjects.CorrectedBy IS Not NULL Then tblEmployees_2.Abbrivation + 
			'/' + tblCorrectedBy.Abbrivation		
			END AS CorrectedBy
			FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
			RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
			ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
			LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
			LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
			LEFT JOIN tblEmployees as tblCorrectedBy ON tblCorrectedBy.EmployeeID=qryNewProjects.CorrectedBy
			LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID 
			LEFT JOIN tblEmployees as tblEmployees_2 ON tblEmployees_2.EmployeeID = qryNewProjects.ProjectDesignerChinaID 
			INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
			ON Inv_Warehouse.ID = qryNewProjects.WareHouseId		
			WHERE 
			--tblMfgFacility.ID=@Shopid AND 
			qryNewProjects.ReleaseDateChina Between @FromDate And @ToDate 
			--AND ((qryNewProjects.CurrencyID=1) Or qryNewProjects.CurrencyID=2) 
			--AND ((qryNewProjects.ProjectDesignerID=1376) OR qryAeroDesigners.EmployeeID IN (339,338))
			AND qryNewProjects.ProjectDesignerID=1376
			ORDER BY qryNewProjects.ReleaseDateChina,NJobID
		END		
	END

	ELSE
	BEGIN
		SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
		qryNewProjects.PONumber, (
				SELECT TOP 1 CONCAT(E.FirstName, ' ' + E.LastName)
				FROM tblProjects_FabricationCanada FC
				INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
				WHERE FC.JobId = qryNewProjects.JobID
				ORDER BY FC.Id DESC
			) as Name, qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
		qryNewProjects.ShipToArriveDate, qryNewProjects.ShipDate,qryNewProjects.JobOrderAck as OrderAckDate,
		CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
		CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
		WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
		WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
		WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
		WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
		END AS ShippingCommit,
		qryShpdrgsSales.MaxsDateReleasedToFab,
		qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
		CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
		ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
		qryNewProjects.FabSentToCanada,
		qryNewProjects.ReleaseDate AS RD,
		(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
		qryNewProjects.ReleasedToShop, (DateDiff("d",[qrynewprojects].[ReleasedToShop],[qrynewprojects].[ShipDate])) AS LeadNest, 
		[tblEmployees_1].[FirstName] AS Reviewed, 
		tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
		CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
		qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName,dateadd(dd,1,[qrynewprojects].[ShipDate])  as gshipdate,
		(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
		qryNewProjects.PORec,		
		CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production Canada'
		WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
		When qryNewProjects.[Status]=3 THEN 'Arrived'
		When qryNewProjects.[Status]=4 THEN 'In Production China'
		WHEN qryNewProjects.[Status]=5 THEN 'Completed'
		WHEN qryNewProjects.[Status]=6 THEN 'In Process'
		WHEN qryNewProjects.[Status]=7 THEN 'Submit For Review'
		END AS [Status],qryNewProjects.[Status] AS [StatusID],
		FORMAT (qryNewProjects.ExpectedArrivalDatefromChina, 'MM/dd/yyyy') AS ExpectedArrivalDatefromChina, 
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' 
		END AS PurchasedItemsCAD, qryNewProjects.ShipDate AS ShipDate_Col,
		qryNewProjects.ShipDate AS ReleaseDateChina,
		qryShpdrgsSales.MaxsReleasedTo AS sReleasedTo,
		Case When qryNewProjects.CorrectedBy IS Not NULL THEN tblEmployees_2.Abbrivation + 
		'/' + tblCorrectedBy.Abbrivation		
		END AS CorrectedBy
		FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
		RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
		ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
		LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
		LEFT JOIN tblEmployees as tblCorrectedBy ON tblCorrectedBy.EmployeeID=qryNewProjects.CorrectedBy
		LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID 
		INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
		ON Inv_Warehouse.ID = qryNewProjects.WareHouseId
		LEFT JOIN tblEmployees AS tblEmployees_2 ON tblEmployees_2.EmployeeID = qryNewProjects.ProjectDesignerChinaID 
		WHERE 
		Inv_Warehouse.ID = @Shopid AND 
		qryNewProjects.ShipDate BETWEEN @FromDate AND @ToDate 
		AND ((qryNewProjects.CurrencyID = 1) OR qryNewProjects.CurrencyID = 2) 		
		ORDER BY qryNewProjects.ShipDate, NJobID		
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Get_SalesWeekly]    Script Date: 11/01/2025 01:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [Get_SalesWeekly] '11/01/2024','11/07/2024',0
CREATE PROCEDURE [dbo].[Get_SalesWeekly] 
	 @FromDate DATE = NULL,
     @ToDate DATE = NULL,
	 @Shopid INT
AS
BEGIN
	SET NOCOUNT ON;

   	IF(@Shopid = 0)
	BEGIN
		SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
		qryNewProjects.PONumber, qryNewProjects.ProjectDesignerID,qryNewProjects.ProjectDesignerChinaID,	   
	   COALESCE((
			SELECT TOP 1 E.FirstName
			--SELECT TOP 1 isnull(E.Abbrivation,'')
			FROM tblProjects_FabricationCanada FC
			INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
			WHERE FC.JobId = qryNewProjects.JobID AND ISNULL(FC.IsDeleted, 0) = 0
			ORDER BY FC.Id DESC
			), CASE WHEN qryNewProjects.ProjectDesignerID=1376 AND (qryNewProjects.ProjectDesignerChinaID = null OR qryNewProjects.ProjectDesignerChinaID=0 OR qryNewProjects.ProjectDesignerChinaID='') Then 'China'
		WHEN qryNewProjects.ProjectDesignerID=1376 AND (qryNewProjects.ProjectDesignerChinaID != null  OR qryNewProjects.ProjectDesignerChinaID != 0 OR qryNewProjects.ProjectDesignerChinaID != '') THEN
		tblEMPChina.FirstName
		WHEN (qryNewProjects.ProjectDesignerID = NULL OR qryNewProjects.ProjectDesignerID=0 OR qryNewProjects.ProjectDesignerID='')
		AND (qryNewProjects.ProjectDesignerChinaID != null OR  qryNewProjects.ProjectDesignerChinaID != 0 OR qryNewProjects.ProjectDesignerChinaID != '')
		THEN tblEMPChina.FirstName
		ELSE qryAeroDesigners.FirstName
		END) as Name, 
		qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
		qryNewProjects.ShipToArriveDate, qryNewProjects.ShipDate,qryNewProjects.JobOrderAck as OrderAckDate,
		CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
		CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
		WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
		WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
		WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
		WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
		END AS ShippingCommit,
		qryShpdrgsSales.MaxsDateReleasedToFab,
		qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
		CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
		ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
		qryNewProjects.FabSentToCanada,
		qryNewProjects.ReleaseDate AS RD,
		(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
		COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop) AS ReleasedToShop,
		--qryNewProjects.ReleasedToShop, 
		(DateDiff("d", COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop),
		[qrynewprojects].[ShipDate])) AS LeadNest, 
		--(DateDiff("d", [qrynewprojects].[ReleasedToShop], [qrynewprojects].[ShipDate])) AS LeadNest, 
		[tblEmployees_1].[FirstName] AS Reviewed, 
		tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
		CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
		qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName,dateadd(dd,1,[qrynewprojects].[ShipDate])  as gshipdate,
		(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
		qryNewProjects.PORec, CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production'
		WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
		WHEN qryNewProjects.[Status]=3 THEN 'Arrived'
		WHEN qryNewProjects.[Status]=4 THEN 'Ready to Ship'
		WHEN qryNewProjects.[Status]=5 THEN 'Completed'
		ELSE ''
		END AS [Status], 
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.'
		END AS PurchasedItemsCAD, qryNewProjects.ShipDate AS ShipDate_Col,qryNewProjects.filepath,
		CASE WHEN qryNewProjects.filepath IS NULL THEN '0' ELSE '1' END AS PlanView, 
		CASE WHEN (SELECT COUNT(*) FROM Inv_AWProduct_Projects WHERE JobID = qryNewProjects.JobId) > 0 THEN 1 ELSE 0 END AS JobModelParts 
		FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
		RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
		ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
		LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
		LEFT JOIN tblEmployees as tblEMPChina ON tblEMPChina.EmployeeID=qryNewProjects.ProjectDesignerChinaID
		LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID 
		INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
		ON Inv_Warehouse.ID = qryNewProjects.WareHouseId		
		WHERE qryNewProjects.ShipDate Between @FromDate And @ToDate AND ((qryNewProjects.CurrencyID=1) 
		Or qryNewProjects.CurrencyID=2)
		ORDER BY qryNewProjects.ShipDate,NJobID
	END

	ELSE IF(@Shopid = 2)
	BEGIN
		SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
		qryNewProjects.PONumber, CASE WHEN ISNULL(tblEmployees_2.FirstName, '') = '' THEN (
						SELECT TOP 1 CONCAT(E.FirstName, ' ' + E.LastName)
						FROM tblProjects_FabricationCanada FC
						INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
						WHERE FC.JobId = qryNewProjects.JobID AND ISNULL(FC.IsDeleted, 0) = 0
						ORDER BY FC.Id DESC
					)ELSE tblEmployees_2.FirstName END as Name, qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
		qryNewProjects.ShipToArriveDate, qryNewProjects.JobOrderAck as OrderAckDate,
		CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
		CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
		WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
		WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
		WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
		WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
		END AS ShippingCommit,
		qryShpdrgsSales.MaxsDateReleasedToFab,
		qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
		CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
		ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
		qryNewProjects.FabSentToCanada,
		qryNewProjects.ReleaseDate AS RD,
		(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
		COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop) AS ReleasedToShop,
		--qryNewProjects.ReleasedToShop, 
		(DateDiff("d", COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop),
		[qrynewprojects].[ShipDate])) AS LeadNest, 
		--(DateDiff("d", [qrynewprojects].[ReleasedToShop], [qrynewprojects].[ShipDate])) AS LeadNest, 
		[tblEmployees_1].[FirstName] AS Reviewed, 
		tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
		CASE WHEN Inv_Warehouse.WarehouseName IS NULL THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
		qryNewProjects.FirstName as ProjecctManager, qryNewProjects.ModelName, dateadd(dd,1,[qrynewprojects].[ShipDate]) as gshipdate,
		(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
		qryNewProjects.PORec,
		CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production'
		WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
		WHEN qryNewProjects.[Status]=3 THEN 'Arrived'
		WHEN qryNewProjects.[Status]=4 THEN 'Ready to Ship'
		WHEN qryNewProjects.[Status]=5 THEN 'Completed'
		ELSE 'Not Started'
		END AS [Status],qryNewProjects.[Status] AS [StatusID],
		FORMAT (qryNewProjects.ExpectedArrivalDatefromChina, 'MM/dd/yyyy') AS ExpectedArrivalDatefromChina, 

		--CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
		--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
		--WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		--WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,

		CASE WHEN qryNewProjects.Issued='D' THEN 'Drawings'
		WHEN qryNewProjects.Issued='P' THEN 'Production'
		WHEN qryNewProjects.Issued='B' THEN 'Drawings and Production'
		END AS PurchasedItems,

		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' 
		END AS PurchasedItemsCAD, 
		
		qryNewProjects.ShipDate AS ShipDate, qryNewProjects.ReleaseDateChina, qryNewProjects.ShipDate AS ShipDate_Col
		,qryNewProjects.filepath,
		CASE WHEN qryNewProjects.filepath IS NULL THEN '0' ELSE '1' END AS PlanView,
		CASE WHEN (SELECT COUNT(*) FROM Inv_AWProduct_Projects WHERE JobID = qryNewProjects.JobId) > 0 THEN 1 ELSE 0 END AS JobModelParts
		--,qryNewProjects.ShipDate
		FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
		RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
		ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
		LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_2 ON qryNewProjects.ProjectDesignerChinaID = tblEmployees_2.EmployeeID 
		LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID 
		INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
		ON Inv_Warehouse.ID = qryNewProjects.WareHouseId
		WHERE 
		--tblMfgFacility.ID=@Shopid AND 
		qryNewProjects.ShipDate Between @FromDate And @ToDate 
		AND ((qryNewProjects.CurrencyID = 1) Or qryNewProjects.CurrencyID = 2) 
		AND ((qryNewProjects.WareHouseId = 2) OR qryAeroDesigners.EmployeeID IN (339, 338))
		
		ORDER BY qryNewProjects.ReleaseDateChina,NJobID

	END
	ELSE
	BEGIN
		SELECT DISTINCT ISNULL(tblCustomers.CompanyName,'') +', '+ ISNULL(tblCustomers.City,'') +', '+ ISNULL(tblStates.State,'') AS Customer, tblDealers.CompanyName AS Dealer ,
		qryNewProjects.PONumber, CASE WHEN ISNULL(tblEmployees_2.FirstName, '') = '' THEN (
						SELECT TOP 1 CONCAT(E.FirstName, ' ' + E.LastName)
						FROM tblProjects_FabricationCanada FC
						INNER JOIN tblEmployees E ON E.EmployeeID = FC.ProjectDesigner
						WHERE FC.JobId = qryNewProjects.JobID AND ISNULL(FC.IsDeleted, 0) = 0
						ORDER BY FC.Id DESC
					)ELSE tblEmployees_2.FirstName END as Name, qryNewProjects.NetEqPrice,CASE WHEN Currencyid=2 THEN NetEqPrice END AS USA, CASE WHEN Currencyid=1 THEN NetEqPrice END AS Canadian, 
		qryNewProjects.ShipToArriveDate, qryNewProjects.ShipDate,qryNewProjects.JobOrderAck as OrderAckDate,
		CASE WHEN qryShpdrgsSales.MaxshpDrgAppDate IS NULL THEN qryNewProjects.JobId + '*' ELSE qryNewProjects.JobId END AS NJobID,
		CASE WHEN qryNewProjects.ShippingCommit IS NULL THEN '' WHEN qryNewProjects.ShippingCommit='F' THEN 'Firm' 
		WHEN qryNewProjects.ShippingCommit='T' THEN 'Tentative' 
		WHEN qryNewProjects.ShippingCommit='W' THEN 'Window' 
		WHEN qryNewProjects.ShippingCommit='H' THEN 'Warehouse' 
		WHEN qryNewProjects.ShippingCommit='S' THEN 'Ship when ready' 
		END AS ShippingCommit,
		qryShpdrgsSales.MaxsDateReleasedToFab,
		qryNewProjects.NetEqPrice, qryNewProjects.CurrencyID, qryNewProjects.RepID, 
		CASE WHEN qryNewProjects.ReleaseDate IS NULL THEN qryNewProjects.FabSentToCanada
		ELSE qryNewProjects.ReleaseDate END AS ReleaseDate,
		qryNewProjects.FabSentToCanada,
		qryNewProjects.ReleaseDate AS RD,
		(DateDiff("d",[qrynewprojects].[ReleaseDate],[qrynewprojects].[ShipDate])) AS Lead, 
		COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop) AS ReleasedToShop,
		--qryNewProjects.ReleasedToShop, 
		(DateDiff("d", COALESCE((SELECT TOP 1 tblProjects_Nesting.SentDate FROM tblProjects_Nesting WHERE tblProjects_Nesting.JobId = qryNewProjects.JobID ORDER BY tblProjects_Nesting.SentDate DESC), qryNewProjects.ReleasedToShop),
		[qrynewprojects].[ShipDate])) AS LeadNest, 
		--(DateDiff("d", [qrynewprojects].[ReleasedToShop], [qrynewprojects].[ShipDate])) AS LeadNest, 
		[tblEmployees_1].[FirstName] AS Reviewed, 
		tblConveyorModel.ModelName, qryShpDrgsSales.MaxShpDrgSentHO, qryShpDrgsSales.MaxShpDrgAppDate, 
		CASE WHEN Inv_Warehouse.WarehouseName Is Null THEN 'Canada' ELSE Inv_Warehouse.WarehouseName END AS FacilityName, Inv_Warehouse.ID AS FacilityID,
		qryNewProjects.FirstName as ProjecctManager,qryNewProjects.ModelName,dateadd(dd,1,[qrynewprojects].[ShipDate])  as gshipdate,
		(select [dbo].[ModalOfJob] (qryNewProjects.JobId)) AS NEWMODEL,
		qryNewProjects.PORec,
		CASE WHEN qryNewProjects.[Status]=1 THEN 'In Production'
		WHEN qryNewProjects.[Status]=2 THEN 'Shipped'
		WHEN qryNewProjects.[Status]=3 THEN 'Arrived'
		WHEN qryNewProjects.[Status]=4 THEN 'Ready to Ship'
		WHEN qryNewProjects.[Status]=5 THEN 'Completed'
		ELSE 'Not Started'
		END AS [Status],qryNewProjects.[Status] AS [StatusID],
		FORMAT (qryNewProjects.ExpectedArrivalDatefromChina, 'MM/dd/yyyy') AS ExpectedArrivalDatefromChina, 
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'O' THEN 'Ordered'
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' AND qryNewProjects.PurchasedItems = 'R' THEN 'Received' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' END AS PurchasedItems,
		CASE WHEN qryNewProjects.PurchasedItemsCAD = 'N' THEN 'Not Req.' 
		WHEN qryNewProjects.PurchasedItemsCAD = 'Y' THEN 'Req.' 
		END AS PurchasedItemsCAD, qryNewProjects.ShipDate AS ShipDate_Col,qryNewProjects.filepath,
		CASE WHEN qryNewProjects.filepath IS NULL THEN '0' ELSE '1' END AS PlanView,
		CASE WHEN (SELECT COUNT(*) FROM Inv_AWProduct_Projects WHERE JobID = qryNewProjects.JobId) > 0 THEN 1 ELSE 0 END AS JobModelParts
		FROM Inv_Warehouse RIGHT JOIN tblHobartBranchListing INNER JOIN qryShpDrgsSales RIGHT JOIN qryAeroDesigners 
		RIGHT JOIN tblStates RIGHT JOIN tblCustomers RIGHT JOIN tblDealers RIGHT JOIN qryNewProjects ON tblDealers.DealerID = qryNewProjects.DealerID 
		ON tblCustomers.CustomerID = qryNewProjects.CustomerID ON tblStates.StateID = tblCustomers.StateID ON qryAeroDesigners.EmployeeID = qryNewProjects.ProjectDesignerID 
		LEFT JOIN tblEmployees ON qryAeroDesigners.EmployeeID = tblEmployees.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_1 ON qryNewProjects.ReviewedBy = tblEmployees_1.EmployeeID 
		LEFT JOIN tblEmployees AS tblEmployees_2 ON qryNewProjects.ProjectDesignerChinaID = tblEmployees_2.EmployeeID 
		LEFT JOIN tblConveyorModel ON qryNewProjects.ModelID = tblConveyorModel.ModelID ON qryShpDrgsSales.sDrgJid = qryNewProjects.JobID 
		INNER JOIN tblHobartListing ON qryNewProjects.RepID = tblHobartListing.RepID ON tblHobartBranchListing.BranchID = tblHobartListing.BranchID 
		ON Inv_Warehouse.ID = qryNewProjects.WareHouseId
		WHERE 
		Inv_Warehouse.ID=@Shopid AND 
		qryNewProjects.ShipDate BETWEEN @FromDate AND @ToDate 
		AND ((qryNewProjects.CurrencyID = 1) OR qryNewProjects.CurrencyID = 2) 		
		ORDER BY qryNewProjects.ShipDate,NJobID
	END
END
GO
