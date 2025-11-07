ALTER PROCEDURE [dbo].[EmailReminder] 
	-- Add the parameters for the stored procedure here
	@Operation		int=NULL,
	@msg			Varchar(50)='' output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @CurrentDate as Date=NULL
	DECLARE @EmailSentDateIndia as Date=NULL
	DECLARE @EmailSentDateChina as Date=NULL

	DECLARE @GetDateIndiaAfter30Days as Date=NULL
	DECLARE @GetDateChinaAfter30Days as Date=NULL	

	SET @EmailSentDateIndia=(SELECT TOP 1 EmailSentDate FROM Inv_PurchaseOrderDetail_Manual
	INNER JOIN Inv_PurchaseOrder_Manual ON Inv_PurchaseOrder_Manual.Id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
	WHERE SourceId=1 AND (EmailSent IS NOT NULL)
	ORDER BY EmailSentDate DESC)

	SET @EmailSentDateChina=(SELECT TOP 1 EmailSentDate FROM Inv_PurchaseOrderDetail_Manual
	INNER JOIN Inv_PurchaseOrder_Manual ON Inv_PurchaseOrder_Manual.Id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
	WHERE SourceId=2 AND (EmailSent IS NOT NULL)
	ORDER BY EmailSentDate DESC)


	SET @GetDateIndiaAfter30Days=DATEADD(DAY, 30, @EmailSentDateIndia)
	SET @GetDateChinaAfter30Days=DATEADD(DAY, 30, @EmailSentDateChina)	

	SET @CurrentDate=GETDATE()

	IF(@Operation=1)
	BEGIN

		IF(@CurrentDate >= @GetDateIndiaAfter30Days)
		BEGIN
			SET @msg= '1'
		END
		ELSE
		BEGIN
			SET @msg='0'
		END	
	END
	ELSE IF(@Operation=2)
	BEGIN
		IF(@CurrentDate >= @GetDateChinaAfter30Days)
		BEGIN
			SET @msg= '1'
		END
		ELSE
		BEGIN
			SET @msg='0'
		END	
	END
	ELSE IF(@Operation=3)
	BEGIN
		DECLARE @TempTable as Table(
			PONumber varchar(50),  
			Part# varchar(50), 
			[Description] varchar(500),  
			OrderDate   varchar(50),
			Requestor   varchar(50),  
			Sourceid    varchar(10), 
			OrderQty    int,     
			ShipQty     int,  
			PendingQty  int,  
			DetailsStatus varchar(10),  
			Shipmentby  VARCHAR(10),     
			UM varchar(10), 
			POId int,  
			PartID int,  
			IsSubmitted int,
			PODetailsID int,
			EmailSent	int,
			EmailSentDate	Date
		)
		INSERT INTO @TempTable
		SELECT 
		Inv_PurchaseOrder_Manual.PONumber,
		MIN(Inv_Parts.PartNumber) AS PartNumber,MIN(Inv_Parts.PartDes) AS PartDes,
		MIN(convert(varchar,Inv_PurchaseOrder_Manual.IssueDate,1)) AS OrderDate,
		CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.Requestor) IS NULL THEN 
		concat(MIN(EmpRequestor.FirstName) + ' ', MIN(EmpRequestor.LastName))
		ELSE concat(MIN(EmpPORequestor.FirstName) + ' ', MIN(EmpPORequestor.LastName)) end as Requestor,
		MIN(Inv_Source.[Source]) AS [Source],NULL AS OrderQty,NULL AS ShipQty,NULL AS PendingQty,
		MIN(Inv_PurchaseOrderDetail_Manual.[StatusID]),
		CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.ReqID) IS NULL THEN MIN(Inv_PurchaseOrderDetail_Manual.ShipmentBy)
		ELSE
		MIN(Inv_RequisitionDetail.ShipmentBy) END AS ShipmentBy,MIN(Inv_UM.UM) AS [UM],MIN(Inv_PurchaseOrder_Manual.Id) AS POId,
		Inv_Parts.id,MIN(Inv_PurchaseOrder_Manual.IsSubmitted) AS IsSubmitted,
		MIN(Inv_PurchaseOrderDetail_Manual.id),MIN(Inv_PurchaseOrderDetail_Manual.EmailSent),
		MIN(Inv_PurchaseOrderDetail_Manual.EmailSentDate)
		FROM Inv_PurchaseOrderDetail_Manual
		Inner join Inv_PurchaseOrder_Manual on Inv_PurchaseOrder_Manual.Id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
		LEFT JOIN Inv_RequisitionDetail ON Inv_RequisitionDetail.id=Inv_PurchaseOrderDetail_Manual.ReqDetailID
		LEFT JOIN tblEmployees as EmpRequestor ON EmpRequestor.EmployeeID=Inv_RequisitionDetail.Requestor
		LEFT JOIN tblEmployees as EmpPORequestor ON EmpPORequestor.EmployeeID=Inv_PurchaseOrderDetail_Manual.Requestor
		LEFT JOIN Inv_Parts ON Inv_Parts.id=Inv_PurchaseOrderDetail_Manual.PartId
		LEFT JOIN Inv_Source ON Inv_Source.id=Inv_PurchaseOrder_Manual.SourceId
		LEFT JOIN Inv_UM ON Inv_UM.id=Inv_Parts.UMId
		Where Inv_PurchaseOrder_Manual.SourceId=1 and Inv_PurchaseOrderDetail_Manual.StatusID=1
		AND (EmailSent IS NULL OR EmailSent=0 OR EmailSent=1)		
		Group by Inv_PurchaseOrder_Manual.PONumber,Inv_Parts.id

		DECLARE @PART_ID int 
		DECLARE @PO_id int 
		DECLARE @PODetailsID INT
		DECLARE @Email_Sent int
		DECLARE @Email_SentDate Date		
		DECLARE CUR_PART 
  
		CURSOR	
		STATIC FOR SELECT Partid,POID,PODetailsID,EmailSent,EmailSentDate FROM @Temptable  
		OPEN 
		CUR_PART 
		IF @@CURSOR_ROWS > 0 
		BEGIN 
		FETCH 
		NEXT FROM CUR_PART INTO @PART_ID,@PO_id,@PODetailsID,@Email_Sent,@Email_SentDate
		WHILE @@Fetch_status = 0 
		BEGIN 

		UPDATE @TempTable SET OrderQty=(SELECT CASE WHEN MIN(ReqID) IS NOT NULL THEN SUM(OrderQty) ELSE MIN(OrderQty) END AS OrderQty FROM Inv_PurchaseOrderDetail_Manual 
		WHERE Inv_PurchaseOrderDetail_Manual.PartId=@PART_ID AND Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=@PO_id
		GROUP BY Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,PartId)
		WHERE PartID=@PART_ID AND POId=@PO_id

		UPDATE @TempTable SET ShipQty=(SELECT SUM(ISNULL(ShipQty,0)) FROM Inv_ContainerDetail WHERE Inv_ContainerDetail.PartId=@PART_ID
		AND POId=@PO_id
		)
		WHERE PartID=@PART_ID AND POId=@PO_id

		DECLARE @DateAfter6Months AS DATE=NULL
		SET @DateAfter6Months=DATEADD(DAY, 180, @Email_SentDate)
		
		if((@Email_Sent is not null OR @Email_Sent != 0) AND (@DateAfter6Months > GETDATE()))
		BEGIN
			DELETE @TempTable WHERE PartId=@PART_ID 
			AND POId=@PO_id AND PODetailsID=@PODetailsID and PartId=@PART_ID
		END


		if(@Email_Sent=1 AND  (@DateAfter6Months < GETDATE()))
		BEGIN
			Update Inv_PurchaseOrderDetail_Manual set EmailSent=1,EmailSentDate=GETDATE() where PartId=@PART_ID 
			AND PurchaseOrderId=@PO_id AND Id=@PODetailsID and PartId=@PART_ID
		END	

		if(@Email_Sent=0 OR @Email_Sent IS NULL)
		BEGIN
			Update Inv_PurchaseOrderDetail_Manual set EmailSent=1,EmailSentDate=GETDATE() where PartId=@PART_ID 
			AND PurchaseOrderId=@PO_id AND Id=@PODetailsID and PartId=@PART_ID
		END
		
		FETCH NEXT FROM CUR_PART INTO @PART_ID,@PO_id,@PODetailsID,@Email_Sent,@Email_SentDate 
		END 
		END  
		CLOSE CUR_PART 
		DEALLOCATE CUR_PART 

		SELECT 
		PONumber,Part#,[Description],OrderDate,
		Requestor,
		Sourceid,OrderQty,ShipQty,
		case when (ISNULL(OrderQty,0)-ISNULL(ShipQty,0))<0 then 0 else (ISNULL(OrderQty,0)-ISNULL(ShipQty,0)) end as  PendingQty,
		CASE WHEN ISNULL(DetailsStatus,1)=1 Then 'Open' WHEN DetailsStatus=2 THEN 'Close' End AS DetailsStatus,
		CASE WHEN Shipmentby=1 Then 'By Sea' When Shipmentby=2 Then 'By Air' End as Shipmentby,
		UM,POId,PartID,IsSubmitted,PODetailsID,EmailSent,EmailSentDate
		FROM @TempTable 
		Order by PONumber ASC,ShipQty desc
	END
	ELSE IF(@Operation=4)
	BEGIN
		DECLARE @TempTableChina as Table(
			PONumber varchar(50),  
			Part# varchar(50), 
			[Description] varchar(500),  
			OrderDate   varchar(50),
			Requestor   varchar(50),  
			Sourceid    varchar(10), 
			OrderQty    int,     
			ShipQty     int,  
			PendingQty  int,  
			DetailsStatus varchar(10),  
			Shipmentby  VARCHAR(10),     
			UM varchar(10), 
			POId int,  
			PartID int,  
			IsSubmitted int,
			PODetailsID int,
			EmailSent	int,
			EmailSentDate	Date
		)
		INSERT INTO @TempTableChina
		SELECT 
		Inv_PurchaseOrder_Manual.PONumber,
		MIN(Inv_Parts.PartNumber) AS PartNumber,MIN(Inv_Parts.PartDes) AS PartDes,
		MIN(convert(varchar,Inv_PurchaseOrder_Manual.IssueDate,1)) AS OrderDate,
		CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.Requestor) IS NULL THEN 
		concat(MIN(EmpRequestor.FirstName) + ' ', MIN(EmpRequestor.LastName))
		ELSE concat(MIN(EmpPORequestor.FirstName) + ' ', MIN(EmpPORequestor.LastName)) end as Requestor,
		MIN(Inv_Source.[Source]) AS [Source],NULL AS OrderQty,NULL AS ShipQty,NULL AS PendingQty,
		MIN(Inv_PurchaseOrderDetail_Manual.[StatusID]),
		CASE WHEN MIN(Inv_PurchaseOrderDetail_Manual.ReqID) IS NULL THEN MIN(Inv_PurchaseOrderDetail_Manual.ShipmentBy)
		ELSE
		MIN(Inv_RequisitionDetail.ShipmentBy) END AS ShipmentBy,MIN(Inv_UM.UM) AS [UM],MIN(Inv_PurchaseOrder_Manual.Id) AS POId,
		Inv_Parts.id,MIN(Inv_PurchaseOrder_Manual.IsSubmitted) AS IsSubmitted,
		MIN(Inv_PurchaseOrderDetail_Manual.id),MIN(Inv_PurchaseOrderDetail_Manual.EmailSent),
		MIN(Inv_PurchaseOrderDetail_Manual.EmailSentDate)
		FROM Inv_PurchaseOrderDetail_Manual
		Inner join Inv_PurchaseOrder_Manual on Inv_PurchaseOrder_Manual.Id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
		LEFT JOIN Inv_RequisitionDetail ON Inv_RequisitionDetail.id=Inv_PurchaseOrderDetail_Manual.ReqDetailID
		LEFT JOIN tblEmployees as EmpRequestor ON EmpRequestor.EmployeeID=Inv_RequisitionDetail.Requestor
		LEFT JOIN tblEmployees as EmpPORequestor ON EmpPORequestor.EmployeeID=Inv_PurchaseOrderDetail_Manual.Requestor
		LEFT JOIN Inv_Parts ON Inv_Parts.id=Inv_PurchaseOrderDetail_Manual.PartId
		LEFT JOIN Inv_Source ON Inv_Source.id=Inv_PurchaseOrder_Manual.SourceId
		LEFT JOIN Inv_UM ON Inv_UM.id=Inv_Parts.UMId
		Where Inv_PurchaseOrder_Manual.SourceId=2 and Inv_PurchaseOrderDetail_Manual.StatusID=1
		AND (EmailSent IS NULL OR EmailSent=0 OR EmailSent=1)		
		Group by Inv_PurchaseOrder_Manual.PONumber,Inv_Parts.id

		DECLARE @PART_IDChina int 
		DECLARE @PO_idChina int 
		DECLARE @PODetailsIDChina INT
		DECLARE @Email_SentChina int
		DECLARE @Email_SentDateChina Date		
		DECLARE CUR_PART 
  
		CURSOR	
		STATIC FOR SELECT Partid,POID,PODetailsID,EmailSent,EmailSentDate FROM @TempTableChina  
		OPEN 
		CUR_PART 
		IF @@CURSOR_ROWS > 0 
		BEGIN 
		FETCH 
		NEXT FROM CUR_PART INTO @PART_IDChina,@PO_idChina,@PODetailsIDChina,@Email_SentChina,@Email_SentDateChina
		WHILE @@Fetch_status = 0 
		BEGIN 

		UPDATE @TempTableChina SET OrderQty=(SELECT CASE WHEN MIN(ReqID) IS NOT NULL THEN SUM(OrderQty) ELSE MIN(OrderQty) END AS OrderQty FROM Inv_PurchaseOrderDetail_Manual 
		WHERE Inv_PurchaseOrderDetail_Manual.PartId=@PART_IDChina AND Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=@PO_idChina
		GROUP BY Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,PartId)
		WHERE PartID=@PART_IDChina AND POId=@PO_idChina

		UPDATE @TempTableChina SET ShipQty=(SELECT SUM(ISNULL(ShipQty,0)) FROM Inv_ContainerDetail WHERE Inv_ContainerDetail.PartId=@PART_IDChina
		AND POId=@PO_idChina
		)
		WHERE PartID=@PART_IDChina AND POId=@PO_idChina

		DECLARE @DateAfter6MonthsChina AS DATE=NULL
		SET @DateAfter6MonthsChina=DATEADD(DAY, 180 , @Email_SentDateChina)
		
		if(@Email_SentChina=1 AND (@DateAfter6MonthsChina > @CurrentDate))
		BEGIN
			DELETE @TempTableChina WHERE PartId=@PART_IDChina 
			AND POId=@PO_idChina AND PODetailsID=@PODetailsIDChina 
		END


		if(@Email_SentChina=1 AND  (@DateAfter6MonthsChina < @CurrentDate))
		BEGIN
			Update Inv_PurchaseOrderDetail_Manual set EmailSent=1,EmailSentDate=GETDATE() where PartId=@PART_IDChina 
			AND PurchaseOrderId=@PO_idChina AND Id=@PODetailsIDChina 
		END	

		if(@Email_SentChina=0 OR @Email_SentDateChina IS NULL)
		BEGIN
			Update Inv_PurchaseOrderDetail_Manual set EmailSent=1,EmailSentDate=GETDATE() where PartId=@PART_IDChina 
			AND PurchaseOrderId=@PO_idChina AND Id=@PODetailsIDChina 
		END
		
		FETCH NEXT FROM CUR_PART INTO @PART_IDChina,@PO_idChina,@PODetailsIDChina,@Email_SentChina,@Email_SentDateChina
		END 
		END  
		CLOSE CUR_PART 
		DEALLOCATE CUR_PART 

		SELECT 
		PONumber,Part#,[Description],OrderDate,
		Requestor,
		Sourceid,OrderQty,ShipQty,
		case when (ISNULL(OrderQty,0)-ISNULL(ShipQty,0))<0 then 0 else (ISNULL(OrderQty,0)-ISNULL(ShipQty,0)) end as  PendingQty,
		CASE WHEN ISNULL(DetailsStatus,1)=1 Then 'Open' WHEN DetailsStatus=2 THEN 'Close' End AS DetailsStatus,
		CASE WHEN Shipmentby=1 Then 'By Sea' When Shipmentby=2 Then 'By Air' End as Shipmentby,
		UM,POId,PartID,IsSubmitted,PODetailsID,EmailSent,EmailSentDate
		FROM @TempTableChina 
		Order by PONumber ASC,ShipQty desc
	END
END
