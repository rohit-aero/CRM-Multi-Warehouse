ALTER TABLE Inv_PurchaseOrder_Manual 
ADD WareHouseID INT

UPDATE Inv_PurchaseOrder_Manual SET [WareHouseID]=4

ALTER TABLE Inv_Container
ADD WareHouseID INT

UPDATE Inv_Container SET [WareHouseID]=4