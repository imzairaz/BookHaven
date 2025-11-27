# BookHaven - Bookstore Management System

BookHaven is a Windows Forms-based application designed to streamline inventory management, sales tracking, and customer management for a mid-sized bookstore. This system helps manage books, track customer orders, handle inventory, and generate sales reports.

## Features

- **User Login System**: Secure login with role-based access control (Admin and Sales Clerk).
- **Book Inventory Management**: Add, update, delete, and search books in the inventory.
- **Customer Management**: Add, update, delete, and search customer profiles.
- **Sales Transactions**: Process sales, calculate totals, apply discounts, and generate receipts.
- **Order Management**: Manage customer orders for pick-up or delivery.
- **Supplier Management**: Manage supplier details and generate restock orders.
- **Admin Dashboard**: Overview of total sales, inventory levels, customer activity, and staff performance.
- **Reporting and Analytics**: Generate sales reports, track best-selling books, and monitor inventory status.
- **Security and Data Protection**: Implemented role-based access control and encryption for sensitive data.

## Requirements

### Hardware

- **Operating System**: Windows 10/11
- **Processor**: Intel Core i3 or higher
- **RAM**: 4GB minimum (8GB recommended)
- **Disk Space**: At least 10GB free

### Software

- **.NET Framework**: 4.7.2 or higher
- **Visual Studio 2017 or later**
- **SQL Server (SSMS)**

## Installation

### Clone the Repository

Clone the repository to your local machine:

```bash
git clone https://github.com/imzairaz/BookHaven.git

Open in Visual Studio

    Open Visual Studio 2017 or later.

    Click on File > Open > Project/Solution.

    Navigate to the cloned repository and open the BookHaven.sln file.

Setting Up the Database

    Open SQL Server Management Studio (SSMS).

    Execute the provided database.sql script to create the necessary tables in your database.

    Update the connection string in DatabaseHelper.cs to match your SQL Server setup.

Run the Application

Press F5 to build and run the application from Visual Studio.
User Roles

    Admin: Full access to manage books, customers, orders, suppliers, and view reports.

    Sales Clerk: Limited access to manage sales transactions, view inventory, and manage customers.

How to Use
Admin

    Admin Dashboard: View system metrics like total sales and customer activity.

    Manage Clerk: Add, update, or delete sales clerk accounts.

    Inventory: Add, update, delete, and search books in the inventory.

    Restock: Order books and manage restock statuses.

    Manage Suppliers: Add, update, or delete suppliers.

    Reports: Generate and view sales reports.

Sales Clerk

    Sales Transaction: Process sales, calculate totals, and print receipts.

    Customer Management: Add new customers and view existing profiles.

    Order Management: Track and manage customer orders.

Documentation

The repository contains detailed documentation, including:

    Installation Guide and User Manual

    Solution Description

    Architecture Diagram

    ER Diagram and UML Diagrams

    Class Details and Methods

Testing

Several test cases have been implemented to verify the correct functionality of the application, such as:

    Successful and unsuccessful login attempts.

    Adding, updating, and deleting books and customers.

    Handling sales transactions and generating receipts.

Future Improvements

    Automated Testing: Implement automated tests for database operations.

    Enhanced Reporting: Add graphical reports for better insights.

    Cloud Integration: Integrate with cloud services for backup and scalability.

    Mobile Access: Develop a mobile version of the application for on-the-go access.

Conclusion

This project is a comprehensive bookstore management system developed using Windows Forms. It offers a user-friendly interface for both Admins and Sales Clerks, ensuring efficient business operations for inventory and customer management.
License

MIT License


This `README.md` includes an overview of the features, installation steps, usage instructions, and more, based on the details from your document. You can modify the links and paths as per your specific project structure.
