using System.Windows.Input;

namespace MachineMaintenanceWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowRecordsCommand { get; }
        public ICommand ShowNewMaintenanceCommand { get; }

        private readonly DashboardViewModel _dashboardViewModel;
        private readonly MaintenanceRecordsViewModel _recordsViewModel;
        private readonly MaintenanceFormViewModel _formViewModel;

        public MainWindowViewModel(
            DashboardViewModel dashboardViewModel,
            MaintenanceRecordsViewModel recordsViewModel,
            MaintenanceFormViewModel formViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
            _recordsViewModel = recordsViewModel;
            _formViewModel = formViewModel;

            ShowDashboardCommand = new RelayCommand(_ => CurrentViewModel = _dashboardViewModel);
            ShowRecordsCommand = new RelayCommand(_ => CurrentViewModel = _recordsViewModel);
            ShowNewMaintenanceCommand = new RelayCommand(_ => CurrentViewModel = _formViewModel);

            // Show dashboard by default
            CurrentViewModel = _dashboardViewModel;
        }
    }
}
