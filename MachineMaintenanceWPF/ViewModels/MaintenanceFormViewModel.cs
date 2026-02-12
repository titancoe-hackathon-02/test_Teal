using System.Windows.Input;
using MachineMaintenanceWPF.Data;
using MachineMaintenanceWPF.Models;

namespace MachineMaintenanceWPF.ViewModels
{
    public class MaintenanceFormViewModel : ViewModelBase
    {
        private readonly MaintenanceDbContext _context;
        private string _machineId = string.Empty;
        private string _machineName = string.Empty;
        private MaintenanceType _maintenanceType;
        private Priority _priority;
        private DateTime _scheduledDate = DateTime.Today;
        private string _technician = string.Empty;
        private decimal? _estimatedHours;
        private MaintenanceStatus _status;
        private string? _description;
        private string? _notes;

        public string MachineId
        {
            get => _machineId;
            set => SetProperty(ref _machineId, value);
        }

        public string MachineName
        {
            get => _machineName;
            set => SetProperty(ref _machineName, value);
        }

        public MaintenanceType MaintenanceType
        {
            get => _maintenanceType;
            set => SetProperty(ref _maintenanceType, value);
        }

        public Priority Priority
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }

        public DateTime ScheduledDate
        {
            get => _scheduledDate;
            set => SetProperty(ref _scheduledDate, value);
        }

        public string Technician
        {
            get => _technician;
            set => SetProperty(ref _technician, value);
        }

        public decimal? EstimatedHours
        {
            get => _estimatedHours;
            set => SetProperty(ref _estimatedHours, value);
        }

        public MaintenanceStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string? Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand ClearCommand { get; }

        public MaintenanceFormViewModel(MaintenanceDbContext context)
        {
            _context = context;
            SaveCommand = new RelayCommand(async _ => await SaveAsync());
            ClearCommand = new RelayCommand(_ => Clear());
        }

        private async Task SaveAsync()
        {
            var record = new MaintenanceRecord
            {
                MachineId = MachineId,
                MachineName = MachineName,
                MaintenanceType = MaintenanceType,
                Priority = Priority,
                ScheduledDate = ScheduledDate,
                Technician = Technician,
                EstimatedHours = EstimatedHours,
                Status = Status,
                Description = Description,
                Notes = Notes,
                CreatedDate = DateTime.Now
            };

            _context.MaintenanceRecords.Add(record);
            await _context.SaveChangesAsync();

            System.Windows.MessageBox.Show("Maintenance record saved successfully!", "Success", 
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            
            Clear();
        }

        private void Clear()
        {
            MachineId = string.Empty;
            MachineName = string.Empty;
            MaintenanceType = MaintenanceType.Preventive;
            Priority = Priority.Medium;
            ScheduledDate = DateTime.Today;
            Technician = string.Empty;
            EstimatedHours = null;
            Status = MaintenanceStatus.Scheduled;
            Description = null;
            Notes = null;
        }
    }
}
