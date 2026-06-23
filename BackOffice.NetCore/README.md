# IMI POS Back Office - .NET Core C# Version

This is a complete rewrite of the original VB.NET Back Office application into .NET Core 8.0 C# with a modern architecture using ASP.NET Core Web API (Backend) and ASP.NET Core MVC (Frontend).

## Project Structure

```
BackOffice.NetCore/
├── BackOffice.API/          # ASP.NET Core Web API (Backend)
│   ├── Controllers/         # API Controllers
│   ├── Data/               # Database Context
│   ├── Models/             # Data Models
│   ├── Services/           # Business Logic Services
│   └── Program.cs          # API Configuration
│
└── BackOffice.MVC/         # ASP.NET Core MVC (Frontend)
    ├── Controllers/        # MVC Controllers
    ├── Models/            # View Models
    ├── Services/          # API Client Service
    ├── Views/             # Razor Views
    └── Program.cs         # MVC Configuration
```

## Technology Stack

### Backend (API)
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core 8.0
- Pomelo.EntityFrameworkCore.MySql (MySQL Provider)
- JWT Authentication
- Swagger/OpenAPI

### Frontend (MVC)
- .NET 8.0
- ASP.NET Core MVC
- Bootstrap 5.3
- Session-based authentication with JWT tokens

## Features

### Converted from VB.NET
- ✅ User Authentication (Admin & Supervisor only)
- ✅ Product Management (CRUD operations)
- ✅ Customer Management (CRUD operations)
- ✅ Discount Management (CRUD operations)
- ✅ User Management (Admin only)
- ✅ Sales Reports
- ✅ JWT-based API authentication
- ✅ Role-based authorization

### Architecture Improvements
- Separated Backend (API) and Frontend (MVC)
- RESTful API design
- Entity Framework Core with proper relationships
- JWT token authentication
- CORS configuration for secure API access
- Modern responsive UI with Bootstrap 5

## Prerequisites

- .NET 8.0 SDK or later
- MySQL Server 5.0 or later
- Visual Studio 2022 or VS Code (optional)

## Database Setup

1. **Import the database:**
   ```bash
   cd database
   mysql -u root -p < pos.sql
   ```

2. **Update connection string in `BackOffice.API/appsettings.json`:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=pos;User=root;Password=your_password;"
     }
   }
   ```

## Configuration

### Backend API Configuration

Edit `BackOffice.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=pos;User=root;Password=your_password;"
  },
  "Jwt": {
    "Key": "YourSecretKeyHere123456789012345678901234567890",
    "Issuer": "BackOfficeAPI",
    "Audience": "BackOfficeMVC"
  },
  "Cors": {
    "AllowedOrigins": "http://localhost:5001,https://localhost:5001"
  }
}
```

### Frontend MVC Configuration

Edit `BackOffice.MVC/appsettings.json`:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7000"
  }
}
```

## Running the Application

### Option 1: Using Visual Studio

1. Open `BackOffice.NetCore` folder in Visual Studio 2022
2. Set multiple startup projects:
   - Right-click solution → Properties → Multiple startup projects
   - Set both `BackOffice.API` and `BackOffice.MVC` to "Start"
3. Press F5 to run

### Option 2: Using Command Line

**Terminal 1 - Start API:**
```bash
cd BackOffice.NetCore/BackOffice.API
dotnet restore
dotnet run
```
The API will start at `https://localhost:7000` (or `http://localhost:5000`)

**Terminal 2 - Start MVC:**
```bash
cd BackOffice.NetCore/BackOffice.MVC
dotnet restore
dotnet run
```
The MVC app will start at `https://localhost:5001` (or `http://localhost:5002`)

### Option 3: Using Docker (Future Enhancement)

Docker support can be added by creating Dockerfile for each project.

## Default Login Credentials

Based on the database:
- **Admin User:**
  - Username: `admin`
  - Password: `12345`
  
