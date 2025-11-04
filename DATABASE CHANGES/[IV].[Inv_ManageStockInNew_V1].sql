ELSE IF(@Operation = 9)--STOCKIN CONTAINER
	BEGIN
		BEGIN TRY 
		BEGIN TRANSACTION 
			DECLARE @WarehouseID INT
			DECLARE @PART_ID INT
			DECLARE @SHIP_QTY INT              
			DECLARE CUR_PART CURSOR            

			STATIC FOR			
			SELECT WareHouseID,PartId, SUM(ShipQty) AS ShipQty
			FROM Inv_ContainerDetail
			INNER JOIN Inv_Container ON Inv_Container.id = Inv_ContainerDetail.ContainerId			
			WHERE ContainerId = @ID AND ShipQty > 0 AND Inv_Container.ReceivedDate IS NOT NULL
			Group by WareHouseID,PartId
	
			OPEN CUR_PART

			IF @@CURSOR_ROWS > 0
			BEGIN
				FETCH NEXT FROM CUR_PART INTO @WarehouseID,@PART_ID, @SHIP_QTY

				WHILE @@FETCH_STATUS = 0
				BEGIN                                
					DECLARE @openstockT INT
					DECLARE @closestockT INT

					DECLARE @openstockinhandParts INT

					SET @openstockinhandParts=(
						SELECT ISNULL(stockinhand,0) AS stockinhand  
						FROM 
						Inv_Parts WHERE id=@PART_ID
					)

					--Update Transaction In Parts Table					
					DECLARE @UpdateStockInHand as INT=NULL

					IF EXISTS(SELECT Id FROM Inv_Parts_StockInHand WHERE PartId = @PART_ID AND WarehouseId = @WarehouseID)
					BEGIN
					SET @openstockT = (SELECT TOP 1 ISNULL(Inv_Parts_StockInHand.[stockinhand],0) FROM  Inv_Parts_StockInHand 
					WHERE Inv_Parts_StockInHand.PartId=@PART_ID AND WarehouseId=@WarehouseID)
					END
					ELSE
					BEGIN
					SET @openstockT=NULL
					END
					
					IF(@SHIP_QTY > 0)
					BEGIN
						SET @closestockT = (ISNULL(@openstockT,0) + ABS(@SHIP_QTY))
					END			
					

								 
					INSERT INTO Inv_StockTransactions
					([partid], [openingstock], [transactqty], [closingstock], 
					[transactdatetime], [transactsummary], 
					[transactby], [transactmode],WarehouseId)
					VALUES
					(@PART_ID, ISNULL(@openstockT,0), @SHIP_QTY, @closestockT, GETDATE(), 'Container Stock In', '263', 'A',@WarehouseID)


					IF EXISTS(SELECT PartId FROM Inv_Parts_StockInHand WHERE PartId=@PART_ID AND WarehouseId=@WarehouseID)
					BEGIN
						UPDATE Inv_Parts_StockInHand SET PartId=@PART_ID,
						StockInHand=@closestockT,
						UpdatedByUser=@EmployeeID,UpdatedDate=GETDATE(),
						WarehouseId=@WarehouseID
						WHERE PartId=@PART_ID AND WarehouseId=@WarehouseID							
						
					END
					ELSE
					BEGIN
						INSERT INTO Inv_Parts_StockInHand (
						PartId,WarehouseId,StockInHand,
						InsertedDate,InsertedByUser,
						UpdatedDate,UpdatedByUser)
						VALUES(
						@PART_ID,@WarehouseID,@closestockT,
						GETDATE(),@EmployeeID,
						NULL,NULL)						
					END	
					

					UPDATE Inv_Parts SET stockinhand=ISNULL(@openstockinhandParts,0) + ISNULL(@SHIP_QTY,0)
					WHERE id=@PART_ID
													 								 
					FETCH NEXT FROM CUR_PART INTO @WarehouseID,@PART_ID, @SHIP_QTY
				END
			END
              
			CLOSE CUR_PART
			DEALLOCATE CUR_PART


			UPDATE Inv_Container SET IsStockIn = 1 WHERE id = @ID

			INSERT INTO [dbo].[Inv_ContainerLogs]
			([ContainerId], [ReceivedDate], [ReceivedBy])
			VALUES
			(@ID, GETDATE(), @EmployeeID)						

			IF @@TRANCOUNT > 0
			COMMIT
		
			SET @msg = 'Stock In Successfull !!'	 
		END TRY

		BEGIN CATCH 
			IF @@TRANCOUNT > 0
				ROLLBACK
			  --SELECT ERROR_NUMBER() AS ErrorNumber
			  --SELECT ERROR_MESSAGE() AS ErrorMessage		
		   END CATCH
	END