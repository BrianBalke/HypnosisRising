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

        /// <summary>
        /// Triggers content population in the view model after
        /// <see cref="Prism.Modularity.IModule"/> registration is complete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel vm = (DataContext as MainWindowViewModel);
            vm.PopulateContent();
        }
    }
}
