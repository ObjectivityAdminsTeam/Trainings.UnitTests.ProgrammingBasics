CREATE FUNCTION dbo.AllTotalSales ()
RETURNS MONEY
AS
BEGIN
	RETURN (SELECT SUM([Products].[TotalSale]) FROM [Products])
END
