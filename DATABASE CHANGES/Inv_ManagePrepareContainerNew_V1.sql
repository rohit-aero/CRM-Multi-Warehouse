ALTER PROCEDURE [IV].[Inv_ManagePrepareContainerNew_V1]
-- Add the parameters for the stored procedure here
@Operation int=NULL,
@msg varchar(500)='' output,
@POid int=NULL,
@POForId int=NULL,
@InvoiceNo VARCHAR(50)=NULL,
@ContainerNo VARCHAR(50)=NULL,
@SealNo VARCHAR(50)=NULL,
@SentDate DATE=NULL,
@Containerid int=NULL,
@POStatus int=NULL,
@EmployeeID int=NULL,
@Partid int=NULL,
@ArrivalinAerowerks DATE=NULL,
@ContainerSize Varchar(50)=NULL,
@Attn INT=NULL,
@Issuedby INT=NULL,
@SourceID INT=NULL,
@ShipmentBy	INT=NULL,
@ContainerDetails ContainerDetails readonly,
@LoginUserId INT=NULL,
@JobID	Varchar(50)=NULL,
@Qty	INT=NULL,
@desc Varchar(500)=NULL,
@requestor Varchar(50)=NULL,
@Remarks VARCHAR(500)=NULL,
@ContainerProjectsID	INT=NULL,
@TentativeSentDate	Date=NULL,
@ApprovedBy	INT=NULL,
@UploadDocument	VARCHAR(MAX)=NULL,
@Status	int=NULL,
@PODetailid int=NULL,
@WareHouseID int=NULL
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;
DECLARE @issubmitted int
DECLARE @Counter int
DECLARE @Containertemptable table
(
[POid] [int] NULL,
[PODetailid] [int] NULL,
[Containerid] [int] NULL,
[PartId] [int] NULL,
[ShipQty] [int] NULL,
[Remarks] [varchar](500) NULL,
[ReqNo] [varchar](500) NULL,
[PartNo] [varchar](500) NULL,
[revisionno] [char](1) NULL,
[PartDes] [varchar](500) NULL,
[ReqPriority] [bit] NULL,
[OrderQty] [int] NULL,
[Status] [int] NULL
)




-- Insert statements for procedure here
if(@Operation=1)
BEGIN

	--Table 0
	SELECT DISTINCT Inv_Container.id as Containerid,
	CASE WHEN ISNULL(Inv_Container.ContainerNo,'')= '' OR Inv_Container.ContainerNo IS NULL THEN Inv_Container.InvoiceNo
	ELSE
	Inv_Container.InvoiceNo + '/'
	+ Inv_Container.ContainerNo END as ContainerDetail
	FROM Inv_Container 
	LEFT JOIN Inv_ContainerDetail ON Inv_ContainerDetail.ContainerId=Inv_Container.id
	--LEFT JOIN Inv_PurchaseOrder_Manual ON Inv_PurchaseOrder_Manual.id=Inv_ContainerDetail.POId
	WHERE Inv_Container.IsSubmitted IS NULL 
	and Inv_Container.SourceId = @SourceId

	SELECT EmployeeID,FirstName + ' ' + ISNULL(LastName,'') AS EmployeeName 
	FROM tblEmployees WHERE EmployeeID in (110)
	Order by FirstName asc
			
	IF(@EmployeeID=340)
	BEGIN
		SELECT EmployeeID,FirstName + ' ' + ISNULL(LastName, '') as EmployeeName 
		FROM tblEmployees WHERE EmployeeID in (340)
		Order by FirstName asc
	END
	ELSE IF(@EmployeeID=335)
	BEGIN
		SELECT EmployeeID,FirstName + ' ' + ISNULL(LastName, '') as EmployeeName 
		FROM tblEmployees WHERE EmployeeID in (335)
		Order by FirstName asc

	END
	ELSE
	BEGIN
		SELECT EmployeeID,FirstName + ' ' + ISNULL(LastName, '') as EmployeeName 
		FROM tblEmployees WHERE EmployeeID in (340,335)
		Order by FirstName asc
	END
					

	SELECT 
	Inv_Warehouse.Id AS WareHouseID,
	Inv_Warehouse.[WarehouseName] AS [Name]
	FROM Inv_Warehouse
	Order by Inv_Warehouse.[WarehouseName] ASC
END

ELSE if(@Operation=2)
BEGIN
DECLARE @TEMP AS TABLE
(
	POid	int,
	PONumber varchar(150),
	PODetailid int,
	Partid int,				
	OrderQty int,				
	PendingQty int,
	SkidNo varchar(500),
	ShipQty int,
	Remarks varchar(500),
	[Status] int,
	SourceId int,
	DestWarehouseID int
)

