# 📚 BookHaven – Bookstore Management System
*A modern Windows Forms application to streamline bookstore operations.*

🌟 **Admin Dashboard** • 🛒 Sales System • 📦 Inventory • 👥 Customers • 🧾 Reports • 🚚 Orders • 🏭 Suppliers

---

## 🚀 Tech Stack

<div align="center">

[![.NET](https://img.shields.io/badge/.NET-4.7.2-purple)](https://dotnet.microsoft.com/)  
[![C#](https://img.shields.io/badge/C%23-10.0-blue)](https://learn.microsoft.com/en-us/dotnet/csharp/)  
[![SQL Server](https://img.shields.io/badge/SQL_Server-Express-blue)](https://www.microsoft.com/en-us/sql-server)  
[![Visual Studio](https://img.shields.io/badge/Visual_Studio-2022-green)](https://visualstudio.microsoft.com/)  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

</div>

---

## ✨ Features

- 🔐 **Secure Role-Based Login** (Admin & Clerk)  
- 📚 **Book Inventory Management**: Add, Update, Delete, Search  
- 👥 **Customer Management** with Purchase History  
- 🛒 **Point of Sale (POS)** with Receipt Generation  
- 🚚 **Order Management** (In-store Pickup / Delivery)  
- 🏭 **Supplier & Restock Management**  
- 📊 **Admin Dashboard** with Key Metrics  
- 🧾 **Sales Reports**: Daily, Weekly, Monthly + Best Sellers  
- ✅ Robust **Data Validation** & Exception Handling  

Ideal for bookstore staff and administrators seeking a clean and efficient desktop system.

---

## 🖼 Screenshots

### Login Interface
![Login](https://github.com/user-attachments/assets/421c44f0-9b49-49d0-8c55-4f997e9f91a3)

### Admin Dashboard
![Admin Dashboard](https://github.com/user-attachments/assets/c5a6c2ab-9996-4816-b554-602f23abee31)

### Clerk Interface
![Clerk](https://github.com/user-attachments/assets/ad8a847d-5d9b-4554-a960-9a54f6039858)

### Inventory Management
![Inventory](https://github.com/user-attachments/assets/532787b5-fe15-47d1-b317-13eba00af517)

### POS System
![POS](https://github.com/user-attachments/assets/2d844aa0-7cad-4cae-a4e0-a6917dbe0dd2)

### Customer Management
![Customer](https://github.com/user-attachments/assets/a8e27061-0f02-48bc-9779-de73b3442daa)

### Orders
![Orders](https://github.com/user-attachments/assets/b7ed4e91-3f9b-490e-8eb9-8cf5935c6a77)

---

## 🔐 User Roles

### 👑 Admin
- Full system access  
- Manage Inventory, Customers, Suppliers, Orders  
- View Analytics & Reports  
- Manage Staff Accounts  

### 👨‍💼 Sales Clerk
- Process Sales  
- Search Inventory  
- Manage Customers  
- Create Customer Orders  

---

## ⚙ System Requirements

### 🖥 Hardware
- Windows 10 or 11  
- Intel i3 or higher  
- 4GB RAM (8GB recommended)  
- 10GB free disk space  

### 🧩 Software
- .NET Framework 4.7.2+  
- Visual Studio 2017+  
- SQL Server + SSMS  

---

## 📥 Installation Guide

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/imzairaz/BookHaven.git
````

### 2️⃣ Open with Visual Studio

* Open `BookHaven.sln`
* Build and run using **F5**

### 3️⃣ Database Setup

1. Open **SSMS**
2. Run `database.sql`
3. Update the connection string in `DatabaseHelper.cs`

### 4️⃣ Run the Application

* Press **F5**
* Login using default credentials:

| Role  | Username | Password |
| ----- | -------- | -------- |
| Admin | admin    | admin123 |
| Clerk | clerk    | clerk123 |

---

## 🧭 Application Modules

* 🔑 **Login System**: Secure credentials & role-based UI
* 📚 **Inventory Management**: Add/Update/Delete/Search Books
* 👥 **Customer Management**: Add/update details, view history
* 🛒 **Sales Transaction (POS)**: Bill, discounts, print receipts, auto-stock update
* 🚚 **Order Management**: Place orders, pickup/delivery, update status
* 🏭 **Supplier Management**: Add/Update suppliers, restock, manage orders
* 📊 **Reports & Analytics**: Sales overview, top-sellers, inventory insights

---

## 🏗 Architecture

**Multi-layer Design:**

* 🎨 **UI Layer**: Windows Forms
* 🧠 **Business Logic Layer**: Handles validation & logic
* 🗄 **Database Layer**: SQL Server + Stored Queries

**Included Diagrams**: Architecture, ER, UML, Class

---

## 🧪 Test Cases Covered

* Login success & failure
* Add/Update/Delete Books
* Restock orders
* Sales & receipt generation
* Customer operations
* Customer order placement

---

## Documentation

Detailed documentation including:
- Installation Guide & User Manual
- Architecture, ER & UML Diagrams
- Class Descriptions
- Personal Reflection
[Download Full Report (PDF)](https://github.com/imzairaz/BookHaven/blob/master/Application%20Development%20-%20Zai.pdf)

## 📝 Author

👤 **I M Zairaz (Zai)**
GitHub: [@imzairaz](https://github.com/imzairaz)

---

## 📄 License

MIT License – [See License](https://opensource.org/licenses/MIT)

---

⭐ **If you like this project, please give it a star!** ⭐
