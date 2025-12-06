# Support Helpdesk Portal (ASP.NET Web Forms)

Support Helpdesk Portal is a simple **ticketing and inventory management system** built using **ASP.NET Web Forms (.NET Framework 4.8)** and **SQL Server**. It demonstrates practical concepts used in real-world support/maintenance projects such as authentication, authorization, CRUD operations, master pages, and stored‑procedure-based data access.

---

## 🚀 Features

### 🔐 Authentication & Roles

* Forms Authentication (Login/Logout)
* Two roles: **Admin** and **User**
* Role-based page access through Web.config

### 📊 Admin Dashboard

* View: Total Tickets, Open Tickets, Total Users
* Quick links to Manage Categories, Products & Tickets

### 🎫 Support Tickets

* Create tickets with Title, Description, Status, Assignee & File Attachment
* Ticket List with filters: Status, Date Range
* Color‑coded rows (Open, Pending, Closed)
* Ticket Details page with download link
* Assign tickets to available users

### 📦 Inventory Management (Admin)

* Manage Categories (CRUD)
* Manage Products with Category, Unit Price & Stock Quantity

### 👤 User Profile

* Shows Username, Full Name, Role & Member Since date

### 📝 Registration

* Simple Registration form creating users with default **User** role

---

## 🛠️ Tech Stack

* **ASP.NET Web Forms (.NET Framework 4.8)**
* **C#**, **ADO.NET** (SqlConnection, SqlCommand, SqlDataAdapter)
* **SQL Server (HelpdeskDB)**
* **Visual Studio 2019/2022**
* **Forms Authentication**

---

## 📥 Getting Started

### 1️⃣ Prerequisites

* Visual Studio 2019/2022 (Web Development workload)
* SQL Server Express / Developer / Standard
* SQL Server Management Studio (SSMS)

### 2️⃣ Restoring the Database

1. Open **SSMS** → Connect to SQL Server.
2. Create a new database named **HelpdeskDB**.
3. Run the full SQL script from `database/HelpdeskDB.sql` to create:

   * Tables
   * Stored Procedures
   * Seed Data (Admin user)

**Default Admin Credentials:**

* **Username:** `admin`
* **Password:** `admin123`

### 3️⃣ Configure Connection String

Open `Web.config` and update:

```xml
<connectionStrings>
  <add name="HelpdeskDB" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=HelpdeskDB;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

Modify `Data Source` or authentication based on your SQL Server setup.

### 4️⃣ Run the Application

* Open **SupportHelpdeskPortal.sln** in Visual Studio
* Set project as **Startup Project**
* Press **F5** to run
* Login using `admin / admin123`

Admins go to **Dashboard**, Users go to **Ticket List**.

---

## 📸 Screenshots

* **Ticket List Page** – Status colors, filters, downloads
<img width="1911" height="607" alt="Screenshot 2025-12-07 044759" src="https://github.com/user-attachments/assets/7724a6e9-be6a-48ae-aae7-9becc74db665" />

* **Create Ticket Page** – Upload attachment, assign users
<img width="702" height="579" alt="Screenshot 2025-12-07 044843" src="https://github.com/user-attachments/assets/dd9c40f1-2417-4f41-a348-eae7b9c53619" />

* **Filtered Tickets View** – Open/Pending/Closed
<img width="1920" height="585" alt="Screenshot 2025-12-07 044819" src="https://github.com/user-attachments/assets/eb2c894b-6432-478e-af70-92aa874c0dc5" />

---

## 📂 Project Structure

```
SupportHelpdeskPortal/
│ Web.config
│ site.css
├── Account/
│   ├── Login.aspx
│   ├── Register.aspx
│   ├── Logout.aspx
│   └── Profile.aspx
├── Admin/
│   └── Dashboard.aspx
├── Inventory/
│   ├── Categories.aspx
│   └── Products.aspx
├── Support/
│   ├── TicketCreate.aspx
│   ├── TicketList.aspx
│   └── TicketDetails.aspx
├── Master/
│   └── Site.master
└── Helpers/
    └── DbHelper.cs
```

---

## 🧠 How It Works

### 🔸 Database Access

`DbHelper.cs` centralizes database operations:

* `ExecuteDataTable` – Fetch data
* `ExecuteNonQuery` – Insert/Update/Delete via stored procedures
* `ExecuteSql` – Used for dashboard & profile summary queries

### 🔸 Authentication

Login uses:

```csharp
FormsAuthentication.SetAuthCookie(username, false);
```

Logout uses:

```csharp
FormsAuthentication.SignOut();
Session.Abandon();
```

### 🔸 Authorization

Controlled through Web.config:

* Admin pages restricted to **Admin** role
* Support pages for all authenticated users

### 🔸 Master Page

Provides shared layout:

* Navigation bar
* LoginView for dynamic user links

---

## ⚠️ Notes

This project is designed for **learning/demo purposes**.
For production use, consider adding:

* Password hashing & salting
* Validation & sanitization
* Error logging (Serilog/ELMAH)
* File upload restrictions & virus scanning
* Stored procedure-based pagination

---

## 📧 Contact

For suggestions or improvements, feel free to contribute or reach out.

**Happy Coding! 🎉**