insert into @TEMP	
SELECT 
    Inv_PurchaseOrder_Manual.id as POid,
    PONumber,
    0 as PODetailid,
    Inv_Parts.id as Partid,   
    NULL as OrderQty,
	0 as PendingQty,
    NULL as SkidNo,
    NULL as ShipQty,
    NULL as Remarks, 
	CASE WHEN ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1)=0 THEN 1
	ELSE ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1) END AS [Status],
    MIN(Inv_PurchaseOrder_Manual.SourceId) AS SourceId,
	MIN(Inv_PurchaseOrder_Manual.WareHouseID) AS DestWarehouseID
	FROM Inv_PurchaseOrderDetail_Manual
	INNER JOIN Inv_PurchaseOrder_Manual 
	ON Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=Inv_PurchaseOrder_Manual.Id
	LEFT JOIN  Inv_Parts ON Inv_Parts.id=Inv_PurchaseOrderDetail_Manual.PartId
	LEFT JOIN  Inv_ContainerDetail 
	ON Inv_ContainerDetail.PODetailid=Inv_PurchaseOrderDetail_Manual.Id
	LEFT JOIN  Inv_Container ON Inv_Container.id = Inv_ContainerDetail.ContainerId
	WHERE Inv_Parts.id=@Partid AND 
	Inv_PurchaseOrder_Manual.SourceId=@SourceID 
	and Inv_PurchaseOrder_Manual.WareHouseID=@WareHouseID
	AND Inv_PurchaseOrder_Manual.IsSubmitted=1 AND 
	(Inv_PurchaseOrderDetail_Manual.StatusID IS NULL OR Inv_PurchaseOrderDetail_Manual.StatusID IN (0,1))
	GROUP BY Inv_Parts.id, PONumber,Inv_PurchaseOrder_Manual.id,
	Inv_PurchaseOrderDetail_Manual.[StatusID]
	ORDER BY MIN(Inv_PurchaseOrderDetail_Manual.PartId), 
	PONumber ASC?
	
			DECLARE @POID_CUR4 INT			
			DECLARE @PartID_CUR4 INT
			DECLARE [CURSOR_NAME] CURSOR	
			STATIC FOR
			SELECT POid, PartId FROM @TEMP
			OPEN [CURSOR_NAME]
				IF @@CURSOR_ROWS > 0
				BEGIN
					FETCH NEXT FROM [CURSOR_NAME] INTO @POID_CUR4, @PartID_CUR4
					WHILE @@FETCH_STATUS = 0
					BEGIN

					UPDATE @TEMP SET OrderQty=(SELECT CASE WHEN MIN(ReqID) IS NOT NULL 
					THEN SUM(OrderQty) 
					ELSE MIN(OrderQty) END AS OrderQty 
					FROM Inv_PurchaseOrderDetail_Manual 
					WHERE Inv_PurchaseOrderDetail_Manual.PartId=@PartID_CUR4 
					AND Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=@POID_CUR4
					GROUP BY Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,PartId)
					WHERE PartID=@PartID_CUR4 AND POId=@POID_CUR4

					UPDATE @TEMP SET PendingQty=(
					(SELECT MIN(ISNULL(OrderQty, 0)) - SUM(ISNULL(ShipQty, 0)) 
					FROM Inv_ContainerDetail 
					INNER JOIN Inv_Container 
					ON Inv_Container.id = Inv_ContainerDetail.ContainerId
					WHERE Inv_ContainerDetail.POid = @POID_CUR4 AND Partid = @PartID_CUR4)
					) 
					WHERE POid=@POID_CUR4 AND Partid = @PartID_CUR4						


				FETCH NEXT FROM [CURSOR_NAME] INTO @POID_CUR4, @PartID_CUR4
					END
				END
			CLOSE [CURSOR_NAME]
			DEALLOCATE [CURSOR_NAME]

	select * from @TEMP 
END

