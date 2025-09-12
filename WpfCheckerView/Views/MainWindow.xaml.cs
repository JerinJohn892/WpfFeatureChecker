using Syncfusion.SfSkinManager;
using System.Windows;
using WpfCheckerView.Services;
using WpfCheckerView.ViewModels;

namespace WpfCheckerView.Views
{
    /// <summary>
    /// Main application window that hosts the employee entry form and data grid.
    /// The grid relies on <see cref="CustomControls.SfDataGridExt"/> to provide
    /// automatic row merging without any code-behind configuration.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SfSkinManager.ApplyStylesOnApplication = true;

            var dataService = new MockDataService();
            DataContext = new MainViewModel(dataService, dataService);
            idTextBox.Focus();
        }
    }
}

