<div align="center">

# BookHaven

### Bookstore Management System

A Windows desktop application for inventory, sales, customer orders, and store administration.

**C#** &nbsp;·&nbsp; **.NET Framework 4.7.2** &nbsp;·&nbsp; **Windows Forms** &nbsp;·&nbsp; **SQL Server**

[Installation](#installation) &nbsp;·&nbsp; [Application preview](#application-preview) &nbsp;·&nbsp; [Documentation](#documentation)

</div>

---

## Overview

BookHaven centralizes the core activities of a bookstore in a desktop workspace. Administrators manage the catalog, stock, suppliers, staff accounts, and reporting. Sales staff handle customer records, sales transactions, and pickup or delivery orders.

## Contents

- [Features](#features)
- [User roles](#user-roles)
- [Technology stack](#technology-stack)
- [Installation](#installation)
- [Application workflow](#application-workflow)
- [Application preview](#application-preview)
- [Architecture and project structure](#architecture-and-project-structure)
- [Troubleshooting](#troubleshooting)
- [Implementation notes](#implementation-notes)
- [Documentation](#documentation)
- [Author](#author)
- [License](#license)

## Features

| Module | Capabilities |
| --- | --- |
| Book inventory | Maintain book records, search the catalog, and manage prices and stock levels. |
| Customers | Manage customer details and select customers during sales and order entry. |
| Sales | Prepare itemized bills, apply percentage discounts, record transactions, update stock, and generate receipts. |
| Customer orders | Create pickup or delivery orders and update their status. |
| Suppliers and restocking | Manage suppliers, request stock for low-stock books, and receive or cancel restock requests. |
| Dashboard and reports | View store metrics, daily, weekly, and monthly sales, best-selling books, and inventory reports. |
| Staff accounts | Create, update, and remove Staff accounts from the Admin interface. |

## User roles

| Login role | Workspace |
| --- | --- |
| `Admin` | Administration dashboard, inventory, customers, suppliers, restocking, staff accounts, orders, and reports. |
| `Staff` | Sales clerk interface for sales, customers, and customer orders. |

The login screen uses **Staff** for the sales clerk role. The selected role must match the account's value in the database.

## Technology stack

| Component | Implementation |
| --- | --- |
| Language | C# |
| Desktop interface | Windows Forms |
| Target framework | .NET Framework 4.7.2 |
| Database | Microsoft SQL Server, accessed through ADO.NET (`System.Data.SqlClient`) |
| UI libraries | Bunifu UI, Guna UI, and Guna UI2 |
| Solution | `BookHaven.sln` |

## Installation

### Prerequisites

- A Windows development environment capable of running .NET Framework 4.7.2 Windows Forms applications.
- Visual Studio with the **.NET desktop development** workload and the **.NET Framework 4.7.2 targeting pack**.
- A SQL Server instance and a database management tool such as SQL Server Management Studio (SSMS).
- Compatible, appropriately licensed copies of `Bunifu_UI_v1.52.dll`, `Guna.UI.dll`, and `Guna.UI2.dll`.
- A database schema compatible with the application's SQL queries.

> **Required external dependencies:** Database scripts or backups, initial user accounts, and third-party UI assemblies are not included. Prepare these dependencies as part of the installation.

### 1. Clone and open the solution

```sh
git clone https://github.com/imzairaz/BookHaven.git
cd BookHaven
```

Open [BookHaven.sln](BookHaven.sln) in Visual Studio.

### 2. Resolve the UI library references

The references in [BookHaven.csproj](BookHaven/BookHaven.csproj) point to paths on the original developer's machine. In Visual Studio, replace unresolved references with your local copies of:

- `Bunifu_UI_v1.52`
- `Guna.UI`
- `Guna.UI2`

Use versions compatible with the existing form designer files and .NET Framework 4.7.2.

### 3. Prepare the database

Restore a compatible database if you have one, or create a schema based on the queries in the source code. The application references these tables:

| Table | Purpose |
| --- | --- |
| `Users` | Login credentials, roles, and staff details |
| `Books` | Book catalog, prices, and stock |
| `Customers` | Customer contact details |
| `Suppliers` | Supplier records |
| `Sales` and `SaleDetails` | Sales transactions and line items |
| `Orders` and `OrderDetails` | Customer orders and line items |
| `InventoryRestock` | Supplier restock requests and their status |

The table summary describes the expected entities. Use the source queries to confirm column definitions, keys, relationships, and defaults when preparing the schema.

### 4. Configure the connection

Edit `connectionString` in [DatabaseHelper.cs](BookHaven/DatabaseHelper.cs). For example, a local SQL Server Express instance using Windows authentication could use:

```csharp
private static readonly string connectionString =
    @"Data Source=.\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";
```

Set `Data Source` to your SQL Server instance and `Initial Catalog` to your database name. The source configuration uses **`BookHeaven`**. With `Integrated Security=True`, grant database access to the Windows account running the application.

The connection string is currently defined in `DatabaseHelper.cs`; `App.config` only declares the supported runtime.

### 5. Build and sign in

1. Build the solution in Visual Studio.
2. Press **F5** to start the application.
3. Select `Admin` or `Staff` and sign in with an account from your database's `Users` table.

No default credentials are supplied in this repository. An initial Admin account must be provisioned in the database before it can be used to manage Staff accounts.

## Application workflow

1. Sign in as an Admin and add books, suppliers, and customer records.
2. Create restock requests for eligible low-stock books and mark received requests to increase inventory.
3. Sign in as Staff, select a customer, and add books to a sale with the required quantities and discounts.
4. Complete the sale using the receipt action, which saves the sale and updates stock.
5. Create pickup or delivery orders as needed and maintain their status.
6. Use the Admin dashboard and reports to review sales and inventory.

## Application preview

The following screenshots illustrate the main application interfaces. Expand a section to view its screenshot.

<details>
<summary>Login</summary>

![BookHaven — login](https://github.com/user-attachments/assets/421c44f0-9b49-49d0-8c55-4f997e9f91a3)

</details>

<details>
<summary>Administration dashboard</summary>

![BookHaven — administration dashboard](https://github.com/user-attachments/assets/c5a6c2ab-9996-4816-b554-602f23abee31)

</details>

<details>
<summary>Sales staff workspace</summary>

![BookHaven — sales staff workspace](https://github.com/user-attachments/assets/ad8a847d-5d9b-4554-a960-9a54f6039858)

</details>

<details>
<summary>Inventory management</summary>

![BookHaven — inventory management](https://github.com/user-attachments/assets/532787b5-fe15-47d1-b317-13eba00af517)

</details>

<details>
<summary>Point of sale</summary>

![BookHaven — point of sale](https://github.com/user-attachments/assets/2d844aa0-7cad-4cae-a4e0-a6917dbe0dd2)

</details>

<details>
<summary>Customer management</summary>

![BookHaven — customer management](https://github.com/user-attachments/assets/a8e27061-0f02-48bc-9779-de73b3442daa)

</details>

<details>
<summary>Order management</summary>

![BookHaven — order management](https://github.com/user-attachments/assets/b7ed4e91-3f9b-490e-8eb9-8cf5935c6a77)

</details>

## Architecture and project structure

The application uses Windows Forms for presentation and ADO.NET for SQL Server access. Form classes contain workflow logic and SQL queries; `DatabaseHelper` provides a shared connection factory.

```text
BookHaven/
├── BookHaven.sln                  # Visual Studio solution
├── BookHaven/
│   ├── BookHaven.csproj           # Project settings and assembly references
│   ├── Program.cs                # Application entry point
│   ├── Loading.cs                # Startup form
│   ├── Login.cs                  # Database-backed login and role routing
│   ├── DatabaseHelper.cs         # Shared SQL Server connection factory
│   ├── Admin_*.cs                # Administration forms
│   ├── Clerk_*.cs                # Sales clerk forms
│   ├── ManageOrder.cs            # Order management form
│   ├── Resources/                # Images and interface assets
│   └── Properties/               # Application resources and settings
├── Application Development - Zai.pdf
└── README.md
```

Each form is paired with a `.Designer.cs` file for layout and a `.resx` file for resources.

## Troubleshooting

| Problem | What to check |
| --- | --- |
| Missing Guna or Bunifu types, or form designer errors | Resolve all three UI assembly references and check version compatibility. |
| Missing framework reference assemblies | Install the .NET Framework 4.7.2 targeting pack through Visual Studio Installer. |
| SQL Server connection fails | Verify the instance name, server availability, database name, and Windows account permissions. |
| Invalid object or column errors | Confirm that your database schema matches the SQL queries in the forms. |
| Login is rejected | Check that the username, password, and selected `Admin` or `Staff` role match a record in `Users`. |

## Implementation notes

- **Authentication:** Passwords are compared directly with stored values in `Users`. Password hashing remains a TODO in the implementation.
- **Environment setup:** Database provisioning and third-party assembly configuration are manual.
- **Validation:** No automated test suite is included. Verify both login roles, inventory and customer operations, sales and stock updates, order status changes, restocking, and reports manually after setup.

## Documentation

The accompanying [application development report](Application%20Development%20-%20Zai.pdf) is included in the repository for additional project context.

## Author

**I M Zairaz (Zai)** · [@imzairaz](https://github.com/imzairaz)

## License

No license file is included in this repository. Contact the author for clarification on reuse and distribution permissions.
