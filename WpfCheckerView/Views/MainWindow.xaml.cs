using Syncfusion.Data;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.Windows.Controls.Grid;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
        private SfDataGrid dataGrid;
        private string mergeColumnName;
        private string[] ignoreColumnName;
        public MainWindow()
        {
            InitializeComponent();
            SfSkinManager.ApplyStylesOnApplication = true;
            // SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            var dataService = new MockDataService();
            DataContext = new MainViewModel(dataService, dataService);
            SetDefaultFocus();
            mergeColumnName = nameof(Employee.Id);
            ignoreColumnName = new string[]
            { 
                nameof(Employee.Department) ,
                nameof(Employee.Salary)
            };
            dataGrid = empDataGrid;
            dataGrid.ItemsSourceChanged += dataGrid_ItemsSourceChanged;
            dataGrid.QueryCoveredRange += dataGrid_QueryCoveredRange;
            // dataGrid.SelectionUnit = GridSelectionUnit.Cell;
            // dataGrid.NavigationMode = Syncfusion.UI.Xaml.Grid.NavigationMode.Cell;
        }

        private void SetDefaultFocus()
        {
            idTextBox.Focus();
        }

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
        }

        /// <summary>
        /// Method to get the covered range based on cell value.
        /// </summary>
        /// <param name="column">Column that contains the current cell.</param>
        /// <param name="rowIndex">Row index of the current cell.</param>
        /// <param name="columnIndex">Column index of the current cell.</param>
        /// <param name="rowData">Data object associated with the current row.</param>
        /// <returns>
        /// A <see cref="CoveredCellInfo"/> representing a range to be covered when
        /// adjacent rows share the same employee id; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// The method searches upward and downward from the given cell to find
        /// consecutive rows that have the same <see cref="mergeColumnName"/>. When
        /// matching rows are found, their indices are used to expand the returned
        /// range so that the grid can render a single cell spanning those rows.
        /// </remarks>

        private CoveredCellInfo GetRange(GridColumn column, int rowIndex, int columnIndex, object rowData)
        {
            // Ignore the column – if it should never be merged.
            if (IsNonMergeableColumn(column))
                return null;

            // Compute the total number of rows displayed in the grid.
            int recordsCount = this.dataGrid.GroupColumnDescriptions.Count != 0 ?
                (this.dataGrid.View.TopLevelGroup.DisplayElements.Count + this.dataGrid.TableSummaryRows.Count + this.dataGrid.UnBoundRows.Count + (this.dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0)) :
                (this.dataGrid.View.Records.Count + this.dataGrid.TableSummaryRows.Count + this.dataGrid.UnBoundRows.Count + (this.dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0));

            var currentId = reflector.GetFormattedValue(rowData, mergeColumnName);

            // Determine the starting index for visible records.
            var startIndex = dataGrid.ResolveStartIndexBasedOnPosition();

            // Search upwards for matching rows.
            int startRow = rowIndex;
            for (int i = rowIndex - 1; i >= startIndex; i--)
            {
                var previousData = this.dataGrid.GetRecordEntryAtRowIndex(i);

                if (previousData == null || !previousData.IsRecords)
                    break;

                var previousId = reflector.GetFormattedValue((previousData as RecordEntry).Data, mergeColumnName);
                if (previousId == null || !previousId.Equals(currentId))
                    break;

                startRow = i;
            }

            // Search downwards for matching rows.
            int endRow = rowIndex;
            for (int i = rowIndex + 1; i < recordsCount + 1; i++)
            {
                var nextData = this.dataGrid.GetRecordEntryAtRowIndex(i);

                if (nextData == null || !nextData.IsRecords)
                    break;

                var nextId = reflector.GetFormattedValue((nextData as RecordEntry).Data, mergeColumnName);
                if (nextId == null || !nextId.Equals(currentId))
                    break;

                endRow = i;
            }

            // If the range was extended, return it. Otherwise, no merge is necessary.
            return (startRow != rowIndex || endRow != rowIndex)
                ? new CoveredCellInfo(columnIndex, columnIndex, startRow, endRow)
                : null;
        }

        private bool IsNonMergeableColumn(GridColumn column)
        {
            foreach (var name in ignoreColumnName)
            {
                if (column.MappingName == name)
                    return true;
            }
            return false;
        }
    }
}
