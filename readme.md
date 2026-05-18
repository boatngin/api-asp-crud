# Backapi

ASP.NET Core Web API CRUD Example using:

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Repository Pattern
- Service Layer Architecture

---

# Features

- Add User
- Get Users Datatable
- Get User By Id
- Update User
- Delete User
- Search

---

# Project Structure

```text
Backapi/
│
├── Controllers/
│   └── UsersController.cs
│
├── Services/
│   ├── Interfaces/
│   │   └── IUserService.cs
│   └── UserService.cs
│
├── Repositories/
│   ├── Interfaces/
│   │   └── IUserRepository.cs
│   └── UserRepository.cs
│
├── DTOs/
│   └── UserDataReq.cs
│
├── Models/
│   └── User.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

# Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Docker

---

# Requirements

- .NET SDK 10
- SQL Server

---

# Configure Connection String

## appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1,1433;Database=UserDb;User Id=sa;Password=StrongPass123!;Encrypt=False;TrustServerCertificate=True;"
  }
}
```

---

# Install Dependencies

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

# Install EF CLI

```bash
dotnet tool install --global dotnet-ef
```

If command not found:

```bash
export PATH="$PATH:$HOME/.dotnet/tools"
source ~/.zshrc
```

---

# Create Migration

```bash
dotnet ef migrations add Init
```

---

# Update Database

```bash
dotnet ef database update
```

---

# Run Project

```bash
dotnet run
```

Default URL:

```text
http://localhost:5069
```

---

# API Endpoints

---

## Add User

### POST `/api/user`

Request Body:

```json
{
  "fname": "Boat",
  "lname": "Engine",
  "email": "boat@test.com",
  "phone": "0999999999",
  "roleId": 1,
  "username": "boat",
  "password": "1234"
}
```

---

## Get Users Datatable

### POST `/api/users/Datatable`

Request Body:

```json
{
  "orderBy": "fname",
  "orderDirection": "asc",
  "pageNumber": 1,
  "pageSize": 10,
  "search": "boat"
}
```

---

## Get User By Id

### GET `/api/users/{id}`

Example:

```text
GET /api/users/1
```

---

## Update User

### PUT `/api/user/{id}`

Request Body:

```json
{
  "fname": "New",
  "lname": "Name",
  "email": "new@test.com",
  "phone": "0888888888",
  "roleId": 2,
  "username": "newuser",
  "password": "9999"
}
```

---

## Delete User

### DELETE `/api/user/{id}`

Example:

```text
DELETE /api/user/1
```

---
