CREATE PROCEDURE test.test_Given_ProductTableHasItems_When_ExecuteTotalSales_Then_ResturnsCorrectResult
AS
BEGIN
----Arrange
	EXEC tSQLt.FakeTable @TableName = 'dbo.Products', @Identity = true;

	INSERT INTO dbo.Products (Name, TotalSale)
	VALUES	('Butter', 100),
			('Car', 200);

----Act
	DECLARE @actualTotalSales decimal = dbo.AllTotalSales();

----Assert
	EXEC tSQLt.assertEquals 300, @actualTotalSales;
END
