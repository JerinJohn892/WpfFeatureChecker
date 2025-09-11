using System.Windows;
using WpfCheckerView.ViewModels;
using WpfCheckerView.Services;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.CellGrid;
using WpfCheckerView.Models;

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

        private void DataGrid_QueryCoveredRange(object? sender, GridQueryCoveredRangeEventArgs e)
        {
            if (e.RowColumnIndex.RowIndex <= 0 || e.RowColumnIndex.ColumnIndex <= 0)
                return;

            var column = dataGrid.Columns[e.RowColumnIndex.ColumnIndex - 1];
            if (column == null)
                return;

            if (column.MappingName == nameof(Employee.Id) || column.MappingName == nameof(Employee.Name))
                return;

            var records = dataGrid.View.Records;
            var provider = dataGrid.View.GetPropertyAccessProvider();
            int rowIndex = e.RowColumnIndex.RowIndex;
            int recordIndex = rowIndex - 1;

            var value = provider.GetValue(records[recordIndex].Data, column.MappingName);

            int start = rowIndex;
            for (int i = recordIndex - 1; i >= 0; i--)
            {
                var prev = provider.GetValue(records[i].Data, column.MappingName);
                if (!Equals(prev, value))
                    break;
                start--;
            }

            int end = rowIndex;
            for (int i = recordIndex + 1; i < records.Count; i++)
            {
                var next = provider.GetValue(records[i].Data, column.MappingName);
                if (!Equals(next, value))
                    break;
                end++;
            }

            if (end > start)
            {
                e.Range = new CoveredCellInfo(start, e.RowColumnIndex.ColumnIndex, end, e.RowColumnIndex.ColumnIndex);
                e.Handled = true;
            }
        }
    }
}
