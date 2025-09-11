using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.Windows.Controls.Grid;
using System.Reflection;
using System.Windows;
using WpfCheckerView.Models;
using WpfCheckerView.Services;
using WpfCheckerView.ViewModels;
using GridQueryCoveredRangeEventArgs = Syncfusion.UI.Xaml.Grid.GridQueryCoveredRangeEventArgs;

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
            //SfSkinManager.ApplyStylesOnApplication = true;
            // SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            var dataService = new MockDataService();
            DataContext = new MainViewModel(dataService, dataService);
            SetDefaultFocus();
            dataGrid.ItemsSourceChanged += dataGrid_ItemsSourceChanged;
            dataGrid.QueryCoveredRange += dataGrid_QueryCoveredRange;
            // dataGrid.QueryCoveredRange += DataGrid_QueryCoveredRange;
            // dataGrid.SelectionUnit = GridSelectionUnit.Cell;
            // dataGrid.NavigationMode = Syncfusion.UI.Xaml.Grid.NavigationMode.Cell;
        }

        private void SetDefaultFocus()
        {
            idTextBox.Focus();
        }
        //private void DataGrid_QueryCoveredRange(object? sender, GridQueryCoveredRangeEventArgs e)
        //{
        //    var grid = sender as SfDataGrid;
        //    if (grid == null)
        //        return;

        //    if (e.RowColumnIndex.RowIndex <= 0 || e.RowColumnIndex.ColumnIndex <= 0)
        //        return;

        //    //if (e.RowColumnIndex.ColumnIndex == 1)
        //    //{

        //    //    if (e.RowColumnIndex.RowIndex >= 1 && e.RowColumnIndex.RowIndex <= 5)
        //    //    {
        //    //        e.Range = new CoveredCellInfo(1, 1, 1, 5);
        //    //        e.Handled = true;
        //    //    }
        //    //}

        //    var column = grid.Columns[e.RowColumnIndex.ColumnIndex - 1];
        //    if (column.MappingName == nameof(Employee.Id) || column.MappingName == nameof(Employee.Name))
        //        return;

        //    var recordIndex = grid.ResolveToRecordIndex(e.RowColumnIndex.RowIndex);
        //    if (recordIndex < 0)
        //        return;

        //    var records = grid.View.Records;
        //    if (recordIndex >= records.Count)
        //        return;

        //    var data = records[recordIndex].Data;
        //    var property = data.GetType().GetProperty(column.MappingName, BindingFlags.Public | BindingFlags.Instance);
        //    if (property == null)
        //        return;

        //    var cellValue = property.GetValue(data);

        //    int startRowIndex = e.RowColumnIndex.RowIndex;
        //    int endRowIndex = e.RowColumnIndex.RowIndex;

        //    for (int i = recordIndex - 1; i >= 0; i--)
        //    {
        //        var previousData = records[i].Data;
        //        var previousValue = property.GetValue(previousData);
        //        if (!Equals(cellValue, previousValue))
        //            break;
        //        startRowIndex = grid.ResolveToRowIndex(i);
        //    }

        //    for (int i = recordIndex + 1; i < records.Count; i++)
        //    {
        //        var nextData = records[i].Data;
        //        var nextValue = property.GetValue(nextData);
        //        if (!Equals(cellValue, nextValue))
        //            break;
        //        endRowIndex = grid.ResolveToRowIndex(i);
        //    }

        //    if (startRowIndex != endRowIndex)
        //    {
        //        e.Range = new CoveredCellInfo(startRowIndex, e.RowColumnIndex.ColumnIndex, endRowIndex, e.RowColumnIndex.ColumnIndex);
        //        e.Handled = true;
        //    }
        //}
        //private void DataGrid_QueryCoveredRange(object? sender, GridQueryCoveredRangeEventArgs e)
        //{
        //    if (e.RowColumnIndex.RowIndex <= 0 || e.RowColumnIndex.ColumnIndex <= 0)
        //        return;

        //    var column = dataGrid.Columns[e.RowColumnIndex.ColumnIndex - 1];
        //    if (column == null)
        //        return;

        //    if (column.MappingName == nameof(Employee.Id) || column.MappingName == nameof(Employee.Name))
        //        return;

        //    var records = dataGrid.View.Records;
        //    var provider = dataGrid.View.GetPropertyAccessProvider();
        //    int rowIndex = e.RowColumnIndex.RowIndex;
        //    int recordIndex = rowIndex - 1;

        //    var value = provider.GetValue(records[recordIndex].Data, column.MappingName);

        //    int start = rowIndex;
        //    for (int i = recordIndex - 1; i >= 0; i--)
        //    {
        //        var prev = provider.GetValue(records[i].Data, column.MappingName);
        //        if (!Equals(prev, value))
        //            break;
        //        start--;
        //    }

        //    int end = rowIndex;
        //    for (int i = recordIndex + 1; i < records.Count; i++)
        //    {
        //        var next = provider.GetValue(records[i].Data, column.MappingName);
        //        if (!Equals(next, value))
        //            break;
        //        end++;
        //    }

        //    if (end > start)
        //    {
        //        e.Range = new Syncfusion.UI.Xaml.Grid.CoveredCellInfo(start, e.RowColumnIndex.ColumnIndex, end, e.RowColumnIndex.ColumnIndex);
        //        e.Handled = true;
        //    }
        //}
        /// <summary>
        /// Reflector for SfDataGrid’s data.
        /// </summary>
        IPropertyAccessProvider reflector = null;

        /// <summary>
        /// ItemsSourceChanged event handler.
        /// </summary>

        void dataGrid_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e)
        {

            if (dataGrid.View != null)
                reflector = dataGrid.View.GetPropertyAccessProvider();

            else
                reflector = null;
        }

        /// <summary>
        /// QueryCoveredRange event handler
        /// </summary>

        void dataGrid_QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            var range = GetRange(e.GridColumn, e.RowColumnIndex.RowIndex, e.RowColumnIndex.ColumnIndex, e.Record);

            if (range == null)
                return;

            // You can know that the range is already exist in Covered Cells by IsInRange method.

            if (!dataGrid.CoveredCells.IsInRange(range))
            {
                e.Range = range;
                e.Handled = true;
            }

            //If the calculated range is already exist in CoveredCells, you can get the range using SfDataGrid.GetConflictRange (CoveredCellInfo coveredCellInfo) extension method.
        }

        /// <summary>
        /// Method to get the covered range based on cell value.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="rowData"></param>
        /// <returns> Compares the adjacent cell value and returns the range </returns>
        /// <remark> If the method find that the adjacent values are equal by horizontal then it will merge vertically. And vice versa</remarks>

        private CoveredCellInfo GetRange(GridColumn column, int rowIndex, int columnIndex, object rowData)
        {
            var range = new CoveredCellInfo(columnIndex, columnIndex, rowIndex, rowIndex);
            if (column.MappingName == nameof(Employee.Department))
                return null;

            var range = new CoveredCellInfo(columnIndex, columnIndex, rowIndex, rowIndex);

            // total rows count.
            int recordsCount = this.dataGrid.GroupColumnDescriptions.Count != 0 ?
            (this.dataGrid.View.TopLevelGroup.DisplayElements.Count + this.dataGrid.TableSummaryRows.Count + this.dataGrid.UnBoundRows.Count + (this.dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0)) :
            (this.dataGrid.View.Records.Count + this.dataGrid.TableSummaryRows.Count + this.dataGrid.UnBoundRows.Count + (this.dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0));

            int previousRowIndex = -1;
            int nextRowIndex = -1;

            var currentId = reflector.GetFormattedValue(rowData, nameof(Employee.Id));

            // Get previous row data based on Id.
            var startIndex = dataGrid.ResolveStartIndexBasedOnPosition();

            for (int i = rowIndex - 1; i >= startIndex; i--)
            {
                var previousData = this.dataGrid.GetRecordEntryAtRowIndex(i);

                if (previousData == null || !previousData.IsRecords)
                    break;
                var previousId = reflector.GetFormattedValue((previousData as RecordEntry).Data, nameof(Employee.Id));

                if (previousId == null)
                    break;

                if (!previousId.Equals(currentId))
                    break;
                previousRowIndex = i;
            }

            // Get next row data based on Id.
            for (int i = rowIndex + 1; i < recordsCount + 1; i++)
            {
                var nextData = this.dataGrid.GetRecordEntryAtRowIndex(i);

                if (nextData == null || !nextData.IsRecords)
                    break;
                var nextId = reflector.GetFormattedValue((nextData as RecordEntry).Data, nameof(Employee.Id));

                if (nextId == null)
                    break;

                if (!nextId.Equals(currentId))
                    break;
                nextRowIndex = i;
            }

            if (previousRowIndex != -1 || nextRowIndex != -1)
            {

                if (previousRowIndex != -1)
                    range = new CoveredCellInfo(range.Left, range.Right, previousRowIndex, range.Bottom);

                if (nextRowIndex != -1)
                    range = new CoveredCellInfo(range.Left, range.Right, range.Top, nextRowIndex);
                return range;
            }
            return null;
        }

    }
}
