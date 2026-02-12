namespace MachineMaintenanceWPF.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private string _currentShift = "A";
        private int _runTime = 0;
        private int _downTime = 0;
        private int _idleTime = 0;
        private double _passCount = 0.00;
        private double _yield = 0.00;
        private double _overallCount = 0.00;
        private double _uph = 0.00;

        public string CurrentShift
        {
            get => _currentShift;
            set => SetProperty(ref _currentShift, value);
        }

        public int RunTime
        {
            get => _runTime;
            set => SetProperty(ref _runTime, value);
        }

        public int DownTime
        {
            get => _downTime;
            set => SetProperty(ref _downTime, value);
        }

        public int IdleTime
        {
            get => _idleTime;
            set => SetProperty(ref _idleTime, value);
        }

        public double PassCount
        {
            get => _passCount;
            set => SetProperty(ref _passCount, value);
        }

        public double Yield
        {
            get => _yield;
            set => SetProperty(ref _yield, value);
        }

        public double OverallCount
        {
            get => _overallCount;
            set => SetProperty(ref _overallCount, value);
        }

        public double UPH
        {
            get => _uph;
            set => SetProperty(ref _uph, value);
        }

        public int TotalTime => RunTime + DownTime + IdleTime;
    }
}
