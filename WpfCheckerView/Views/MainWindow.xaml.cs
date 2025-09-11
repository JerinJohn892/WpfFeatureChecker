using Syncfusion.Data;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;
using WpfCheckerView.Models;
using WpfCheckerView.Services;
using WpfCheckerView.ViewModels;
using GridQueryCoveredRangeEventArgs = Syncfusion.UI.Xaml.Grid.GridQueryCoveredRangeEventArgs;

namespace WpfCheckerView.Views
{
    /// <summary>
    /// Main application window that hosts the employee entry form and data grid.
    /// <para>
    /// The constructor wires up Syncfusion themes, creates the <see cref="MainViewModel"/>
    /// with a <see cref="MockDataService"/> and configures the grid to merge cells with
    /// identical employee IDs. The process flow is as follows:
    /// <list type="number">
    /// <item><description>Initialize WPF components and apply global themes.</description></item>
    /// <item><description>Create the view model and set it as the <see cref="Window.DataContext"/>.</description></item>
    /// <item><description>Assign focus to the ID text box for quick data entry.</description></item>
    /// <item><description>Hook grid events that provide cell merging and property reflection.</description></item>
    /// </list>
    /// </para>
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SfDataGrid _dataGrid;
        private readonly string _mergeColumnName = nameof(Employee.Id);
        private readonly string[] _ignoredColumns =
        {
            nameof(Employee.Department),
            nameof(Employee.Salary)
        };
        private IPropertyAccessProvider _propertyAccessor;

        public MainWindow()
        {
            InitializeComponent();
            SfSkinManager.ApplyStylesOnApplication = true;

            var dataService = new MockDataService();
            DataContext = new MainViewModel(dataService, dataService);
            SetDefaultFocus();

            _dataGrid = empDataGrid;
            _dataGrid.ItemsSourceChanged += OnItemsSourceChanged;
            _dataGrid.QueryCoveredRange += OnQueryCoveredRange;
            // _dataGrid.SelectionUnit = GridSelectionUnit.Cell;
            // _dataGrid.NavigationMode = Syncfusion.UI.Xaml.Grid.NavigationMode.Cell;
        }

        private void SetDefaultFocus() => idTextBox.Focus();

        /// <summary>
        /// Handles the <see cref="SfDataGrid.ItemsSourceChanged"/> event and captures
        /// a property accessor for reflection-based value comparisons.
        /// </summary>
        private void OnItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e)
        {
            _propertyAccessor = _dataGrid.View != null
                ? _dataGrid.View.GetPropertyAccessProvider()
                : null;
        }

        /// <summary>
        /// Handles the <see cref="SfDataGrid.QueryCoveredRange"/> event to merge
        /// adjacent rows with identical values in the configured column.
        /// </summary>
        private void OnQueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            var range = GetMergeRange(
                e.GridColumn,
                e.RowColumnIndex.RowIndex,
                e.RowColumnIndex.ColumnIndex,
                e.Record);

            if (range == null)
                return;

            // Only assign the range if it is not already covered.
            if (!_dataGrid.CoveredCells.IsInRange(range))
            {
                e.Range = range;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Determines the range of rows that should be merged for the specified cell.
        /// </summary>
        /// <param name="column">Column that contains the current cell.</param>
        /// <param name="rowIndex">Row index of the current cell.</param>
        /// <param name="columnIndex">Column index of the current cell.</param>
        /// <param name="rowData">Data object associated with the current row.</param>
        /// <returns>A <see cref="CoveredCellInfo"/> representing the merge range; otherwise, <c>null</c>.</returns>
        private CoveredCellInfo GetMergeRange(GridColumn column, int rowIndex, int columnIndex, object rowData)
        {
            if (IsIgnoredColumn(column))
                return null;

            int recordsCount = _dataGrid.GroupColumnDescriptions.Count != 0
                ? _dataGrid.View.TopLevelGroup.DisplayElements.Count + _dataGrid.TableSummaryRows.Count + _dataGrid.UnBoundRows.Count + (_dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0)
                : _dataGrid.View.Records.Count + _dataGrid.TableSummaryRows.Count + _dataGrid.UnBoundRows.Count + (_dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0);

            var currentId = _propertyAccessor.GetFormattedValue(rowData, _mergeColumnName);
            var startIndex = _dataGrid.ResolveStartIndexBasedOnPosition();

            int startRow = FindStartRow(rowIndex, startIndex, currentId);
            int endRow = FindEndRow(rowIndex, recordsCount, currentId);

            return (startRow != rowIndex || endRow != rowIndex)
                ? new CoveredCellInfo(columnIndex, columnIndex, startRow, endRow)
                : null;
        }

        private int FindStartRow(int rowIndex, int startIndex, object currentId)
        {
            for (int i = rowIndex - 1; i >= startIndex; i--)
            {
                var previousData = _dataGrid.GetRecordEntryAtRowIndex(i);
                if (previousData == null || !previousData.IsRecords)
                    break;

                var previousId = _propertyAccessor.GetFormattedValue((previousData as RecordEntry).Data, _mergeColumnName);
                if (previousId == null || !previousId.Equals(currentId))
                    break;

                rowIndex = i;
            }

            return rowIndex;
        }

        private int FindEndRow(int rowIndex, int recordsCount, object currentId)
        {
            for (int i = rowIndex + 1; i < recordsCount + 1; i++)
            {
                var nextData = _dataGrid.GetRecordEntryAtRowIndex(i);
                if (nextData == null || !nextData.IsRecords)
                    break;

                var nextId = _propertyAccessor.GetFormattedValue((nextData as RecordEntry).Data, _mergeColumnName);
                if (nextId == null || !nextId.Equals(currentId))
                    break;

                rowIndex = i;
            }

            return rowIndex;
        }

        private bool IsIgnoredColumn(GridColumn column)
        {
            foreach (var name in _ignoredColumns)
            {
                if (column.MappingName == name)
                    return true;
            }
            return false;
        }
    }
}
