using HypnosisRising.CaseRecorder.ViewModels;
using System.Windows;

namespace HypnosisRising.CaseRecorder.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel vm = (DataContext as MainWindowViewModel);
            vm.PopulateContent();
        }
    }
}
