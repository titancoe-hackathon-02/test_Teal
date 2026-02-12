using MachineMaintenanceWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineMaintenanceWPF.Data
{
    public class MaintenanceDbContext : DbContext
    {
        public MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed sample data
            modelBuilder.Entity<MaintenanceRecord>().HasData(
                new MaintenanceRecord
                {
                    Id = 1,
                    MachineId = "MCH-001",
                    MachineName = "CNC Lathe",
                    MaintenanceType = MaintenanceType.Preventive,
                    Priority = Priority.Medium,
                    ScheduledDate = new DateTime(2026, 2, 10),
                    Technician = "John Smith",
                    Status = MaintenanceStatus.Completed,
                    EstimatedHours = 3,
                    ActualHours = 2.5m,
                    CompletionDate = new DateTime(2026, 2, 10),
                    Description = "Routine preventive maintenance",
                    CreatedDate = new DateTime(2026, 2, 5)
                },
                new MaintenanceRecord
                {
                    Id = 2,
                    MachineId = "MCH-002",
                    MachineName = "Milling Machine",
                    MaintenanceType = MaintenanceType.Corrective,
                    Priority = Priority.High,
                    ScheduledDate = new DateTime(2026, 2, 11),
                    Technician = "Sarah Johnson",
                    Status = MaintenanceStatus.Completed,
                    EstimatedHours = 4,
                    ActualHours = 5m,
                    CompletionDate = new DateTime(2026, 2, 11),
                    Description = "Replace worn bearings",
                    CreatedDate = new DateTime(2026, 2, 8)
                },
                new MaintenanceRecord
                {
                    Id = 3,
                    MachineId = "MCH-003",
                    MachineName = "Hydraulic Press",
                    MaintenanceType = MaintenanceType.Preventive,
                    Priority = Priority.Low,
                    ScheduledDate = new DateTime(2026, 2, 12),
                    Technician = "Mike Wilson",
                    Status = MaintenanceStatus.Scheduled,
                    EstimatedHours = 2,
                    Description = "Monthly inspection and lubrication",
                    CreatedDate = new DateTime(2026, 2, 1)
                }
            );
        }
    }
}