ELSE if(@Operation=3)
BEGIN
			DECLARE @ContainerSubmit as INT			
			
			if(@InvoiceNo IS NOT NULL)
			BEGIN
			SET @ContainerSubmit=(SELECT COUNT(Inv_Container.id)
			FROM Inv_Container 
			INNER JOIN Inv_ContainerDetail 
			ON Inv_ContainerDetail.ContainerId=Inv_Container.id
			INNER JOIN Inv_PurchaseOrder_Manual 
			ON Inv_PurchaseOrder_Manual.id=Inv_ContainerDetail.POId
			WHERE Inv_Container.IsSubmitted IS NULL 
			and Inv_PurchaseOrder_Manual.SourceId = @SourceId)

			if(@InvoiceNo != '')
			BEGIN
			SET @ContainerSubmit=(SELECT COUNT(Inv_Container.id) 
			FROM Inv_Container WHERE InvoiceNo = @InvoiceNo)
			END
			ELSE
			BEGIN
			SET @ContainerSubmit=NULL;	
			END
			END
			IF(@ContainerSubmit > 0)
			BEGIN
				SET @msg = 'ER01'
			END

			ELSE
				BEGIN					
					SET @ContainerSubmit=(SELECT COUNT(Inv_Container.id) 
					FROM Inv_Container WHERE InvoiceNo = @InvoiceNo)

					IF(@ContainerSubmit > 0)
						BEGIN
							SET @msg = 'ER02'
						END
					ELSE
						BEGIN
							SET @ContainerSubmit = NULL
						END
				END

			IF(@ContainerSubmit IS NULL)
			BEGIN
			
			INSERT INTO Inv_Container (
			InvoiceNo,ContainerNo,SealNo,TentativeSentDate,
			SentDate,ArrivalinAerowerks,ContainerSize,
			Attn,ApprovedBy,Issuedby, SourceID,
			ShipmentBy,UploadDocument,WareHouseID)
			VALUES (
			@InvoiceNo,@ContainerNo,@SealNo,@TentativeSentDate,
			@SentDate,@ArrivalinAerowerks,@ContainerSize,
			@Attn,@ApprovedBy,@Issuedby, @SourceID,
			@ShipmentBy,@UploadDocument,@WareHouseID)

			declare @container as INT
			SET @container=SCOPE_IDENTITY()			

			Set @msg=@container
			
			SET @Counter=1

			WHILE @Counter <= (SELECT COUNT(Inv_ContainerDetail.ContainerId) 
			FROM Inv_ContainerDetail where ContainerId=@msg)
			BEGIN
			Delete From Inv_ContainerDetail 
			where  Inv_ContainerDetail.PODetailid 
			in (select PODetailid from @ContainerDetails)

			SET @Counter=@Counter+1
			END		

			INSERT INTO Inv_ContainerDetail (
			ContainerId,POId,PODetailid,PartId,
			OrderQty,ShipQty,PendingQty,SkidNo,Remarks,PackingNo,[Status])
			SELECT @container,Reqid,ReqDetailid,PartId,
			OrderQty,ShipQty,PendingQty,SkidNo,Remarks,PackingNo,[Status]	
			FROM @ContainerDetails where ShipQty>0	

			Update Inv_PurchaseOrderDetail_Manual
			SET 
			[Remarks] = r.[Remarks]
			from @ContainerDetails r
			Where Inv_PurchaseOrderDetail_Manual.PurchaseOrderId = r.Reqid
			and Inv_PurchaseOrderDetail_Manual.PartId=r.PartId
			AND (r.[Status]=2 and (r.Remarks != null OR r.Remarks != ''))
			
			Update Inv_PurchaseOrderDetail_Manual
			SET 
			[StatusID] = r.[Status]
			from @ContainerDetails r
			Where Inv_PurchaseOrderDetail_Manual.PurchaseOrderId = r.Reqid
			and  Inv_PurchaseOrderDetail_Manual.PartId=r.PartId

			INSERT INTO [dbo].[Inv_ContainerLogs]
			([ContainerId], [CreatedDate], [CreatedBy])
			VALUES
			(@msg,GETDATE(),@LoginUserId)			
			END
			END
