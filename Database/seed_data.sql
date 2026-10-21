/* OPTIONAL fictional Sri Lankan bookstore dataset; amounts represent sample LKR.
   Real book titles/authors; generated ISBN-format identifiers, prices, contacts,
   people, companies and transactions. Not recovered business records.
   Edit login passwords before use. All nine tables must be empty.
   No deletes, updates to existing data, IDENTITY_INSERT, or identity resets.
*/
USE [BookHeaven];
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    IF EXISTS (SELECT 1 FROM dbo.Users)
       OR EXISTS (SELECT 1 FROM dbo.Books)
       OR EXISTS (SELECT 1 FROM dbo.Customers)
       OR EXISTS (SELECT 1 FROM dbo.Suppliers)
       OR EXISTS (SELECT 1 FROM dbo.Sales)
       OR EXISTS (SELECT 1 FROM dbo.SaleDetails)
       OR EXISTS (SELECT 1 FROM dbo.Orders)
       OR EXISTS (SELECT 1 FROM dbo.OrderDetails)
       OR EXISTS (SELECT 1 FROM dbo.InventoryRestock)
        THROW 51001, 'Full sample data requires empty tables. No records were changed.', 1;

    DECLARE @Now datetime2(0) = SYSDATETIME();
    DECLARE @CustomerMap TABLE (SeedNo int PRIMARY KEY, CustomerID int NOT NULL);
    DECLARE @SupplierMap TABLE (SeedNo int PRIMARY KEY, SupplierID int NOT NULL);
    DECLARE @BookMap TABLE (SeedNo int PRIMARY KEY, BookID int NOT NULL, TargetStock int NOT NULL);

    INSERT dbo.Users (Username, Email, Phone, Password, Role) VALUES
    (N'admin', N'admin@bookhaven.example.com', N'0772145617', N'BookHaven-Admin-2026!', N'Admin'),
    (N'manager', N'manager@bookhaven.example.com', N'0772145934', N'BookHaven-Admin-2026!', N'Admin'),
    (N'clerk', N'clerk@bookhaven.example.com', N'0772146251', N'BookHaven-Staff-2026!', N'Staff'),
    (N'nimali', N'nimali@bookhaven.example.com', N'0772146568', N'BookHaven-Staff-2026!', N'Staff'),
    (N'arjun', N'arjun@bookhaven.example.com', N'0772146885', N'BookHaven-Staff-2026!', N'Staff'),
    (N'farah', N'farah@bookhaven.example.com', N'0772147202', N'BookHaven-Staff-2026!', N'Staff');

    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Nimal Perera', N'nimal.perera@example.com', N'0713423539', N'20, Temple Road, Colombo');
    INSERT @CustomerMap VALUES (1, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Dilini Fernando', N'dilini.fernando@example.com', N'0723425278', N'23, Lake Road, Kandy');
    INSERT @CustomerMap VALUES (2, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Kasun Silva', N'kasun.silva@example.com', N'0753427017', N'26, Lighthouse Street, Galle');
    INSERT @CustomerMap VALUES (3, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Tharushi Jayasinghe', N'tharushi.jayasinghe@example.com', N'0763428756', N'29, St. Joseph Road, Negombo');
    INSERT @CustomerMap VALUES (4, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Dinesh Wickramasinghe', N'dinesh.wickramasinghe@example.com', N'0773430495', N'32, Beach Road, Matara');
    INSERT @CustomerMap VALUES (5, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Sanduni Rajapaksha', N'sanduni.rajapaksha@example.com', N'0783432234', N'35, Kandy Road, Kurunegala');
    INSERT @CustomerMap VALUES (6, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Chamath Gunawardena', N'chamath.gunawardena@example.com', N'0713433973', N'38, Palaly Road, Jaffna');
    INSERT @CustomerMap VALUES (7, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Hiruni Senanayake', N'hiruni.senanayake@example.com', N'0723435712', N'41, Station Road, Batticaloa');
    INSERT @CustomerMap VALUES (8, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Ravindu Wijesinghe', N'ravindu.wijesinghe@example.com', N'0753437451', N'44, Church Road, Gampaha');
    INSERT @CustomerMap VALUES (9, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Ishara Bandara', N'ishara.bandara@example.com', N'0763439190', N'47, Pagoda Road, Nugegoda');
    INSERT @CustomerMap VALUES (10, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Arjun Ramanathan', N'arjun.ramanathan@example.com', N'0773440929', N'50, Temple Road, Colombo');
    INSERT @CustomerMap VALUES (11, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Priya Sivakumar', N'priya.sivakumar@example.com', N'0783442668', N'53, Lake Road, Kandy');
    INSERT @CustomerMap VALUES (12, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Kavin Nadarajah', N'kavin.nadarajah@example.com', N'0713444407', N'56, Lighthouse Street, Galle');
    INSERT @CustomerMap VALUES (13, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Anjali Balasubramaniam', N'anjali.balasubramaniam@example.com', N'0723446146', N'59, St. Joseph Road, Negombo');
    INSERT @CustomerMap VALUES (14, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Farhan Rahman', N'farhan.rahman@example.com', N'0753447885', N'62, Beach Road, Matara');
    INSERT @CustomerMap VALUES (15, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Ayesha Hassan', N'ayesha.hassan@example.com', N'0763449624', N'65, Kandy Road, Kurunegala');
    INSERT @CustomerMap VALUES (16, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Imran Ahamed', N'imran.ahamed@example.com', N'0773451363', N'68, Palaly Road, Jaffna');
    INSERT @CustomerMap VALUES (17, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Fathima Nazeer', N'fathima.nazeer@example.com', N'0783453102', N'71, Station Road, Batticaloa');
    INSERT @CustomerMap VALUES (18, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Sahan Dissanayake', N'sahan.dissanayake@example.com', N'0713454841', N'74, Church Road, Gampaha');
    INSERT @CustomerMap VALUES (19, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Dinithi Karunaratne', N'dinithi.karunaratne@example.com', N'0723456580', N'77, Pagoda Road, Nugegoda');
    INSERT @CustomerMap VALUES (20, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Malith Abeysekara', N'malith.abeysekara@example.com', N'0753458319', N'80, Temple Road, Colombo');
    INSERT @CustomerMap VALUES (21, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Pavithra Herath', N'pavithra.herath@example.com', N'0763460058', N'83, Lake Road, Kandy');
    INSERT @CustomerMap VALUES (22, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Navin Dias', N'navin.dias@example.com', N'0773461797', N'86, Lighthouse Street, Galle');
    INSERT @CustomerMap VALUES (23, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Shanika De Alwis', N'shanika.de.alwis@example.com', N'0783463536', N'89, St. Joseph Road, Negombo');
    INSERT @CustomerMap VALUES (24, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Roshan Mendis', N'roshan.mendis@example.com', N'0713465275', N'92, Beach Road, Matara');
    INSERT @CustomerMap VALUES (25, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Amaya De Silva', N'amaya.de.silva@example.com', N'0723467014', N'95, Kandy Road, Kurunegala');
    INSERT @CustomerMap VALUES (26, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Isuru Samarakoon', N'isuru.samarakoon@example.com', N'0753468753', N'98, Palaly Road, Jaffna');
    INSERT @CustomerMap VALUES (27, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Nethmi Ekanayake', N'nethmi.ekanayake@example.com', N'0763470492', N'101, Station Road, Batticaloa');
    INSERT @CustomerMap VALUES (28, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Thilina Weerasinghe', N'thilina.weerasinghe@example.com', N'0773472231', N'104, Church Road, Gampaha');
    INSERT @CustomerMap VALUES (29, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Customers (Name, Email, Phone, Address) VALUES (N'Sachini Madushika', N'sachini.madushika@example.com', N'0783473970', N'107, Pagoda Road, Nugegoda');
    INSERT @CustomerMap VALUES (30, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Suppliers (Name, Email, Phone) VALUES (N'Serendib Book Distribution', N'orders@serendibbookdistribution.example.com', N'0112364531');
    INSERT @SupplierMap VALUES (1, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Suppliers (Name, Email, Phone) VALUES (N'Hill Country Literary Supply', N'orders@hillcountryliterarysupply.example.com', N'0112364962');
    INSERT @SupplierMap VALUES (2, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Suppliers (Name, Email, Phone) VALUES (N'Southern Readers Wholesale', N'orders@southernreaderswholesale.example.com', N'0112365393');
    INSERT @SupplierMap VALUES (3, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Suppliers (Name, Email, Phone) VALUES (N'Northern Pages Distribution', N'orders@northernpagesdistribution.example.com', N'0112365824');
    INSERT @SupplierMap VALUES (4, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Suppliers (Name, Email, Phone) VALUES (N'Lanka Academic Books', N'orders@lankaacademicbooks.example.com', N'0112366255');
    INSERT @SupplierMap VALUES (5, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Suppliers (Name, Email, Phone) VALUES (N'Coastal Classics Supply', N'orders@coastalclassicssupply.example.com', N'0112366686');
    INSERT @SupplierMap VALUES (6, CONVERT(int, SCOPE_IDENTITY()));
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Pride and Prejudice', N'Jane Austen', N'Classic', N'9789558100011', 1500.00, 11);
    INSERT @BookMap VALUES (1, CONVERT(int, SCOPE_IDENTITY()), 11);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Time Machine', N'H. G. Wells', N'Fiction', N'9789558100028', 1200.00, 2);
    INSERT @BookMap VALUES (2, CONVERT(int, SCOPE_IDENTITY()), 2);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Treasure Island', N'Robert Louis Stevenson', N'Adventure', N'9789558100035', 1000.00, 13);
    INSERT @BookMap VALUES (3, CONVERT(int, SCOPE_IDENTITY()), 13);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Nineteen Eighty-Four', N'George Orwell', N'Dystopian', N'9789558100042', 1850.00, 14);
    INSERT @BookMap VALUES (4, CONVERT(int, SCOPE_IDENTITY()), 14);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Animal Farm', N'George Orwell', N'Classic', N'9789558100059', 1250.00, 1);
    INSERT @BookMap VALUES (5, CONVERT(int, SCOPE_IDENTITY()), 1);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Jane Eyre', N'Charlotte Brontë', N'Classic', N'9789558100066', 1750.00, 16);
    INSERT @BookMap VALUES (6, CONVERT(int, SCOPE_IDENTITY()), 16);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Wuthering Heights', N'Emily Brontë', N'Romance', N'9789558100073', 1650.00, 0);
    INSERT @BookMap VALUES (7, CONVERT(int, SCOPE_IDENTITY()), 0);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Great Expectations', N'Charles Dickens', N'Classic', N'9789558100080', 1900.00, 18);
    INSERT @BookMap VALUES (8, CONVERT(int, SCOPE_IDENTITY()), 18);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'A Tale of Two Cities', N'Charles Dickens', N'Historical Fiction', N'9789558100097', 1800.00, 19);
    INSERT @BookMap VALUES (9, CONVERT(int, SCOPE_IDENTITY()), 19);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Oliver Twist', N'Charles Dickens', N'Classic', N'9789558100103', 1550.00, 20);
    INSERT @BookMap VALUES (10, CONVERT(int, SCOPE_IDENTITY()), 20);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Little Women', N'Louisa May Alcott', N'Coming-of-age', N'9789558100110', 1700.00, 3);
    INSERT @BookMap VALUES (11, CONVERT(int, SCOPE_IDENTITY()), 3);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Secret Garden', N'Frances Hodgson Burnett', N'Fiction', N'9789558100127', 1350.00, 22);
    INSERT @BookMap VALUES (12, CONVERT(int, SCOPE_IDENTITY()), 22);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Adventures of Tom Sawyer', N'Mark Twain', N'Adventure', N'9789558100134', 1400.00, 23);
    INSERT @BookMap VALUES (13, CONVERT(int, SCOPE_IDENTITY()), 23);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Adventures of Huckleberry Finn', N'Mark Twain', N'Adventure', N'9789558100141', 1550.00, 24);
    INSERT @BookMap VALUES (14, CONVERT(int, SCOPE_IDENTITY()), 24);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Jungle Book', N'Rudyard Kipling', N'Adventure', N'9789558100158', 1450.00, 25);
    INSERT @BookMap VALUES (15, CONVERT(int, SCOPE_IDENTITY()), 25);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Alice in Wonderland', N'Lewis Carroll', N'Fantasy', N'9789558100165', 1300.00, 26);
    INSERT @BookMap VALUES (16, CONVERT(int, SCOPE_IDENTITY()), 26);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Through the Looking-Glass', N'Lewis Carroll', N'Fantasy', N'9789558100172', 1350.00, 1);
    INSERT @BookMap VALUES (17, CONVERT(int, SCOPE_IDENTITY()), 1);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Wonderful Wizard of Oz', N'L. Frank Baum', N'Fantasy', N'9789558100189', 1450.00, 10);
    INSERT @BookMap VALUES (18, CONVERT(int, SCOPE_IDENTITY()), 10);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Dracula', N'Bram Stoker', N'Fiction', N'9789558100196', 1950.00, 0);
    INSERT @BookMap VALUES (19, CONVERT(int, SCOPE_IDENTITY()), 0);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Frankenstein', N'Mary Shelley', N'Fiction', N'9789558100202', 1750.00, 12);
    INSERT @BookMap VALUES (20, CONVERT(int, SCOPE_IDENTITY()), 12);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Picture of Dorian Gray', N'Oscar Wilde', N'Psychological Fiction', N'9789558100219', 1650.00, 13);
    INSERT @BookMap VALUES (21, CONVERT(int, SCOPE_IDENTITY()), 13);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Great Gatsby', N'F. Scott Fitzgerald', N'Classic', N'9789558100226', 1500.00, 14);
    INSERT @BookMap VALUES (22, CONVERT(int, SCOPE_IDENTITY()), 14);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Call of the Wild', N'Jack London', N'Adventure', N'9789558100233', 1100.00, 3);
    INSERT @BookMap VALUES (23, CONVERT(int, SCOPE_IDENTITY()), 3);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'White Fang', N'Jack London', N'Adventure', N'9789558100240', 1350.00, 16);
    INSERT @BookMap VALUES (24, CONVERT(int, SCOPE_IDENTITY()), 16);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The War of the Worlds', N'H. G. Wells', N'Fiction', N'9789558100257', 1550.00, 17);
    INSERT @BookMap VALUES (25, CONVERT(int, SCOPE_IDENTITY()), 17);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Invisible Man', N'H. G. Wells', N'Fiction', N'9789558100264', 1450.00, 18);
    INSERT @BookMap VALUES (26, CONVERT(int, SCOPE_IDENTITY()), 18);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Sense and Sensibility', N'Jane Austen', N'Romance', N'9789558100271', 1700.00, 19);
    INSERT @BookMap VALUES (27, CONVERT(int, SCOPE_IDENTITY()), 19);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Emma', N'Jane Austen', N'Romance', N'9789558100288', 1800.00, 20);
    INSERT @BookMap VALUES (28, CONVERT(int, SCOPE_IDENTITY()), 20);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'Persuasion', N'Jane Austen', N'Romance', N'9789558100295', 1550.00, 1);
    INSERT @BookMap VALUES (29, CONVERT(int, SCOPE_IDENTITY()), 1);
    INSERT dbo.Books (Title, Author, Genre, ISBN, Price, Stock) VALUES (N'The Railway Children', N'E. Nesbit', N'Fiction', N'9789558100301', 1250.00, 22);
    INSERT @BookMap VALUES (30, CONVERT(int, SCOPE_IDENTITY()), 22);

    -- Generate 240 sales over 120 days, with an explicit same-day sale.
    -- Header totals equal the sum of rounded, discounted line totals.
    DECLARE @n int = 1, @j int, @Lines int, @SaleID int, @CustomerID int,
            @BookID int, @Price decimal(18,2), @Quantity int,
            @Discount decimal(5,2), @LineTotal decimal(18,2);
    WHILE @n <= 240
    BEGIN
        SELECT @CustomerID = CustomerID FROM @CustomerMap WHERE SeedNo = 1 + ((@n * 7) % 30);
        IF @n % 11 = 0 SET @CustomerID = NULL; -- Walk-in sales.
        SET @Discount = CASE WHEN @n % 10 = 0 THEN 10 WHEN @n % 4 = 0 THEN 5 ELSE 0 END;
        INSERT dbo.Sales (CustomerID, SaleDate, Discount, Total)
        VALUES (@CustomerID, DATEADD(day, -((@n - 1) % 120), @Now), @Discount, 0);
        SET @SaleID = CONVERT(int, SCOPE_IDENTITY());
        SET @Lines = 1 + (@n % 4);
        SET @j = 1;
        WHILE @j <= @Lines
        BEGIN
            -- Weighted demand makes selected titles best sellers.
            SELECT @BookID = BookID FROM @BookMap
            WHERE SeedNo = CASE WHEN @j = 1 AND @n % 3 = 0 THEN 1
                                WHEN @j = 1 AND @n % 5 = 0 THEN 4
                                ELSE 1 + ((@n * 7 + @j * 11) % 30) END;
            SELECT @Price = Price FROM dbo.Books WHERE BookID = @BookID;
            SET @Quantity = CASE WHEN (@n + @j) % 9 = 0 THEN 3
                                 WHEN (@n + @j) % 4 = 0 THEN 2 ELSE 1 END;
            SET @LineTotal = ROUND(@Price * @Quantity * (1 - @Discount / 100.0), 2);
            INSERT dbo.SaleDetails (SaleID, BookID, Quantity, Price, Total)
            VALUES (@SaleID, @BookID, @Quantity, @Price, @LineTotal);
            SET @j += 1;
        END;
        UPDATE dbo.Sales SET Total = (SELECT SUM(Total) FROM dbo.SaleDetails WHERE SaleID = @SaleID)
        WHERE SaleID = @SaleID;
        SET @n += 1;
    END;

    -- Orders remain separate from sales/inventory, matching the existing UI.
    DECLARE @OrderID int;
    SET @n = 1;
    WHILE @n <= 36
    BEGIN
        SELECT @CustomerID = CustomerID FROM @CustomerMap WHERE SeedNo = 1 + ((@n * 11) % 30);
        INSERT dbo.Orders (CustomerID, OrderDate, Status, DeliveryMethod)
        VALUES (@CustomerID,
                DATEADD(day, -(CASE WHEN @n <= 12 THEN @n % 5 ELSE 7 + @n END), @Now),
                CASE WHEN @n <= 12 THEN N'Pending' WHEN @n <= 30 THEN N'Completed' ELSE N'Cancelled' END,
                CASE WHEN @n % 2 = 0 THEN N'Delivery' ELSE N'Pickup' END);
        SET @OrderID = CONVERT(int, SCOPE_IDENTITY());
        SET @j = 1;
        WHILE @j <= 1 + (@n % 3)
        BEGIN
            SELECT @BookID = BookID FROM @BookMap WHERE SeedNo = 1 + ((@n * 3 + @j * 7) % 30);
            SELECT @Price = Price FROM dbo.Books WHERE BookID = @BookID;
            INSERT dbo.OrderDetails (OrderID, BookID, Quantity, Price)
            VALUES (@OrderID, @BookID, 1 + ((@n + @j) % 2), @Price);
            SET @j += 1;
        END;
        SET @n += 1;
    END;

    DECLARE @SupplierID int;
    SET @n = 1;
    WHILE @n <= 18
    BEGIN
        SELECT @SupplierID = SupplierID FROM @SupplierMap WHERE SeedNo = 1 + ((@n - 1) % 6);
        SELECT @BookID = BookID FROM @BookMap
        WHERE SeedNo = CASE WHEN @n <= 6 THEN
                          CASE @n WHEN 1 THEN 2 WHEN 2 THEN 5 WHEN 3 THEN 7
                                  WHEN 4 THEN 11 WHEN 5 THEN 19 ELSE 23 END
                          ELSE 1 + ((@n * 7) % 30) END;
        INSERT dbo.InventoryRestock (SupplierID, BookID, Quantity, RestockDate, Status)
        VALUES (@SupplierID, @BookID, CASE WHEN @n <= 6 THEN 20 ELSE 5 END,
                DATEADD(day, -(CASE WHEN @n BETWEEN 7 AND 12 THEN 130 ELSE @n % 7 END), @Now),
                CASE WHEN @n <= 6 THEN N'Pending' WHEN @n <= 12 THEN N'Received' ELSE N'Canceled' END);
        SET @n += 1;
    END;

    -- Reconstruct plausible opening inventory, then apply receipts and sales once.
    -- Received restocks precede the entire sales history. TargetStock is closing stock.
    DECLARE @Opening TABLE (BookID int PRIMARY KEY, OpeningStock int NOT NULL);
    INSERT @Opening (BookID, OpeningStock)
    SELECT m.BookID, m.TargetStock
        + COALESCE((SELECT SUM(Quantity) FROM dbo.SaleDetails d WHERE d.BookID = m.BookID), 0)
        - COALESCE((SELECT SUM(Quantity) FROM dbo.InventoryRestock r
                    WHERE r.BookID = m.BookID AND r.Status = N'Received'), 0)
    FROM @BookMap m;
    IF EXISTS (SELECT 1 FROM @Opening WHERE OpeningStock < 0)
        THROW 51006, 'Generated opening inventory would be negative.', 1;
    UPDATE b SET Stock = o.OpeningStock
        + COALESCE((SELECT SUM(Quantity) FROM dbo.InventoryRestock r
                    WHERE r.BookID = b.BookID AND r.Status = N'Received'), 0)
        - COALESCE((SELECT SUM(Quantity) FROM dbo.SaleDetails d WHERE d.BookID = b.BookID), 0)
    FROM dbo.Books b JOIN @Opening o ON o.BookID = b.BookID;

    IF EXISTS (SELECT 1 FROM dbo.Sales s
               WHERE s.Total <> (SELECT SUM(d.Total) FROM dbo.SaleDetails d WHERE d.SaleID = s.SaleID))
        THROW 51007, 'Generated sale totals are inconsistent.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Books b JOIN @BookMap m ON m.BookID = b.BookID
               WHERE b.Stock <> m.TargetStock)
        THROW 51008, 'Generated inventory balance is inconsistent.', 1;

    COMMIT TRANSACTION;
    SELECT N'Users' AS Entity, COUNT(*) AS Records FROM dbo.Users
    UNION ALL SELECT N'Books', COUNT(*) FROM dbo.Books
    UNION ALL SELECT N'Customers', COUNT(*) FROM dbo.Customers
    UNION ALL SELECT N'Suppliers', COUNT(*) FROM dbo.Suppliers
    UNION ALL SELECT N'Sales', COUNT(*) FROM dbo.Sales
    UNION ALL SELECT N'SaleDetails', COUNT(*) FROM dbo.SaleDetails
    UNION ALL SELECT N'Orders', COUNT(*) FROM dbo.Orders
    UNION ALL SELECT N'OrderDetails', COUNT(*) FROM dbo.OrderDetails
    UNION ALL SELECT N'InventoryRestock', COUNT(*) FROM dbo.InventoryRestock;
    PRINT 'Full fictional bookstore dataset created successfully.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
