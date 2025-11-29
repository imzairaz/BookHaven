# BookHaven - Bookstore Management System

![BookHaven Banner](https://github.com/user-attachments/assets/421c44f0-9b49-49d0-8c55-4f997e9f91a3)

> A modern Windows Forms desktop application built in **C#** for managing bookstore operations — inventory, sales, customers, suppliers, orders, and analytics.

[![.NET](https://img.shields.io/badge/.NET-4.7.2-purple)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-10.0-blue)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-Express-blue)](https://www.microsoft.com/en-us/sql-server)
[![Visual Studio](https://img.shields.io/badge/Visual_Studio-2022-green)](https://visualstudio.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

**Course**: CS6004ES – Application Development  
**Student**: I M Zairaz (E182014)  
**Module Leader**: Mr. Chamila Karunathilaka  
**Submitted**: 15th March 2025  
**London Metropolitan University**

---

## Features

- Secure **Role-Based Login** (Admin & Sales Clerk)
- Full **Book Inventory Management** (Add, Update, Delete, Search)
- **Customer Management** with Purchase History
- **Point of Sale (POS)** System with Receipt Generation
- **Order Management** (In-store Pickup / Delivery)
- **Supplier & Restock Management**
- **Admin Dashboard** with Key Metrics
- **Sales Reports** (Daily, Weekly, Monthly + Best Sellers)
- Robust **Data Validation** & Exception Handling

---

## Screenshots

| Login Screen                          | Admin Dashboard                          |
|---------------------------------------|------------------------------------------|
| ![Login](https://github.com/user-attachments/assets/cbb2e2f1-4ba0-4e95-ae3a-87b5e24836a1) | ![Admin Dashboard](https://github.com/user-attachments/assets/c5a6c2ab-9996-4816-b554-602f23abee31) |

| Clerk Interface (Sales View)          | Inventory Management                     |
|---------------------------------------|------------------------------------------|
| ![Clerk Interface](https://github.com/user-attachments/assets/ad8a847d-5d9b-4554-a960-9a54f6039858) | ![Inventory](https://github.com/user-attachments/assets/532787b5-fe15-47d1-b317-13eba00af517) |

| Restock Books                         | Manage Suppliers                         |
|---------------------------------------|------------------------------------------|
| ![Restock](https://github.com/user-attachments/assets/6948a8d2-5f2d-409a-9e63-6fc359a39e12) | ![Suppliers](https://github.com/user-attachments/assets/7a5a6428-b4b8-467c-a6be-93f3d21d0b1f) |

| Point of Sale (POS)                   | Manage Customers                         |
|---------------------------------------|------------------------------------------|
| ![POS](https://github.com/user-attachments/assets/2d844aa0-7cad-4cae-a4e0-a6917dbe0dd2) | ![Customers](https://github.com/user-attachments/assets/a8e27061-0f02-48bc-9779-de73b3442daa) |

| Order Management (Clerk)              |
|---------------------------------------|
| ![Order Form](https://github.com/user-attachments/assets/b7ed4e91-3f9b-490e-8eb9-8cf5935c6a77) |

---

## System Requirements

### Hardware
- Windows 10/11
- 4GB RAM (8GB recommended)
- 500MB free disk space

### Software
- .NET Framework 4.7.2 or higher
- Visual Studio 2017+
- SQL Server 2016+ / SQL Server Express
- SQL Server Management Studio (SSMS)

---

## Installation & Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/BookHaven.git
   ```

2. **Open Project**
   - Launch Visual Studio
   - Open `BookHaven.sln`

3. **Database Setup**
   - Open SSMS and run the script in `Database/BookHavenDB.sql`
   - Or attach the `.mdf` file located in `Database/`

4. **Update Connection String** (if needed)
   ```csharp
   Data Source=.\SQLEXPRESS;Initial Catalog=BookHavenDB;Integrated Security=True
   ```

5. **Run the Application**
   - Press **F5** in Visual Studio

Default Login Credentials:
- **Admin**: Username: `admin` | Password: `admin123`
- **Clerk**: Username: `clerk` | Password: `clerk123`

---

## Project Structure

```
BookHaven/
├── Forms/              # All Windows Forms
├── Classes/            # Business logic & models
├── Database/           # SQL scripts & .mdf file
├── Reports/            # Crystal Reports (.rpt)
├── Resources/          # Images & icons
├── Documentation/      # Full report (AD - Zai.pdf)
└── BookHaven.sln
```

---

## Documentation

Detailed documentation including:
- Installation Guide & User Manual
- Architecture, ER & UML Diagrams
- Class Descriptions
- Personal Reflection

[Download Full Report (PDF)](https://github.com/yourusername/BookHaven/blob/main/Documentation/AD%20-%20Zai.pdf)

---

## Academic Integrity

This project was developed **entirely by I M Zairaz** as part of the CS6004ES coursework. No generative AI was used to write core logic or produce submission content. All code, design, and documentation are original work.

---

## License

This project is licensed under the **MIT License** – feel free to use, modify, and learn from it.

---

**Developed with passion by I M Zairaz**  
London Metropolitan University | March 2025

⭐ **If you like this project, please give it a star!** ⭐