ELSE IF(@Operation=4)
BEGIN
			SELECT InvoiceNo,ContainerNo,SealNo,TentativeSentDate,SentDate,
			ArrivalinAerowerks,isnull(Attn,0) as Attn,ApprovedBy,
			isnull(Issuedby,0) as Issuedby,ContainerSize,Shipmentby,UploadDocument,
			WareHouseID
			FROM Inv_Container
			WHERE Inv_Container.id=@Containerid

			--Get Destination WareHouse ID
			DECLARE @GetDestWareID AS INT=NULL
			SET @GetDestWareID=(SELECT TOP 1  WareHouseID 
			FROM Inv_Container 
			WHERE Inv_Container.id=@Containerid)

			DECLARE @temptablePO1 as table 
			(
			PartId	 int,
			PartNumber Varchar(500),
			POid	 int,
			PODetailid int,	
			SourceID int,
			[Status] int,
			DestWareHouseID int,
			UM		Varchar(50)
				
			)
			INSERT INTO @temptablePO1 (
			PartId,PartNumber,POid,PODetailid,SourceID,[Status],DestWareHouseID,[UM])			
			Select DISTINCT  Inv_Parts.id,
			Concat(Inv_Parts.PartNumber + '/' , Inv_Parts.PartDes),0 as POId,0 as PODetailid,
			Inv_PurchaseOrder_Manual.SourceId,NULL AS [StatusID],
			Inv_PurchaseOrder_Manual.WareHouseID AS DestWareHouseID,
			Inv_UM.[UM]
			from Inv_PurchaseOrderDetail_Manual 
			Inner join Inv_Parts 
			on Inv_PurchaseOrderDetail_Manual.PartId=Inv_Parts.id
			inner join Inv_PurchaseOrder_Manual on
			Inv_PurchaseOrder_Manual.id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
			LEFT JOIN Inv_UM ON Inv_UM.id=Inv_Parts.UMId
			WHERE Inv_PurchaseOrder_Manual.IsSubmitted=1 
			AND Inv_PurchaseOrder_Manual.SourceId=@SourceID 
			AND Inv_PurchaseOrder_Manual.WareHouseID=@GetDestWareID
			and ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1)=1
			GROUP BY Inv_Parts.id,Inv_Parts.PartNumber,Inv_Parts.PartDes,
			Inv_PurchaseOrder_Manual.SourceId,Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,
			Inv_PurchaseOrder_Manual.WareHouseID,
			ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1),Inv_UM.[UM]
			UNION 
			select distinct Inv_ContainerDetail.PartId,
			Inv_Parts.PartNumber + '/' + Inv_Parts.PartDes,
			0 as POId,0 as PODetailid,
			Inv_PurchaseOrder_Manual.SourceId,NULL AS [StatusID],
			Inv_PurchaseOrder_Manual.WareHouseID AS DestWareHouseID,
			Inv_UM.[UM]
			from Inv_PurchaseOrderDetail_Manual 
			inner join Inv_PurchaseOrder_Manual 
			on Inv_PurchaseOrder_Manual.id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
			left join Inv_ContainerDetail on Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=
			Inv_ContainerDetail.POId
			left join Inv_Parts on Inv_Parts.id=Inv_ContainerDetail.PartId
			LEFT JOIN Inv_UM ON Inv_UM.id=Inv_Parts.UMId
			where ContainerId=@Containerid 
			and Inv_PurchaseOrder_Manual.IsSubmitted=1 
			and Inv_PurchaseOrder_Manual.SourceId=@SourceID
			AND Inv_PurchaseOrder_Manual.WareHouseID=@GetDestWareID

			SELECT * FROM @temptablePO1  
			Order by PartNumber asc


			
	DECLARE @TEMP_1 AS TABLE
			(
				POid	int,
				PONumber varchar(150),
				PODetailid int,
				Partid int,				
				OrderQty int,				
				PendingQty int,
				SkidNo varchar(500),
				ShipQty int,
				Remarks varchar(500),
				[Status] int,
				SourceId int
			)

insert into @TEMP_1	
SELECT 
    Inv_PurchaseOrder_Manual.id as POid,
    PONumber,
    0 as PODetailid,
    Inv_Parts.id as Partid,   
    NULL as OrderQty,
	NULL as PendingQty,
    (
	SELECT TOP 1 SkidNo 
	FROM Inv_ContainerDetail 
	WHERE ContainerId = @ContainerId AND PartId = @PartId 
	AND POId = Inv_PurchaseOrder_Manual.id) as SkidNo,
    (
	SELECT TOP 1 ShipQty 
	FROM Inv_ContainerDetail 
	WHERE ContainerId = @ContainerId 
	AND PartId = @PartId AND POId = Inv_PurchaseOrder_Manual.id) as ShipQty,
    (
	SELECT TOP 1 Remarks 
	FROM Inv_ContainerDetail 
	WHERE ContainerId = @ContainerId 
	AND PartId = @PartId 
	AND POId = Inv_PurchaseOrder_Manual.id) as Remarks, 
	CASE WHEN Inv_PurchaseOrderDetail_Manual.[StatusID]=0 THEN 1 
	ELSE ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1) END
	AS [Status],
    MIN(Inv_PurchaseOrder_Manual.SourceId) AS SourceId
	FROM Inv_PurchaseOrderDetail_Manual
	INNER JOIN Inv_PurchaseOrder_Manual 
	ON Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=Inv_PurchaseOrder_Manual.Id
	LEFT JOIN  Inv_Parts 
	ON Inv_Parts.id=Inv_PurchaseOrderDetail_Manual.PartId
	LEFT JOIN  Inv_ContainerDetail 
	ON Inv_ContainerDetail.PODetailid=Inv_PurchaseOrderDetail_Manual.Id
	LEFT JOIN  Inv_Container 
	ON Inv_Container.id = Inv_ContainerDetail.ContainerId
	WHERE Inv_Parts.id=@PartId 
	AND Inv_PurchaseOrder_Manual.SourceId=@SourceID 
	AND Inv_PurchaseOrder_Manual.WareHouseID=@GetDestWareID
	GROUP BY Inv_Parts.id, PONumber,Inv_PurchaseOrder_Manual.id,
	Inv_PurchaseOrderDetail_Manual.[StatusID]
	ORDER BY MIN(Inv_PurchaseOrderDetail_Manual.PartId), PONumber ASC?

			DECLARE @POID_CUR3 INT
			DECLARE @PODetailID_CUR3 INT
			DECLARE @PartID_CUR3 INT
			DECLARE [CURSOR_NAME] CURSOR	
			STATIC FOR
			SELECT POid,PODetailid, PartId FROM @TEMP_1
			OPEN [CURSOR_NAME]
		IF @@CURSOR_ROWS > 0
		BEGIN
			FETCH NEXT FROM [CURSOR_NAME] INTO @POID_CUR3,@PODetailID_CUR3, @PartID_CUR3
			WHILE @@FETCH_STATUS = 0
			BEGIN

			UPDATE @TEMP_1 SET OrderQty=(
			SELECT CASE WHEN MIN(ReqID) IS NOT NULL 
			THEN SUM(OrderQty) 
			ELSE MIN(OrderQty) END AS OrderQty 
			FROM Inv_PurchaseOrderDetail_Manual 
			WHERE Inv_PurchaseOrderDetail_Manual.PartId=@PartID_CUR3 
			AND Inv_PurchaseOrderDetail_Manual.PurchaseOrderId=@POID_CUR3
			GROUP BY Inv_PurchaseOrderDetail_Manual.PurchaseOrderId,PartId)
			WHERE PartID=@PartID_CUR3 AND POId=@POID_CUR3


			UPDATE @TEMP_1 SET PendingQty=(
			(
			SELECT MIN(ISNULL(OrderQty, 0)) - SUM(ISNULL(ShipQty, 0)) 
			FROM Inv_ContainerDetail 
			INNER JOIN Inv_Container ON Inv_Container.id = Inv_ContainerDetail.ContainerId
			WHERE Inv_ContainerDetail.POid = @POID_CUR3 AND Partid = @PartID_CUR3)
			) 
			WHERE POid=@POID_CUR3 AND Partid = @PartID_CUR3			

				


		FETCH NEXT FROM [CURSOR_NAME] INTO @POID_CUR3,@PODetailID_CUR3, @PartID_CUR3
					END
				END
			CLOSE [CURSOR_NAME]
			DEALLOCATE [CURSOR_NAME]

	select * from @TEMP_1 where [Status]=1 
	OR ([Status]=2 AND ShipQty>0) OR ([Status]=3 AND ShipQty>0)

