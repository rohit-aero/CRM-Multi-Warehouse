ELSE IF(@Operation = 8)
	BEGIN	

		IF(@userid IN (280,309,340))
		BEGIN			
			--Table 0 For Agilent
			Select 2 AS WareHouse

			--Table 1 Bind Data
			SELECT id, WarehouseName AS [text]
			FROM Inv_Warehouse Where id=2
			ORDER BY WarehouseName
		END
		ELSE IF(@userid IN (335))
		BEGIN		
			--Table 0 For Triflex
			Select 1 AS WareHouse

			--Table 1 For Bind Data
			SELECT id, WarehouseName AS [text]
			FROM Inv_Warehouse Where id=1
			ORDER BY WarehouseName
		END
		ELSE
		BEGIN
			--Table 0 For All
			Select 0 as WareHouse

			--Table 1 For Bind Data
			SELECT id, WarehouseName AS [text]
			FROM Inv_Warehouse 
			ORDER BY WarehouseName
		END

	END