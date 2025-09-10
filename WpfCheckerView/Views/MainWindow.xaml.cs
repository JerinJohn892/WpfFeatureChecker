using System.Windows;
using WpfCheckerView.ViewModels;
using WpfCheckerView.Services;
using Syncfusion.SfSkinManager;

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
            SfSkinManager.ApplyStylesOnApplication = true;
           // SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            var dataService = new MockDataService();
            DataContext = new MainViewModel(dataService, dataService);
            SetDefaultFocus();
        }

        private void SetDefaultFocus()
        {
            idTextBox.Focus();
        }
    }
}
