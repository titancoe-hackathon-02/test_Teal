using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MachineMaintenanceWPF.Data;
using MachineMaintenanceWPF.ViewModels;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MachineMaintenanceWPF
{
    public partial class App : Application
    {
        private ServiceProvider? serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // Database
            services.AddDbContext<MaintenanceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<MaintenanceRecordsViewModel>();
            services.AddTransient<MaintenanceFormViewModel>();

            // Windows
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = serviceProvider?.GetRequiredService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
