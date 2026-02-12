using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MachineMaintenanceWPF.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MaintenanceDbContext>
    {
        public MaintenanceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MaintenanceDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new MaintenanceDbContext(optionsBuilder.Options);
        }
    }
}
