/* Run after schema.sql; seed data is not required.
   Test rows are rolled back. SQL Server identity counters may advance.
*/
USE [BookHeaven];
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    DECLARE @CustomerID int, @SupplierID int, @BookID int,
            @SaleID int, @OrderID int, @RestockID int;

    INSERT dbo.Customers (Name) VALUES (N'Verification customer');
    SET @CustomerID = CONVERT(int, SCOPE_IDENTITY());
    INSERT dbo.Suppliers (Name) VALUES (N'Verification supplier');
    SET @SupplierID = CONVERT(int, SCOPE_IDENTITY());
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock)
    VALUES (N'Verification book', N'Test', N'Fiction', N'TEST', 100, 3);
    SET @BookID = CONVERT(int, SCOPE_IDENTITY());

    -- Same header/line inserts and stock update used by the POS.
    INSERT dbo.Sales (CustomerID, Discount, Total) VALUES (@CustomerID, 0, 100);
    SET @SaleID = CONVERT(int, SCOPE_IDENTITY());
    INSERT dbo.SaleDetails (SaleID, BookID, Quantity, Price, Total)
    VALUES (@SaleID, @BookID, 1, 100, 100);
    UPDATE dbo.Books SET Stock = Stock - 1 WHERE BookID = @BookID;
    IF NOT EXISTS (SELECT 1 FROM dbo.Sales WHERE SaleID = @SaleID AND SaleDate IS NOT NULL)
        THROW 51002, 'Sale date default failed.', 1;

    -- Customer is deliberately optional for a sale, as in SaveSale().
    INSERT dbo.Sales (CustomerID, Discount, Total) VALUES (NULL, 0, 0);

    -- OUTPUT INSERTED must work without triggers on Orders.
    DECLARE @NewOrder TABLE (OrderID int);
    INSERT dbo.Orders (CustomerID, OrderDate, Status, DeliveryMethod)
    OUTPUT INSERTED.OrderID INTO @NewOrder
    VALUES (@CustomerID, GETDATE(), N'Pending', N'Delivery');
    SELECT @OrderID = OrderID FROM @NewOrder;
    INSERT dbo.OrderDetails (OrderID, BookID, Quantity, Price)
    VALUES (@OrderID, @BookID, 1, 100);
    UPDATE dbo.Orders SET Status = N'Completed' WHERE OrderID = @OrderID;
    UPDATE dbo.Orders SET Status = N'Cancelled' WHERE OrderID = @OrderID;

    INSERT dbo.InventoryRestock (SupplierID, BookID, Quantity, Status)
    VALUES (@SupplierID, @BookID, 5, N'Pending');
    SET @RestockID = CONVERT(int, SCOPE_IDENTITY());
    IF NOT EXISTS (SELECT 1 FROM dbo.InventoryRestock
                   WHERE RestockID = @RestockID AND RestockDate IS NOT NULL)
        THROW 51003, 'Restock date default failed.', 1;
    UPDATE dbo.InventoryRestock SET Status = N'Received' WHERE RestockID = @RestockID;
    UPDATE dbo.Books SET Stock = Stock +
        (SELECT Quantity FROM dbo.InventoryRestock WHERE RestockID = @RestockID)
    WHERE BookID = @BookID;
    UPDATE dbo.InventoryRestock SET Status = N'Canceled' WHERE RestockID = @RestockID;
    IF (SELECT Stock FROM dbo.Books WHERE BookID = @BookID) <> 7
        THROW 51004, 'Stock workflow failed.', 1;

    -- Compile/execute the relationship shape used by pending-order screens.
    SELECT o.OrderID, c.Name, b.Title, od.Quantity, od.Price, o.DeliveryMethod, o.Status
    FROM dbo.Orders o
    JOIN dbo.OrderDetails od ON o.OrderID = od.OrderID
    JOIN dbo.Books b ON od.BookID = b.BookID
    JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
    WHERE o.OrderID = @OrderID;
    SELECT SUM(sd.Total) AS TotalSales, COUNT(DISTINCT s.SaleID) AS NumberOfSales
    FROM dbo.Sales s JOIN dbo.SaleDetails sd ON s.SaleID = sd.SaleID
    WHERE s.SaleID = @SaleID AND CAST(s.SaleDate AS date) = CAST(GETDATE() AS date);

    ROLLBACK TRANSACTION;
    PRINT 'Workflow verification passed. Test rows rolled back.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

-- Isolated negative tests: each must fail with the expected constraint error.
DECLARE @NegativeTests TABLE (TestName nvarchar(100), Statement nvarchar(max), ExpectedError int);
INSERT @NegativeTests VALUES
(N'Negative stock', N'INSERT dbo.Books (Title,Author,Genre,ISBN,Price,Stock) VALUES (N''Test'',N''Test'',N''Fiction'',N''TEST'',1,-1)', 547),
(N'Invalid role', N'INSERT dbo.Users (Username,Password,Role) VALUES (CONVERT(nvarchar(36),NEWID()),N''Test'',N''Clerk'')', 547),
(N'Invalid customer reference', N'INSERT dbo.Orders (CustomerID) VALUES (-1)', 547),
(N'Zero quantity', N'DECLARE @b int, @s int; INSERT dbo.Books (Title,Author,Genre,ISBN,Price,Stock) VALUES (N''Test'',N''Test'',N''Fiction'',N''TEST'',1,1); SET @b = SCOPE_IDENTITY(); INSERT dbo.Suppliers (Name) VALUES (N''Test''); SET @s = SCOPE_IDENTITY(); INSERT dbo.InventoryRestock (SupplierID,BookID,Quantity) VALUES (@s,@b,0)', 547);
DECLARE @Name nvarchar(100), @Statement nvarchar(max), @Expected int, @Actual int;
DECLARE tests CURSOR LOCAL FAST_FORWARD FOR
    SELECT TestName, Statement, ExpectedError FROM @NegativeTests;
OPEN tests;
FETCH NEXT FROM tests INTO @Name, @Statement, @Expected;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @Actual = NULL;
    BEGIN TRANSACTION;
    BEGIN TRY
        EXEC sys.sp_executesql @Statement;
    END TRY
    BEGIN CATCH
        SET @Actual = ERROR_NUMBER();
    END CATCH;
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    IF @Actual IS NULL OR @Actual <> @Expected
    BEGIN
        CLOSE tests;
        DEALLOCATE tests;
        THROW 51005, 'A negative constraint test failed or returned an unexpected error.', 1;
    END;
    PRINT @Name + N': passed';
    FETCH NEXT FROM tests INTO @Name, @Statement, @Expected;
END;
CLOSE tests;
DEALLOCATE tests;
GO
