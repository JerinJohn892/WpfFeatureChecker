using System.Windows;
using WpfCheckerView.ViewModels;
using WpfCheckerView.Services;

namespace WpfCheckerView.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var dataService = new MockDataService();
            DataContext = new MainViewModel(dataService, dataService);
        }
    }
}