END
ELSE if(@Operation=5)
BEGIN
		UPDATE Inv_PurchaseOrder_Manual 
		SET [Status] = @POStatus 
		where Inv_PurchaseOrder_Manual.id = @POid
END

ELSE IF(@Operation=6)
BEGIN
		UPDATE Inv_Container 
		SET IsSubmitted=1 
		WHERE Inv_Container.id=@Containerid

		INSERT INTO [dbo].[Inv_ContainerLogs]
		([ContainerId], [SubmitedDate], [SubmitedBy])
		VALUES
		(@Containerid,GETDATE(),@LoginUserId)	
		
		SET @msg='Records Submitted Successfull !!!';

		--Check Auto Submit Status --Close if Ship Qty Greater than Order Qty
		WITH CTE AS (
		SELECT 
		MIN(Inv_ContainerDetail.ContainerId) AS ContainerID,
		Inv_ContainerDetail.POId, 
		Inv_ContainerDetail.PartId, 
		MIN(OrderQty) AS TotalOrderQty,
		SUM(ShipQty) AS TotalShipQty
		FROM 
		Inv_ContainerDetail		
		GROUP BY 
		Inv_ContainerDetail.POId, 
		Inv_ContainerDetail.PartId
		HAVING 
		SUM(ShipQty) >= MIN(OrderQty)
		)
		UPDATE Inv_PurchaseOrderDetail_Manual
		SET [StatusID] = 2
		FROM Inv_PurchaseOrderDetail_Manual
		JOIN CTE
		ON Inv_PurchaseOrderDetail_Manual.PurchaseOrderId = CTE.POId 
		AND Inv_PurchaseOrderDetail_Manual.PartId = CTE.PartId
		WHERE CTE.TotalShipQty >= CTE.TotalOrderQty;

		
END

