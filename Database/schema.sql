/* BookHaven reconstructed schema. Run the entire script in SSMS.
   Creates BookHeaven if absent. Requires an EMPTY user-table database.
   Never drops or replaces existing tables. No accounts are seeded here.
   Reconstructed from source; data types and lengths are design choices.
*/
USE master;
GO
IF DB_ID(N'BookHeaven') IS NULL
    EXEC(N'CREATE DATABASE [BookHeaven]');
GO
USE [BookHeaven];
GO
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    IF EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)
        THROW 51000, 'Installation requires an empty database. Existing tables were left unchanged.', 1;

    CREATE TABLE dbo.Users
    (
        UserID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
        Username nvarchar(100) NOT NULL CONSTRAINT UQ_Users_Username UNIQUE,
        Email nvarchar(254) NOT NULL CONSTRAINT DF_Users_Email DEFAULT (N''),
        Phone nvarchar(30) NOT NULL CONSTRAINT DF_Users_Phone DEFAULT (N''),
        Password nvarchar(256) COLLATE Latin1_General_100_BIN2 NOT NULL,
        Role nvarchar(20) NOT NULL,
        CONSTRAINT CK_Users_Role CHECK (Role IN (N'Admin', N'Staff'))
    );

    CREATE TABLE dbo.Books
    (
        BookID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Books PRIMARY KEY,
        Title nvarchar(300) NOT NULL,
        Author nvarchar(200) NOT NULL,
        Genre nvarchar(100) NOT NULL,
        ISBN nvarchar(32) NOT NULL,
        Price decimal(18,2) NOT NULL,
        Stock int NOT NULL CONSTRAINT DF_Books_Stock DEFAULT (0),
        CONSTRAINT CK_Books_Price CHECK (Price >= 0),
        CONSTRAINT CK_Books_Stock CHECK (Stock >= 0)
    );

    CREATE TABLE dbo.Customers
    (
        CustomerID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Customers PRIMARY KEY,
        Name nvarchar(200) NOT NULL,
        Email nvarchar(254) NOT NULL CONSTRAINT DF_Customers_Email DEFAULT (N''),
        Phone nvarchar(30) NOT NULL CONSTRAINT DF_Customers_Phone DEFAULT (N''),
        Address nvarchar(1000) NOT NULL CONSTRAINT DF_Customers_Address DEFAULT (N'')
    );

    CREATE TABLE dbo.Suppliers
    (
        SupplierID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Suppliers PRIMARY KEY,
        Name nvarchar(200) NOT NULL,
        Email nvarchar(254) NOT NULL CONSTRAINT DF_Suppliers_Email DEFAULT (N''),
        Phone nvarchar(30) NOT NULL CONSTRAINT DF_Suppliers_Phone DEFAULT (N'')
    );

    CREATE TABLE dbo.Sales
    (
        SaleID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Sales PRIMARY KEY,
        CustomerID int NULL,
        SaleDate datetime2(0) NOT NULL CONSTRAINT DF_Sales_SaleDate DEFAULT (SYSDATETIME()),
        Discount decimal(5,2) NOT NULL CONSTRAINT DF_Sales_Discount DEFAULT (0),
        Total decimal(18,2) NOT NULL,
        CONSTRAINT FK_Sales_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID),
        CONSTRAINT CK_Sales_Discount CHECK (Discount BETWEEN 0 AND 100),
        CONSTRAINT CK_Sales_Total CHECK (Total >= 0)
    );

    CREATE TABLE dbo.SaleDetails
    (
        SaleDetailID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_SaleDetails PRIMARY KEY,
        SaleID int NOT NULL,
        BookID int NOT NULL,
        Quantity int NOT NULL,
        Price decimal(18,2) NOT NULL,
        Total decimal(18,2) NOT NULL,
        CONSTRAINT FK_SaleDetails_Sales FOREIGN KEY (SaleID) REFERENCES dbo.Sales(SaleID),
        CONSTRAINT FK_SaleDetails_Books FOREIGN KEY (BookID) REFERENCES dbo.Books(BookID),
        CONSTRAINT CK_SaleDetails_Quantity CHECK (Quantity > 0),
        CONSTRAINT CK_SaleDetails_Price CHECK (Price >= 0),
        CONSTRAINT CK_SaleDetails_Total CHECK (Total >= 0)
    );

    CREATE TABLE dbo.Orders
    (
        OrderID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Orders PRIMARY KEY,
        CustomerID int NOT NULL,
        OrderDate datetime2(0) NOT NULL CONSTRAINT DF_Orders_OrderDate DEFAULT (SYSDATETIME()),
        Status nvarchar(20) NOT NULL CONSTRAINT DF_Orders_Status DEFAULT (N'Pending'),
        DeliveryMethod nvarchar(20) NOT NULL CONSTRAINT DF_Orders_DeliveryMethod DEFAULT (N'Pickup'),
        CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID),
        CONSTRAINT CK_Orders_Status CHECK (Status IN (N'Pending', N'Completed', N'Cancelled')),
        CONSTRAINT CK_Orders_DeliveryMethod CHECK (DeliveryMethod IN (N'Pickup', N'Delivery'))
    );

    CREATE TABLE dbo.OrderDetails
    (
        OrderDetailID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_OrderDetails PRIMARY KEY,
        OrderID int NOT NULL,
        BookID int NOT NULL,
        Quantity int NOT NULL,
        Price decimal(18,2) NOT NULL,
        CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderID) REFERENCES dbo.Orders(OrderID),
        CONSTRAINT FK_OrderDetails_Books FOREIGN KEY (BookID) REFERENCES dbo.Books(BookID),
        CONSTRAINT CK_OrderDetails_Quantity CHECK (Quantity > 0),
        CONSTRAINT CK_OrderDetails_Price CHECK (Price >= 0)
    );

    CREATE TABLE dbo.InventoryRestock
    (
        RestockID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_InventoryRestock PRIMARY KEY,
        SupplierID int NOT NULL,
        BookID int NOT NULL,
        Quantity int NOT NULL,
        RestockDate datetime2(0) NOT NULL CONSTRAINT DF_InventoryRestock_RestockDate DEFAULT (SYSDATETIME()),
        Status nvarchar(20) NOT NULL CONSTRAINT DF_InventoryRestock_Status DEFAULT (N'Pending'),
        CONSTRAINT FK_InventoryRestock_Suppliers FOREIGN KEY (SupplierID) REFERENCES dbo.Suppliers(SupplierID),
        CONSTRAINT FK_InventoryRestock_Books FOREIGN KEY (BookID) REFERENCES dbo.Books(BookID),
        CONSTRAINT CK_InventoryRestock_Quantity CHECK (Quantity > 0),
        CONSTRAINT CK_InventoryRestock_Status CHECK (Status IN (N'Pending', N'Received', N'Canceled'))
    );

    CREATE INDEX IX_Sales_CustomerID ON dbo.Sales (CustomerID);
    CREATE INDEX IX_Sales_SaleDate ON dbo.Sales (SaleDate);
    CREATE INDEX IX_SaleDetails_SaleID ON dbo.SaleDetails (SaleID);
    CREATE INDEX IX_SaleDetails_BookID ON dbo.SaleDetails (BookID);
    CREATE INDEX IX_Orders_CustomerID ON dbo.Orders (CustomerID);
    CREATE INDEX IX_Orders_Status ON dbo.Orders (Status);
    CREATE INDEX IX_OrderDetails_OrderID ON dbo.OrderDetails (OrderID);
    CREATE INDEX IX_OrderDetails_BookID ON dbo.OrderDetails (BookID);
    CREATE INDEX IX_InventoryRestock_SupplierID ON dbo.InventoryRestock (SupplierID);
    CREATE INDEX IX_InventoryRestock_BookID ON dbo.InventoryRestock (BookID);
    CREATE INDEX IX_InventoryRestock_Status ON dbo.InventoryRestock (Status);

    COMMIT TRANSACTION;
    PRINT 'BookHeaven schema created. Configure initial accounts using Database/seed_data.sql.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
