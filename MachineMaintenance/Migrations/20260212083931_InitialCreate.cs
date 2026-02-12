using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MachineMaintenance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaintenanceType = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Technician = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstimatedHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ActualHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "ActualHours", "CompletionDate", "CreatedDate", "Description", "EstimatedHours", "LastUpdated", "MachineId", "MachineName", "MaintenanceType", "Notes", "Priority", "ScheduledDate", "Status", "Technician" },
                values: new object[,]
                {
                    { 1, 2.5m, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine preventive maintenance", 3m, null, "MCH-001", "CNC Lathe", 0, null, 1, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "John Smith" },
                    { 2, 5m, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Replace worn bearings", 4m, null, "MCH-002", "Milling Machine", 1, null, 2, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sarah Johnson" },
                    { 3, null, null, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly inspection and lubrication", 2m, null, "MCH-003", "Hydraulic Press", 0, null, 0, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Mike Wilson" },
                    { 4, null, null, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Motor malfunction - urgent repair needed", 6m, null, "MCH-004", "Grinding Machine", 3, null, 3, new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "John Smith" },
                    { 5, null, null, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sensor calibration based on vibration analysis", 3m, null, "MCH-005", "Welding Robot", 2, null, 1, new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Emily Davis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRecords");
        }
    }
}
