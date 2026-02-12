# Machine Maintenance Management System

A comprehensive ASP.NET Core MVC application for managing machine maintenance records.

## Features

- ✅ Dashboard with statistics overview
- ✅ Create, Read, Update, Delete (CRUD) maintenance records
- ✅ Track different maintenance types (Preventive, Corrective, Predictive, Emergency)
- ✅ Priority management (Low, Medium, High, Critical)
- ✅ Status tracking (Scheduled, In Progress, Completed, Pending, Cancelled)
- ✅ Machine and technician assignment
- ✅ Time tracking (Estimated vs Actual hours)
- ✅ Responsive design for mobile and desktop
- ✅ Entity Framework Core with SQL Server

## Prerequisites

- .NET 8.0 SDK or later
- SQL Server (LocalDB or SQL Server Express)
- Visual Studio 2022 or VS Code

## Getting Started

### 1. Restore Dependencies

```powershell
cd MachineMaintenance
dotnet restore
```

### 2. Create Database

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create the database with sample data.

### 3. Run the Application

```powershell
dotnet run
```

The application will be available at:
- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000

## Project Structure

```
MachineMaintenance/
├── Controllers/
│   └── MaintenanceController.cs    # Main controller for CRUD operations
├── Models/
│   └── MaintenanceRecord.cs        # Data model with enums
├── Data/
│   └── MaintenanceDbContext.cs     # EF Core DbContext with seed data
├── Views/
│   ├── Maintenance/
│   │   ├── Index.cshtml           # Dashboard & list view
│   │   ├── Create.cshtml          # Create new record
│   │   ├── Edit.cshtml            # Edit existing record
│   │   ├── Details.cshtml         # View record details
│   │   └── Delete.cshtml          # Delete confirmation
│   └── Shared/
│       ├── _Layout.cshtml         # Main layout
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   └── css/
│       └── site.css               # Custom styles
├── Program.cs                     # Application startup
├── appsettings.json              # Configuration
└── MachineMaintenance.csproj     # Project file
```

## Database Schema

**MaintenanceRecords Table:**
- Id (Primary Key)
- MachineId
- MachineName
- MaintenanceType (Enum)
- Priority (Enum)
- ScheduledDate
- Technician
- EstimatedHours
- Status (Enum)
- Description
- Notes
- ActualHours
- CompletionDate
- CreatedDate
- LastUpdated

## Usage

### Dashboard
View overview statistics and all maintenance records in a table format.

### Create Maintenance Record
Click "New Maintenance" to log a new maintenance activity with all required details.

### Edit Record
Update existing records, including adding actual hours and completion date.

### View Details
See complete information about a specific maintenance record.

### Delete Record
Remove maintenance records with confirmation.

## Customization

### Change Database Connection
Edit `appsettings.json` to modify the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your-Connection-String-Here"
}
```

### Modify Enums
Edit the enums in `Models/MaintenanceRecord.cs` to add or change:
- Maintenance Types
- Priority Levels
- Status Options

## Technologies Used

- ASP.NET Core 8.0 MVC
- Entity Framework Core 8.0
- SQL Server
- HTML5, CSS3
- jQuery (for validation)

## License

This project is free to use for educational and commercial purposes.
