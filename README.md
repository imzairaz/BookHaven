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
- [Included database records](#included-database-records)
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
- SQL Server 2012 or later for the supplied scripts.
- SQL Server Management Studio (SSMS) — [download the installer from the project's shared OneDrive folder](https://1drv.ms/f/c/1c376c356b285265/IgDQVZoAX1nkSL1RGKa79uXgAXaloGUXyB5x6fQRB0PigNY?e=GOB9ii).
- Bunifu UI, Guna UI, and Guna UI2 DLLs in `Lib/` — [download the libraries from OneDrive](https://1drv.ms/f/c/1C376C356B285265/AtiaB72fr6tDk2Jv2Gxlm8Q?e=iu5d1t).

> **Database setup:** A reconstructed SQL Server schema, optional seed data, and verification script are available in [Database/](Database/README.md). The UI DLLs must be available in `Lib/`; download instructions are provided below.

### 1. Clone and open the solution

```sh
git clone https://github.com/imzairaz/BookHaven.git
cd BookHaven
```

Open [BookHaven.sln](BookHaven.sln) in Visual Studio.

### 2. Download and configure the UI libraries

The UI DLLs are distributed separately and are not included in this repository. Download them before building the application.

**[Download Bunifu UI, Guna UI, and Guna UI2 DLLs from OneDrive](https://1drv.ms/f/c/1C376C356B285265/AtiaB72fr6tDk2Jv2Gxlm8Q?e=iu5d1t)**

1. Open the shared OneDrive folder and download the three DLLs.
2. If the download is a ZIP archive, extract it first.
3. Create a folder named **`Lib`** in the repository root, beside `BookHaven.sln`.
4. Copy the three DLLs directly into `Lib/`. Avoid an extra nested folder from the extracted archive.
5. Confirm the folder structure matches the example below.

```text
BookHaven/
├── BookHaven.sln
├── Lib/
│   ├── Bunifu_UI_v1.52.dll
│   ├── Guna.UI.dll
│   └── Guna.UI2.dll
└── BookHaven/
    └── BookHaven.csproj
```

| Library | Required filename | Configured project reference |
| --- | --- | --- |
| Bunifu UI | `Bunifu_UI_v1.52.dll` | `..\Lib\Bunifu_UI_v1.52.dll` |
| Guna UI | `Guna.UI.dll` | `..\Lib\Guna.UI.dll` |
| Guna UI2 (Guna2) | `Guna.UI2.dll` | `..\Lib\Guna.UI2.dll` |

The project references are already configured with these relative paths and **Copy Local** enabled. After downloading the files, Visual Studio can resolve them and copy them to the build output.

#### Build and open the forms

1. Keep all three DLLs in the `Lib` folder alongside `BookHaven.sln`.
2. If Windows blocks a downloaded DLL, right-click it → **Properties** → **Unblock** (if shown) → **Apply**.
3. Open `BookHaven.sln` in Visual Studio.
4. Expand **BookHaven → References** in **Solution Explorer**. Confirm the three references appear without warning icons.
5. Select **Build → Rebuild Solution**. The project has **Copy Local** enabled for all three assemblies.
6. Once the build succeeds, right-click a form such as `Login.cs` and select **View Designer**.

The assembly references are already configured. No separate installer or manual Toolbox registration is required to build the existing application.

#### Add controls to the Toolbox (optional)

To drag additional controls onto a form:

1. Open a Windows Form in the designer, then select **View → Toolbox**.
2. Right-click inside the Toolbox → **Add Tab**. Create tabs named **Bunifu UI**, **Guna UI**, and **Guna UI2**.
3. Right-click the **Bunifu UI** tab → **Choose Items… → .NET Framework Components → Browse…**.
4. Select `Bunifu_UI_v1.52.dll` from the `Lib` folder, select the required controls, and choose **OK**.
5. Repeat for `Guna.UI.dll` and `Guna.UI2.dll` in their respective tabs.

#### Repair a missing reference

If a reference has a warning icon, close the form designer, remove only the affected reference, then right-click **References → Add Reference → Browse** and select its DLL from the `Lib` folder. Set **Copy Local** to **True** in the reference properties and rebuild.

For designer load errors, check the **Error List**, confirm the .NET Framework 4.7.2 targeting pack is installed, and check whether Windows has blocked any DLL. Replacement assemblies must remain compatible with the controls in the `.Designer.cs` files. Guna UI and Guna UI2 are separate libraries; both are required.

### 3. Prepare the database

If SSMS is not installed:

1. Open the [SSMS download folder on OneDrive](https://1drv.ms/f/c/1c376c356b285265/IgDQVZoAX1nkSL1RGKa79uXgAXaloGUXyB5x6fQRB0PigNY?e=GOB9ii).
2. Download the SSMS installer provided in the folder.
3. Run the installer and follow its setup instructions.
4. Open SSMS and connect to your SQL Server instance.

SSMS is the database management tool. Install a SQL Server database engine separately if you do not already have an instance available.

Once connected, open and execute the supplied scripts in this order:

1. [Create the schema](Database/schema.sql) — creates `BookHeaven` and its nine tables. Requires an empty database; existing tables are left unchanged.
2. [Load optional seed data](Database/seed_data.sql) — edit the initial passwords, then populate all nine tables with 30 books, 30 customers, 240 sales, customer orders, and restock history.
3. [Verify the database](Database/verify_database.sql) — exercises workflows and constraints, then rolls back test records.

See the [database guide](Database/README.md) for the schema, credentials, installation details, and known application behavior. The schema is reconstructed from the source and does not restore lost records.

### 4. Configure the connection

Update the SQL Server instance in all nine source connection strings listed in the [database connection guide](Database/README.md#connect-the-application). For example, a local SQL Server Express instance using Windows authentication could use:

```csharp
private static readonly string connectionString =
    @"Data Source=.\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";
```

Set `Data Source` to your SQL Server instance and `Initial Catalog` to your database name. The source configuration uses **`BookHeaven`**. With `Integrated Security=True`, grant database access to the Windows account running the application.

`App.config` only declares the supported runtime. Set the same server and database in all nine source files.

### 5. Build and sign in

1. Build the solution in Visual Studio.
2. Press **F5** to start the application.
3. Select `Admin` or `Staff` and sign in with an account from your database's `Users` table.

If you loaded the seed data without changing the initial passwords, use:

| Role | Username | Initial password |
| --- | --- | --- |
| `Admin` | `admin` | `BookHaven-Admin-2026!` |
| `Staff` | `clerk` | `BookHaven-Staff-2026!` |

Passwords are case-sensitive. Set your own initial passwords in the seed script before loading it. If you skip seed data, provision an Admin account directly in `Users` before signing in.

## Included database records

[seed_data.sql](Database/seed_data.sql) supplies a complete fictional bookstore dataset with Sri Lankan names, local address and phone formats, and illustrative prices in LKR.

| Records | Count |
| --- | ---: |
| User accounts | 6 — 2 Admin and 4 Staff |
| Books | 30 |
| Customers | 30 |
| Suppliers | 6 |
| Sales transactions | 240 |
| Sales line items | 600 |
| Customer orders | 36 |
| Order line items | 72 |
| Restock requests | 18 |

Sales cover 120 days relative to script execution, including the current day, with walk-in purchases and discounts of 0%, 5%, and 10%. The dataset includes pending, completed, and cancelled customer orders; pickup and delivery methods; and pending, received, and canceled restock requests. Inventory includes available, low-stock, and out-of-stock titles.

Stored sale totals reconcile with their discounted line items. Inventory balances account for opening stock, received restocks, and sold quantities. Book titles and authors are real; generated ISBN-format values are not verified publisher assignments. Contacts and transactions are fictional.

The seed script requires all nine application tables to be empty and refuses to overwrite existing records. If you already loaded an earlier dataset, follow the [database guide](Database/README.md#sample-dataset) to prepare a separate empty database.

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
├── Lib/                          # Create locally; download DLLs from OneDrive
│   ├── Bunifu_UI_v1.52.dll        # Bunifu UI assembly
│   ├── Guna.UI.dll               # Guna UI assembly
│   └── Guna.UI2.dll              # Guna UI2 assembly
├── BookHaven/
│   ├── BookHaven.csproj           # Project settings and assembly references
│   ├── Program.cs                # Application entry point
│   ├── Loading.cs                # Startup form
│   ├── Login.cs                  # Database-backed login and role routing
│   ├── DatabaseHelper.cs         # SQL Server connection factory
│   ├── Admin_*.cs                # Administration forms
│   ├── Clerk_*.cs                # Sales clerk forms
│   ├── ManageOrder.cs            # Order management form
│   ├── Resources/                # Images and interface assets
│   └── Properties/               # Application resources and settings
├── Database/
│   ├── schema.sql                # Tables, relationships, constraints, and indexes
│   ├── seed_data.sql             # Complete bookstore dataset
│   ├── verify_database.sql       # Transactional workflow and constraint checks
│   └── README.md                 # Database setup and schema reference
├── Document/
│   └── Application Development - Zai.pdf
└── README.md
```

Each form is paired with a `.Designer.cs` file for layout and a `.resx` file for resources.

## Troubleshooting

| Problem | What to check |
| --- | --- |
| Missing Guna or Bunifu types, or reference warning icons | Download the DLLs from the OneDrive link above, extract them directly into `Lib/`, and rebuild. Check filenames and reference paths. |
| Form designer cannot load a control | Build the project first, unblock downloaded DLLs if needed, and check assembly version compatibility in the Error List. |
| Missing framework reference assemblies | Install the .NET Framework 4.7.2 targeting pack through Visual Studio Installer. |
| SQL Server connection fails | Verify the instance name, server availability, database name, and Windows account permissions. |
| Invalid object or column errors | Confirm that your database schema matches the SQL queries in the forms. |
| Schema or seed installation refuses to run | The schema requires an empty database; seed data requires empty application tables. Use a separate empty database to preserve existing records. |
| Deleting a referenced record fails | Foreign keys preserve transaction history. Books, customers, and suppliers linked to transactions cannot be deleted. |
| Login is rejected | Check that the username, password, and selected `Admin` or `Staff` role match a record in `Users`. |

## Implementation notes

- **Authentication:** Passwords are compared directly with stored values in `Users`. Password hashing remains a TODO in the implementation.
- **Environment setup:** Run the supplied database scripts and download the UI DLLs into `Lib/` before building. Assembly references are configured with relative paths.
- **Inventory:** Receiving the same restock request repeatedly can add stock more than once. Customer orders do not reserve or decrement inventory.
- **Sales reporting:** The current sales form can save undiscounted line totals for discounted bills. The seed data contains reconciled totals; the application calculation still requires correction.
- **Verification:** SQL workflow and constraint checks are provided in `Database/verify_database.sql`. SQL Server execution has not been verified in this workspace. No automated C# test suite is included; verify the application workflows manually after setup.

## Documentation

- [Database guide](Database/README.md) — installation, connection settings, schema reference, and application behavior.
- [Application development report](Document/Application%20Development%20-%20Zai.pdf) — additional project context.

## Author

**I M Zairaz (Zai)** · [@imzairaz](https://github.com/imzairaz)

## License

No license file is included in this repository. Contact the author for clarification on reuse and distribution permissions.