ELSE IF(@Operation=7)
BEGIN
		DECLARE @temptablePO as table 
			(
				PartId	 int,
				PartNumber Varchar(500),
				POid	 int,
				PODetailid int,	
				SourceID int,
				[Status] int,
				DestWareHouseID int,
				UM		Varchar(50)
			)
			INSERT INTO @temptablePO (
			PartId,
			PartNumber,POid,PODetailid,
			SourceID,[Status],DestWareHouseID,[UM])
			Select DISTINCT  Inv_Parts.id,
			MIN(Inv_Parts.PartNumber) + '/' + MIN(Inv_Parts.PartDes) 
			as PartNumber,MIN(Inv_PurchaseOrder_Manual.id) AS POid,0 AS PODetailid,
			Inv_PurchaseOrder_Manual.SourceId,
			ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1),
			Inv_PurchaseOrder_Manual.WareHouseID,
			MIN(Inv_UM.[UM]) AS [UM]
			from Inv_PurchaseOrderDetail_Manual 
			Inner join Inv_Parts 
			on Inv_PurchaseOrderDetail_Manual.PartId=Inv_Parts.id
			inner join Inv_PurchaseOrder_Manual on
			Inv_PurchaseOrder_Manual.id=Inv_PurchaseOrderDetail_Manual.PurchaseOrderId
			LEFT JOIN Inv_UM ON Inv_UM.id=Inv_Parts.UMId
			WHERE Inv_PurchaseOrder_Manual.IsSubmitted=1
			GROUP BY Inv_Parts.id,Inv_PurchaseOrder_Manual.SourceId,Inv_PurchaseOrder_Manual.WareHouseID,
			ISNULL(Inv_PurchaseOrderDetail_Manual.[StatusID],1)
			

			SELECT * FROM @temptablePO  
			WHERE SourceID=@SourceID 
			AND  DestWareHouseID=@WareHouseID 
			and  ([Status]=1 OR [Status] IS NULL OR [Status]=0)
			Order by PartId asc

			
END


ELSE IF(@Operation=9)
BEGIN
		if(@InvoiceNo != '')
		BEGIN
			SET @ContainerSubmit=(SELECT COUNT(Inv_Container.id) 
			FROM Inv_Container 
			WHERE InvoiceNo = @InvoiceNo AND id <> @Containerid)
		END
		ELSE
		BEGIN
		SET @ContainerSubmit=NULL
		END
			IF(@ContainerSubmit > 0)
			BEGIN
				SET @msg = 'ER01'
			END

			ELSE
				BEGIN			
						DECLARE @CheckMainTableContainerID AS INT=NULL
						DECLARE @CheckMainTableWareHouseID AS INT=NULL
							
						SET @CheckMainTableContainerID=(SELECT Top 1 id  
						FROM Inv_Container 
						WHERE Inv_Container.id=@Containerid)

						SET @CheckMainTableWareHouseID=(
						SELECT TOP 1 WareHouseID 
						FROM Inv_Container 
						WHERE Inv_Container.id=@Containerid)

						IF(@CheckMainTableContainerID = @Containerid AND @CheckMainTableWareHouseID != @WareHouseID)
						BEGIN
							Update Inv_PurchaseOrderDetail_Manual
							SET 
							[StatusID]=1
							from Inv_ContainerDetail CD
							Where 
							PurchaseOrderId IN (SELECT POId 
							FROM Inv_ContainerDetail 
							WHERE ContainerId=@Containerid)
							AND Inv_PurchaseOrderDetail_Manual.PartId 
							IN (SELECT PartId 
							FROM Inv_ContainerDetail 
							WHERE ContainerId=@Containerid)

							Update Inv_ContainerDetail set PendingQty=NULL Where Inv_ContainerDetail.ContainerId=@Containerid
						END
					SET @ContainerSubmit=(SELECT COUNT(Inv_Container.id) FROM Inv_Container WHERE InvoiceNo = @InvoiceNo AND id <> @Containerid)
					IF(@ContainerSubmit > 0)
						BEGIN
							SET @msg = 'ER02'
						END
					ELSE
						BEGIN
						
							UPDATE Inv_Container SET InvoiceNo=@InvoiceNo,ContainerNo=@ContainerNo,SealNo=@SealNo,SentDate=@SentDate,
                             ArrivalinAerowerks=@ArrivalinAerowerks,ContainerSize=@ContainerSize,Attn=@Attn,Issuedby=@Issuedby, SourceID = @SourceID,
							ShipmentBy=@ShipmentBy,TentativeSentDate=@TentativeSentDate,
							ApprovedBy=@ApprovedBy,UploadDocument=@UploadDocument,
							WareHouseID=@WareHouseID
							WHERE Inv_Container.id = @Containerid

							SET @msg=(SELECT Inv_Container.id FROM Inv_Container WHERE Inv_Container.id = @Containerid)		
							
							
							SET @Counter=1
			
							WHILE @Counter <= (SELECT COUNT(Inv_ContainerDetail.ContainerId) FROM Inv_ContainerDetail where ContainerId=@msg)
							BEGIN
							Delete From Inv_ContainerDetail where Inv_ContainerDetail.ContainerId=@msg AND Inv_ContainerDetail.PODetailid in (select PODetailid from @ContainerDetails)

							SET @Counter=@Counter+1
							END
			
							INSERT INTO Inv_ContainerDetail (ContainerId,POId,PODetailid,PartId,OrderQty,ShipQty,Pendingqty,SkidNo,Remarks,PackingNo,[Status])
							SELECT @msg,Reqid,ReqDetailid,PartId,OrderQty,ShipQty,PendingQty,SkidNo,Remarks,PackingNo,[Status]
							FROM @ContainerDetails where ShipQty>0

							Update Inv_PurchaseOrderDetail_Manual
							SET 
							[Remarks] = r.[Remarks]
							from @ContainerDetails r
							Where Inv_PurchaseOrderDetail_Manual.PurchaseOrderId = r.Reqid
							and Inv_PurchaseOrderDetail_Manual.PartId=r.PartId
							AND (r.[Status]=2 and (r.Remarks != null OR r.Remarks != ''))


							Update Inv_PurchaseOrderDetail_Manual
							SET 
							[StatusID] = r.[Status]
							from @ContainerDetails r
							Where Inv_PurchaseOrderDetail_Manual.PurchaseOrderId = r.Reqid
							and Inv_PurchaseOrderDetail_Manual.PartId=r.PartId			

							INSERT INTO [dbo].[Inv_ContainerLogs]
							([ContainerId], [UpdatedDate], [UpdatedBy])
							VALUES
							(@msg,GETDATE(),@LoginUserId)						
							

		END
	END						