- **Supervisor User:**
  - Username: `imi`
  - Password: `imi`

**Note:** Only Admin and Supervisor roles can access the Back Office application.

## API Documentation

Once the API is running, access Swagger UI at:
```
https://localhost:7000/swagger
```

### Available API Endpoints

#### Authentication
- `POST /api/auth/login` - User login

#### Products
- `GET /api/produk` - Get all products
- `GET /api/produk/{id}` - Get product by ID
- `POST /api/produk` - Create new product
- `PUT /api/produk/{id}` - Update product
- `DELETE /api/produk/{id}` - Delete product

#### Customers
- `GET /api/pelanggan` - Get all customers (with optional filters)
- `GET /api/pelanggan/{id}` - Get customer by ID
- `POST /api/pelanggan` - Create new customer
- `PUT /api/pelanggan/{id}` - Update customer
- `DELETE /api/pelanggan/{id}` - Delete customer

#### Discounts
- `GET /api/diskon` - Get all discounts
- `GET /api/diskon/{id}` - Get discount by ID
- `POST /api/diskon` - Create new discount
- `PUT /api/diskon/{id}` - Update discount
- `DELETE /api/diskon/{id}` - Delete discount

#### Users (Admin Only)
- `GET /api/pengguna` - Get all users
- `GET /api/pengguna/{namaUser}` - Get user by username
- `POST /api/pengguna` - Create new user
- `PUT /api/pengguna/{namaUser}` - Update user
- `DELETE /api/pengguna/{namaUser}` - Delete user

#### Reports
- `GET /api/laporan/penjualan` - Get sales report (with date filters)
- `GET /api/laporan/penjualan/summary` - Get sales summary

## Project Differences from Original VB.NET

### Architecture
- **Original:** Monolithic Windows Forms application with direct database access
- **New:** Separated Backend API and Frontend MVC with RESTful architecture

### Database Access
- **Original:** Direct MySQL queries using MySqlCommand
- **New:** Entity Framework Core with LINQ queries

### Authentication
- **Original:** Session-based with direct database validation
- **New:** JWT token-based authentication with secure API calls

### UI
- **Original:** Windows Forms desktop application
- **New:** Web-based responsive UI with Bootstrap 5

### Security
- **Original:** Basic authentication
- **New:** JWT tokens, CORS, role-based authorization

## Development Notes

### Adding New Features

1. **Add API Endpoint:**
   - Create/modify controller in `BackOffice.API/Controllers/`
   - Add necessary models in `BackOffice.API/Models/`
   - Update DbContext if needed

2. **Add MVC View:**
   - Create/modify controller in `BackOffice.MVC/Controllers/`
   - Add view models in `BackOffice.MVC/Models/`
   - Create Razor views in `BackOffice.MVC/Views/`

### Database Migrations

To create a new migration:
```bash
cd BackOffice.API
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Troubleshooting

### API Connection Issues
- Ensure the API is running before starting the MVC app
- Check that the `BaseUrl` in MVC `appsettings.json` matches the API URL
- Verify CORS settings in API `appsettings.json`

### Database Connection Issues
- Verify MySQL server is running
- Check connection string credentials
- Ensure the `pos` database exists

### Authentication Issues
- Clear browser cookies/session
- Verify JWT settings match between API and MVC
- Check user roles in database (only admin/supervisor can access)

## Future Enhancements

- [ ] Add Docker support
- [ ] Implement package management functionality
- [ ] Add more detailed sales analytics
- [ ] Implement real-time notifications
- [ ] Add export functionality for reports (PDF, Excel)
- [ ] Implement audit logging
- [ ] Add unit and integration tests
- [ ] Implement caching for better performance

## License

This project maintains the same license as the original VB.NET version.

## Support

For issues or questions, please refer to the original project documentation or contact the development team.

---

**Migration Date:** 2024
**Original Version:** VB.NET Framework 3.5
**New Version:** .NET Core 8.0 C#