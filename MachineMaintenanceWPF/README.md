# Machine Maintenance WPF Application

A Windows desktop application for managing machine maintenance records built with WPF and Entity Framework Core.

## Features

- ✅ Industrial dashboard with real-time monitoring
- ✅ MVVM architecture pattern
- ✅ Full CRUD operations for maintenance records
- ✅ Entity Framework Core with SQL Server
- ✅ Professional WPF UI matching industrial design
- ✅ Dependency injection
- ✅ Data binding with INotifyPropertyChanged

## Prerequisites

- .NET 8.0 SDK or later
- SQL Server (LocalDB or SQL Server Express)
- Visual Studio 2022 (recommended) or VS Code

## Getting Started

### 1. Restore Dependencies

```powershell
cd MachineMaintenanceWPF
dotnet restore
```

### 2. Create Database

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Run the Application

```powershell
dotnet run
```

Or press F5 in Visual Studio.

## Project Structure

```
MachineMaintenanceWPF/
├── Models/                     # Data models
│   └── MaintenanceRecord.cs
├── ViewModels/                 # MVVM ViewModels
│   ├── ViewModelBase.cs
│   ├── RelayCommand.cs
│   ├── MainWindowViewModel.cs
│   ├── DashboardViewModel.cs
│   ├── MaintenanceRecordsViewModel.cs
│   └── MaintenanceFormViewModel.cs
├── Views/                      # XAML Views
│   ├── DashboardView.xaml
│   ├── MaintenanceRecordsView.xaml
│   └── MaintenanceFormView.xaml
├── Data/
│   └── MaintenanceDbContext.cs # EF Core DbContext
├── App.xaml                    # Application resources
├── App.xaml.cs                 # Application startup with DI
├── MainWindow.xaml             # Main window
├── appsettings.json            # Configuration
└── MachineMaintenanceWPF.csproj
```

## Architecture

- **MVVM Pattern**: Separation of concerns with ViewModels
- **Dependency Injection**: Using Microsoft.Extensions.DependencyInjection
- **Data Binding**: Two-way binding for forms and display
- **Entity Framework Core**: Database access and migrations
- **Command Pattern**: RelayCommand for button actions

## Technologies Used

- WPF (.NET 8.0)
- Entity Framework Core 8.0
- SQL Server
- XAML
- C# 12

## Database

The application uses SQL Server LocalDB by default. Connection string can be modified in `appsettings.json`.

## License

Free to use for educational and commercial purposes.