END

ELSE IF(@Operation=10)
	BEGIN
			SELECT DISTINCT Inv_Container.id as Containerid,
			CASE WHEN ISNULL(Inv_Container.ContainerNo,'')= '' OR Inv_Container.ContainerNo IS NULL THEN Inv_Container.InvoiceNo
			ELSE
			Inv_Container.InvoiceNo + '/'
			+ Inv_Container.ContainerNo END as ContainerDetail
			FROM Inv_Container 
			LEFT JOIN Inv_ContainerDetail ON Inv_ContainerDetail.ContainerId=Inv_Container.id			
			WHERE Inv_Container.IsSubmitted IS NULL and Inv_Container.SourceId = @SourceId
	END
--Container Project Job Operation Start
ELSE IF(@Operation=11)
BEGIN
		SELECT tblProjects.JobID AS ProjectID,
		CONCAT(tblCustomers.CompanyName + ', ', tblCustomers.City + ', ', tblStates.[State] + ', ', tblCountries.Country) as ProjectName
		FROM tblProjects
		INNER JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID
		LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID
		LEFT JOIN tblCountries ON tblCountries.CountryID=tblCustomers.CountryID
		Order by ProjectName asc
END

ELSE IF(@Operation=12)
BEGIN
INSERT INTO Inv_ContainerProjects (ContainerID,JobID,[Description],Requester,Qty,Remarks) values (@ContainerID,@JobID,@desc,@requestor,@Qty,@Remarks)
	SET @msg='Record Added Successfully !!!'
 
	INSERT INTO [dbo].[Inv_ContainerProjectLogs]
	([ContainerId],[JobName] ,[CreatedDate], [CreatedBy])
	VALUES
	(@Containerid,@JobID,GETDATE(),@LoginUserId)
END

ELSE IF(@Operation=13)
BEGIN
select 
Inv_ContainerProjects.id as ContainerProjectid,
Inv_ContainerProjects.JobID AS jobid, 
Inv_ContainerProjects.[Description],Inv_ContainerProjects.Requester,
Inv_ContainerProjects.Qty as qty,Inv_ContainerProjects.Remarks as remarks
from Inv_ContainerProjects
WHERE Inv_ContainerProjects.ContainerID=@Containerid
Order by jobid
END

ELSE IF(@Operation=14)
BEGIN
	DELETE Inv_ContainerProjects WHERE id=@ContainerProjectsID

	INSERT INTO [dbo].[Inv_ContainerProjectLogs]
	([ContainerId], [DeletedDate], [DeletedBy])
	VALUES
	(@Containerid,GETDATE(),@LoginUserId)
END

ELSE IF(@Operation=15)
BEGIN
		SELECT tblProjects.JobID AS ProjectID,
		CONCAT(tblCustomers.CompanyName + ', ', tblCustomers.City + ', ', tblStates.[State] + ', ', tblCountries.Country) as ProjectName
		FROM tblProjects
		INNER JOIN tblCustomers ON tblCustomers.CustomerID=tblProjects.CustomerID
		LEFT JOIN tblStates ON tblStates.StateID=tblCustomers.StateID
		LEFT JOIN tblCountries ON tblCountries.CountryID=tblCustomers.CountryID
		WHERE tblProjects.JobID=@JobID

END
ELSE IF(@Operation=16)
BEGIN
		SELECT EmployeeID,
		CONCAT(FirstName + ' ', LastName) AS ApprovedBy
		FROM tblEmployees 
		WHERE EmployeeID IN (110,44)
		Order by FirstName,LastName asc	

END
ELSE IF(@Operation=17)
BEGIN
	SELECT UploadDocument FROM Inv_Container WHERE Inv_Container.id=@Containerid
END

