using System.Windows;
using MachineMaintenanceWPF.ViewModels;

namespace MachineMaintenanceWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
