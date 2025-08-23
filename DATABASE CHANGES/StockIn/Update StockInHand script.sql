DECLARE @TempTable as TABLE(
	PartID	int,
	StockInHand int
	)
INSERT INTO @TempTable
SELECT id,stockinhand FROM Inv_Parts WHERE (stockinhand IS NOT NULL AND stockinhand <> 0)

			DECLARE @PartID_Cur INT
			DECLARE @StockInHand_Cur INT
			DECLARE [CURSOR_NAME] CURSOR	
			STATIC FOR
			SELECT PartId,StockInHand FROM @TempTable
			OPEN [CURSOR_NAME]
				IF @@CURSOR_ROWS > 0
				BEGIN
					FETCH NEXT FROM [CURSOR_NAME] INTO @PartID_Cur,@StockInHand_Cur
					WHILE @@FETCH_STATUS = 0
					BEGIN
						INSERT INTO Inv_Parts_StockInHand(PartId,WarehouseId,StockInHand,InsertedByUser,InsertedDate)
						VALUES(@PartID_Cur,4,@StockInHand_Cur,'263',GETDATE())

					FETCH NEXT FROM [CURSOR_NAME] INTO @PartID_Cur,@StockInHand_Cur
					END
				END
			CLOSE [CURSOR_NAME]
			DEALLOCATE [CURSOR_NAME]