ELSE IF(@Operation=18)
BEGIN
	SELECT 
	Inv_Container.Sourceid as Vendor,
	Inv_Container.WareHouseID as Warehouse,
	Inv_Container.InvoiceNo,
	Inv_Container.SealNo,
	Inv_Container.TentativeSentDate,
	Inv_Container.ApprovedBy,
	Inv_Container.Shipmentby
	FROM Inv_Container WHERE Inv_Container.id=@Containerid
END
--Container Job Operations End

ELSE IF(@Operation=19)
BEGIN
	DECLARE @EmployeeCountryID TABLE (
	WareHouseID	 INT,
	EmployeeID	 INT,
	CountryID    INT,
	Access		 INT,
	WarehouseName Varchar(50),
	SetPermission INT
)
INSERT INTO @EmployeeCountryID
SELECT Inv_Warehouse.Id AS WareHouseID,EmployeeID,Inv_EmployeeContainerAccess.CountryID,ContainerAccess,WarehouseName,NULL 
FROM Inv_EmployeeContainerAccess 
INNER JOIN Inv_Warehouse ON Inv_Warehouse.CountryId=Inv_EmployeeContainerAccess.CountryID
WHERE EmployeeID=@EmployeeID AND ContainerAccess=1

DECLARE @WareHouse_ID INT
DECLARE @Country_ID INT
DECLARE @Employee_ID INT
DECLARE @WarehouseName VARCHAR(50)
DECLARE @SetPermission INT
DECLARE [CURSOR_NAME] CURSOR	
STATIC FOR
SELECT WareHouseID,CountryID,EmployeeID,WarehouseName,SetPermission FROM @EmployeeCountryID
OPEN [CURSOR_NAME]
IF @@CURSOR_ROWS > 0
BEGIN
	FETCH NEXT FROM [CURSOR_NAME] INTO @WareHouse_ID,@Country_ID,@Employee_ID,@WarehouseName,@SetPermission
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(@Country_ID=1 AND @WarehouseName='Canada')
		BEGIN
			UPDATE @EmployeeCountryID SET SetPermission=4
			WHERE EmployeeID=@Employee_ID AND CountryID=@Country_ID AND WareHouseID=@WareHouse_ID
		END

		IF(@Country_ID=2 AND @WarehouseName='Gaffney')
		BEGIN
			UPDATE @EmployeeCountryID SET SetPermission=3 
			WHERE EmployeeID=@Employee_ID AND CountryID=@Country_ID AND WareHouseID=@WareHouse_ID
		END

		IF(@Country_ID=2 AND @WarehouseName='Caddy')
		BEGIN
			UPDATE @EmployeeCountryID SET SetPermission=5
			WHERE EmployeeID=@Employee_ID AND CountryID=@Country_ID AND WareHouseID=@WareHouse_ID
		END
		
		IF(@Country_ID=13 AND @WarehouseName='Agilent')
		BEGIN
			UPDATE @EmployeeCountryID SET SetPermission=2
			WHERE EmployeeID=@Employee_ID AND CountryID=@Country_ID AND WareHouseID=@WareHouse_ID
		END

		IF(@Country_ID=19 AND @WarehouseName='Triflex')
		BEGIN
			UPDATE @EmployeeCountryID SET SetPermission=1
			WHERE EmployeeID=@Employee_ID AND CountryID=@Country_ID AND WareHouseID=@WareHouse_ID
		END

		

	FETCH NEXT FROM [CURSOR_NAME] INTO @WareHouse_ID,@Country_ID,@Employee_ID,@WarehouseName,@SetPermission
	END
END
CLOSE [CURSOR_NAME]
DEALLOCATE [CURSOR_NAME]

SELECT Inv_Warehouse.id,Inv_Warehouse.[WarehouseName] as [Source] 
FROM Inv_Warehouse 
WHERE id IN (SELECT SetPermission FROM @EmployeeCountryID)	
Order by Inv_Warehouse.[WarehouseName] ASC
END

ELSE IF(@Operation=20)
BEGIN
		DECLARE @ContainerStatus as varchar(20)=NULL
		set @ContainerStatus=(Select MIN(CONVERT(INT, ContainerAccess)) from Inv_EmployeeContainerAccess WHERE EmployeeID=@EmployeeID GROUP BY EmployeeID)
		if(@ContainerStatus=1)
		BEGIN
		SET @msg='True'
		END
		ELSE
		BEGIN
		SET @msg='False'
		END
END	

ELSE IF(@Operation=21)
BEGIN
	INSERT INTO [dbo].[tblShipmentLogs] (Containerid,LastUpdatedDate,Comments) VALUES (@Containerid,GETDATE(),'ArrivalInAerowerksDate')

END
ELSE IF(@Operation=22)
BEGIN
	SELECT WareHouseID,[Name] FROM FilterWarehouse(@SourceID)
	Order by [Name] ASC
END
END
