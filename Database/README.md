# BookHaven database

A SQL Server schema reconstructed from the application's C# queries. This restores the database structure required by the project; it does not recover original records. Column lengths, numeric precision, indexes, and constraint policies are inferred design decisions.

## Installation

Run the scripts in SQL Server Management Studio against your SQL Server instance, in this order:

1. **[schema.sql](schema.sql)** — creates `BookHeaven` if absent, then creates nine tables in one transaction. Requires an empty database and refuses existing user tables. No existing tables are dropped or altered. If installation fails after database creation, the empty database may remain.
2. **[seed_data.sql](seed_data.sql)** — optional full fictional bookstore dataset with accounts, catalog, contacts, sales history, customer orders, and restock history. Edit the passwords before running. Requires empty application tables and refuses to overwrite records.
3. **[verify_database.sql](verify_database.sql)** — exercises sales, orders, restocking, report joins, defaults, and constraint rejection. Test records are rolled back; identity counters may advance. Run without concurrent application activity.

Use SQL Server 2012 or later for the script syntax. Execute each file in full and stop if it reports an error. The setup account needs permission to create a database (when absent) and create tables, constraints, and indexes. The application's Windows account needs access to `BookHeaven` and CRUD permissions on its application tables; database creation permissions are not needed at runtime.

## Connect the application

The database name is **BookHeaven**, matching the source code. Update the SQL Server instance in all nine files, which currently contain their own connection strings:

- [Admin_Books.cs](../BookHaven/Admin_Books.cs)
- [Admin_Clerk.cs](../BookHaven/Admin_Clerk.cs)
- [Admin_Cus.cs](../BookHaven/Admin_Cus.cs)
- [Admin_Dash.cs](../BookHaven/Admin_Dash.cs)
- [Admin_Restock.cs](../BookHaven/Admin_Restock.cs)
- [Admin_Suppliers.cs](../BookHaven/Admin_Suppliers.cs)
- [Clerk_Customer.cs](../BookHaven/Clerk_Customer.cs)
- [Clerk_Sale.cs](../BookHaven/Clerk_Sale.cs)
- [DatabaseHelper.cs](../BookHaven/DatabaseHelper.cs)

For a local default SQL Server Express instance:

```csharp
@"Data Source=.\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True"
```

Build and run the solution after configuring the server. The optional seed script supplies:

| Login role | Username | Initial password |
| --- | --- | --- |
| Admin | `admin` | `BookHaven-Admin-2026!` |
| Staff | `clerk` | `BookHaven-Staff-2026!` |

These credentials exist only if the seed script is executed without changing them. For an empty store, skip the seed script and insert your own initial Admin account into `dbo.Users` using its `Username`, `Password`, and `Role` columns. Email and phone default to empty strings. The application currently requires plaintext passwords; use only development credentials until authentication is upgraded. Password comparisons in this schema are case-sensitive.

## Sample dataset

The expanded `seed_data.sql` populates all nine tables:

| Entity | Records |
| --- | ---: |
| Users | 6 (2 Admin, 4 Staff) |
| Books | 30 |
| Customers | 30 |
| Suppliers | 6 |
| Sales | 240 |
| Sale details | 600 |
| Customer orders | 36 |
| Order details | 72 |
| Restock requests | 18 |

Sales span the preceding 120 days relative to SQL Server's execution time, including the current day. Discounts include 0%, 5%, and 10%; some sales are walk-ins without a customer. Stored line totals include the discount and reconcile with each sale header. Prices are illustrative LKR amounts, not market quotations.

Orders include 12 pending, 18 completed, and 6 cancelled orders, with pickup and delivery represented. Restocking includes 6 pending, 6 received, and 6 canceled requests. Stock includes low-stock and out-of-stock titles. Closing stock reconciles with inferred opening stock, received restocks, and sold quantities. Opening balances are calculated inside the script rather than stored in a separate ledger. Customer orders do not change inventory, matching the application.

Book titles and authors are real. ISBN-format identifiers have valid check digits but are generated catalog values, not verified publisher assignments. People, businesses, contact details, addresses, and transactions are fictional. Emails use reserved `example.com` domains. Phone numbers and addresses follow local conventions and are not verified contact information.

The existing `admin` and `clerk` logins remain available. Additional accounts are `manager` (Admin) and `nimali`, `arjun`, and `farah` (Staff). They use the corresponding role's initial password from the credentials table above.

**If you already ran the earlier starter dataset:** this expanded script will refuse to run against those populated tables. Use a separate empty database for the full dataset, changing the `USE` database name in the scripts and the application's connection strings accordingly. Do not rerun `schema.sql` on populated tables. No reset or deletion script is included.

## Schema

| Table | Key | References | Application use |
| --- | --- | --- | --- |
| Users | UserID | — | Login and staff management |
| Books | BookID | — | Catalog, stock, and pricing |
| Customers | CustomerID | — | Customer records |
| Suppliers | SupplierID | — | Supplier records |
| Sales | SaleID | Customers (optional) | Sale header, date, percentage discount, total |
| SaleDetails | SaleDetailID | Sales, Books | Sold quantities and historical prices |
| Orders | OrderID | Customers | Order date, status, and delivery method |
| OrderDetails | OrderDetailID | Orders, Books | Ordered quantities and historical prices |
| InventoryRestock | RestockID | Suppliers, Books | Restock quantity, date, and status |

All keys are integer identities. ID columns appear first to match forms that access `Cells[0]`. Monetary amounts use `decimal(18,2)`; phone numbers and ISBNs use strings. Dates default to SQL Server's local time because the current application uses `DateTime.Now` and reports use `GETDATE()`.

Foreign keys prevent deleting books, customers, suppliers, or transaction headers that are referenced by transaction records. There are no cascading deletes. Existing UI delete actions may therefore report a database error for referenced records; this preserves transaction history.

Stock and amounts cannot be negative, quantities must be positive, and percentage discounts must be between 0 and 100. Usernames are unique. ISBNs and contact details are not unique because the existing UI does not enforce that policy. Totals remain ordinary stored columns to accept the application's explicit inserts.

Customer order statuses are `Pending`, `Completed`, and **`Cancelled`**. Restock statuses are `Pending`, `Received`, and **`Canceled`**. This difference matches the source. Delivery methods are `Pickup` and `Delivery`; roles are `Admin` and `Staff`.

## Application behavior to address separately

The schema deliberately adds no stock or total triggers: the application already updates stock during sales and restock receipt. Adding stock triggers would double-count these operations.

- **Repeated restock receipt:** The Receive action increases stock every time it is clicked, including for an already received or canceled request. The application should conditionally receive only pending requests in the same transaction.
- **Discount reporting:** `Clerk_Sale.SaveSale()` stores line totals as price × quantity, while the bill can include discounted totals. Reports sum the stored line totals, so discounted sales can be overstated. The application must define and persist consistent discount calculations.
- **Customer orders:** Creating or completing an order does not reserve or decrement inventory and does not create a sale. This script preserves that behavior.
- **Passwords:** Login and staff management store and display plaintext passwords. Password hashing requires coordinated changes to the C# code.

## Verification status

The schema was checked against the source queries. `verify_database.sql` is supplied for execution on SQL Server; execution results should be confirmed in your environment before relying on the database.
