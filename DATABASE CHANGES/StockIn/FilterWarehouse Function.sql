CREATE FUNCTION [dbo].[FilterWarehouse] 
(	
	-- Add the parameters for the function here
	@SourceID		INT
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT Id as WareHouseID,
	WarehouseName as [Name] 
	FROM Inv_Warehouse Where Id <> @SourceID
)