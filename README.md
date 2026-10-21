<div align="center">

# BookHaven

### Bookstore operations, in one workspace.

Manage inventory, sales, customer orders, suppliers, and staff from a Windows desktop application.

![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.7.2-512BD4?style=flat-square)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square)
[![License: MIT](https://img.shields.io/badge/License-MIT-22C55E?style=flat-square)](LICENSE)

[Get started](#getting-started) · [Explore the interface](#application-preview) · [Database guide](Database/README.md) · [Project report](Document/Application%20Development%20-%20Zai.pdf)

</div>

---

## Overview

BookHaven brings daily bookstore operations into one desktop workspace. Administrators manage the catalog, inventory, suppliers, accounts, and reports; sales staff handle customer records, purchases, and pickup or delivery orders.

## At a glance

| Catalog and inventory | Sales and customers | Store administration |
| --- | --- | --- |
| Search books and manage prices | Build itemized bills and apply discounts | Manage staff and supplier records |
| Track available and low stock | Save sales and generate receipts | Request, receive, or cancel restocks |
| Maintain book records | Manage pickup and delivery orders | Review sales, best sellers, and inventory |

**Admin** manages store operations and reporting. **Staff** handles sales, customers, and customer orders.

## Application preview

![BookHaven administration dashboard](https://github.com/user-attachments/assets/c5a6c2ab-9996-4816-b554-602f23abee31)

<details>
<summary><strong>View login, inventory, sales, customers, and orders</strong></summary>

<details>
<summary>Login</summary>

![BookHaven — login](https://github.com/user-attachments/assets/421c44f0-9b49-49d0-8c55-4f997e9f91a3)

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

</details>

## Tech stack

| Area | Technology |
| --- | --- |
| Language and runtime | C#, .NET Framework 4.7.2 |
| Desktop UI | Windows Forms, Bunifu UI, Guna UI, Guna UI2 |
| Data access | ADO.NET (`System.Data.SqlClient`) |
| Database | Microsoft SQL Server |
| Development tools | Visual Studio, SQL Server Management Studio (SSMS) |

Form classes contain workflow logic and SQL queries. `DatabaseHelper` supplies a shared connection factory, while several forms also define their own connection strings.

## Getting started

### Before you begin

- **Windows** capable of running .NET Framework 4.7.2 Windows Forms applications.
- **Visual Studio** with the **.NET desktop development** workload and **.NET Framework 4.7.2 targeting pack**.
- **SQL Server 2012 or later** for the supplied database scripts.
- **SSMS:** [Download the installer from OneDrive](https://1drv.ms/f/c/1c376c356b285265/IgDQVZoAX1nkSL1RGKa79uXgAXaloGUXyB5x6fQRB0PigNY?e=GOB9ii).
- **UI assemblies:** [Download Bunifu UI, Guna UI, and Guna UI2 from OneDrive](https://1drv.ms/f/c/1C376C356B285265/AtiaB72fr6tDk2Jv2Gxlm8Q?e=iu5d1t).

> [!IMPORTANT]
> Install the SQL Server database engine separately from SSMS. Download the UI DLLs into `Lib/` before building; they are not included in the repository.

### 1. Clone the repository

```bash
git clone https://github.com/imzairaz/BookHaven.git
cd BookHaven
```

Open [BookHaven.sln](BookHaven.sln) in Visual Studio.

### 2. Download the UI libraries

1. Download the DLLs from the [shared OneDrive folder](https://1drv.ms/f/c/1C376C356B285265/AtiaB72fr6tDk2Jv2Gxlm8Q?e=iu5d1t).
2. Extract the archive if the download is a ZIP file.
3. Create **`Lib/`** beside `BookHaven.sln` and copy the following files directly into it.

| Library | Required file | Configured reference |
| --- | --- | --- |
| Bunifu UI | `Bunifu_UI_v1.52.dll` | `..\Lib\Bunifu_UI_v1.52.dll` |
| Guna UI | `Guna.UI.dll` | `..\Lib\Guna.UI.dll` |
| Guna UI2 | `Guna.UI2.dll` | `..\Lib\Guna.UI2.dll` |

References already use these relative paths with **Copy Local** enabled. Keep the DLLs directly inside `Lib/`, without an extra archive subfolder. If Windows blocks a file, right-click it → **Properties → Unblock** (if shown) → **Apply**.

### 3. Create and populate the database

1. Download and run the [SSMS installer](https://1drv.ms/f/c/1c376c356b285265/IgDQVZoAX1nkSL1RGKa79uXgAXaloGUXyB5x6fQRB0PigNY?e=GOB9ii), following its setup instructions.
2. Open SSMS and connect to your SQL Server instance.
3. Open and execute the scripts below **in order**.

| Order | Script | Purpose |
| --- | --- | --- |
| 1 | [schema.sql](Database/schema.sql) | Create `BookHeaven`, its nine tables, relationships, constraints, and indexes. Requires an empty database. |
| 2 | [seed_data.sql](Database/seed_data.sql) | Optionally populate all nine tables. Edit initial passwords before execution. Requires empty application tables. |
| 3 | [verify_database.sql](Database/verify_database.sql) | Check workflows and constraints; roll back test records. |

> [!NOTE]
> The schema is reconstructed from source and does not recover lost records. Setup refuses existing tables or populated seed tables. See the [database guide](Database/README.md) if you already have data.

### 4. Configure SQL Server access

Update the connection strings in **all nine source files** listed in the [connection guide](Database/README.md#connect-the-application). For a local SQL Server Express instance:

```csharp
private static readonly string connectionString =
    @"Data Source=.\SQLEXPRESS;Initial Catalog=BookHeaven;Integrated Security=True";
```

| Setting | Value or action |
| --- | --- |
| `Data Source` | Set your SQL Server instance name. |
| `Initial Catalog` | Use `BookHeaven`, matching the supplied schema. |
| `Integrated Security` | `True`; grant database access to the Windows account running the application. |
| Configuration location | Source connection strings; `App.config` declares only the supported runtime. |

### 5. Build and run

1. In **Solution Explorer → BookHaven → References**, check that the three UI libraries have no warning icons.
2. Select **Build → Rebuild Solution**.
3. Press **F5** to start the application.
4. Select `Admin` or `Staff` and sign in with a matching account in `Users`.

If you loaded the seed script without changing its passwords:

| Role | Username | Initial password |
| --- | --- | --- |
| `Admin` | `admin` | `BookHaven-Admin-2026!` |
| `Staff` | `clerk` | `BookHaven-Staff-2026!` |

Passwords are case-sensitive. Set your own initial passwords before loading the script. If you skip seed data, provision an Admin account directly in `Users` before signing in.

## Daily use

| Action | Command or Visual Studio operation |
| --- | --- |
| Build | **Build → Rebuild Solution** |
| Run | **F5** |
| Open a form designer | Right-click a form such as `Login.cs` → **View Designer** |
| Verify database workflows | Execute [verify_database.sql](Database/verify_database.sql) in SSMS |

### Roles and daily workflow

| Role | Workspace |
| --- | --- |
| `Admin` | Dashboard, inventory, customers, suppliers, restocking, staff accounts, orders, and reports. |
| `Staff` | Sales, customers, and customer orders. |

- **Admin:** Maintain books, suppliers, and customers; manage restocking; review reports.
- **Staff:** Select a customer, add books and discounts to a bill, and use the receipt action to save the sale and update stock.
- **Orders:** Create pickup or delivery orders and maintain their status.

## Database at a glance

The seed script provides fictional Sri Lankan bookstore records with illustrative LKR prices:

| Entity | Count | Entity | Count |
| --- | ---: | --- | ---: |
| Users | 6 | Books | 30 |
| Customers | 30 | Suppliers | 6 |
| Sales | 240 | Sales line items | 600 |
| Customer orders | 36 | Order line items | 72 |
| Restock requests | 18 | Sales history | 120 days |

- **History:** 120 days of sales relative to execution, including the current day, walk-in purchases, and 0%, 5%, and 10% discounts.
- **Coverage:** Pickup and delivery orders, varied order/restock statuses, and available, low-stock, and out-of-stock books.
- **Balances:** Seed sale totals reconcile with discounted line items; stock accounts for opening quantities, receipts, and sales.
- **Catalog:** Real book titles and authors; generated ISBN-format identifiers are not verified publisher assignments. Contacts and transactions are fictional.

See the [database guide](Database/README.md) for full details.

## Developer reference

<details>
<summary><strong>Add controls to the Visual Studio Toolbox</strong></summary>

1. Open a Windows Form in the designer, then **View → Toolbox**.
2. Right-click the Toolbox → **Add Tab**; create **Bunifu UI**, **Guna UI**, and **Guna UI2** tabs.
3. Right-click each tab → **Choose Items… → .NET Framework Components → Browse…**.
4. Select the corresponding DLL in `Lib/`, choose the required controls, and select **OK**.

Toolbox registration is optional for building the existing application.

</details>

<details>
<summary><strong>Troubleshoot setup and connection issues</strong></summary>

| Problem | Resolution |
| --- | --- |
| Missing UI types or reference warnings | Download all three DLLs into `Lib/` and rebuild. If needed, remove the affected reference and re-add it through **References → Add Reference → Browse**; set **Copy Local = True**. |
| Designer cannot load controls | Build first; check blocked DLLs, assembly compatibility, and the Error List. |
| Missing framework assemblies | Install the .NET Framework 4.7.2 targeting pack. |
| Database connection fails | Check instance name, `BookHeaven` database name, and Windows account permissions. |
| Invalid table or column | Confirm the schema matches the source queries. |
| Schema or seed script refuses to run | Use an empty database for the schema and empty application tables for seed data. |
| Deleting a referenced record fails | Foreign keys preserve transaction history; referenced records cannot be deleted. |
| Login fails | Match the username, case-sensitive password, and selected role to the `Users` record. |

</details>

### Known limitations

- **Authentication:** Passwords are stored and compared directly; password hashing remains a TODO.
- **Restocking:** Receiving the same request repeatedly can add stock more than once.
- **Orders:** Customer orders do not reserve or decrement inventory.
- **Reporting:** The sales form can save undiscounted line totals for discounted bills. Seed totals reconcile, but application calculations still need correction.
- **Verification:** SQL Server execution has not been verified in this workspace. No automated C# test suite is included; verify application workflows manually after setup.

## Project structure

<details>
<summary><strong>Explore the repository</strong></summary>

```text
BookHaven/
├── BookHaven.sln
├── BookHaven/
│   ├── BookHaven.csproj
│   ├── Program.cs              # Application entry point
│   ├── Loading.cs              # Startup form
│   ├── Login.cs                # Login and role routing
│   ├── DatabaseHelper.cs       # Connection factory
│   ├── Admin_*.cs              # Administration forms
│   ├── Clerk_*.cs              # Staff forms
│   ├── ManageOrder.cs          # Order management form
│   ├── Resources/              # UI assets
│   └── Properties/             # Resources and settings
├── Lib/                        # Create locally; download DLLs from OneDrive
│   ├── Bunifu_UI_v1.52.dll
│   ├── Guna.UI.dll
│   └── Guna.UI2.dll
├── Database/
│   ├── schema.sql
│   ├── seed_data.sql
│   ├── verify_database.sql
│   └── README.md
├── Document/
│   └── Application Development - Zai.pdf
└── README.md
```

Forms have matching `.Designer.cs` layout files and `.resx` resources. See the [application development report](Document/Application%20Development%20-%20Zai.pdf) for additional context.

</details>

---

## License and contact

**License:** [MIT](LICENSE) — applies to the project’s original code and documentation.

Third-party libraries, including Bunifu UI, Guna UI, and Guna UI2, retain their respective licenses and are not covered by this license.

**Author:** I M Zairaz (Zai) · [@imzairaz](https://github.com/imzairaz)
