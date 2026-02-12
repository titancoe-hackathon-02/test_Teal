using System.Collections.ObjectModel;
using MachineMaintenanceWPF.Data;
using MachineMaintenanceWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineMaintenanceWPF.ViewModels
{
    public class MaintenanceRecordsViewModel : ViewModelBase
    {
        private readonly MaintenanceDbContext _context;
        private ObservableCollection<MaintenanceRecord> _records = new();

        public ObservableCollection<MaintenanceRecord> Records
        {
            get => _records;
            set => SetProperty(ref _records, value);
        }

        public MaintenanceRecordsViewModel(MaintenanceDbContext context)
        {
            _context = context;
            _ = LoadRecordsAsync();
        }

        private async Task LoadRecordsAsync()
        {
            var records = await _context.MaintenanceRecords
                .OrderByDescending(m => m.CreatedDate)
                .ToListAsync();

            Records = new ObservableCollection<MaintenanceRecord>(records);
        }

        public async Task RefreshAsync()
        {
            await LoadRecordsAsync();
        }
    }
}
