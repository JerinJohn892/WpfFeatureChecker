using Syncfusion.Data;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.Utility;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataRow = Syncfusion.UI.Xaml.Grid.DataRow;

namespace Nice
{
    public class CustomGridCellTemplateRenderer : GridCellTemplateRenderer
    {
        protected override void SetFocus(FrameworkElement uiElement, bool needToFocus)
        {
            base.SetFocus(uiElement, needToFocus);
            var focusedElement = FocusManagerHelper.GetFocusedUIElement(CurrentCellRendererElement);
            TextBox textBox = focusedElement as TextBox;
            if (textBox == null)
            {
                var comboBox = focusedElement as ComboBox;
                if (comboBox != null && comboBox.IsEditable)
                {
                    textBox = (TextBox)GridUtil.FindDescendantChildByType(comboBox, typeof(TextBox));
                }
            }
            if (textBox != null)
            {
                if (PreviewInputText == null)
                {
                    var index = textBox.Text.Length;
                    textBox.Select(index + 1, 0);
                    return;
                }
                textBox.Text = PreviewInputText;
                var caretIndex = (textBox.Text).IndexOf(PreviewInputText.ToString());
                textBox.Select(caretIndex + 1, 0);
                PreviewInputText = null;
            }
        }
    }
    public class SfDataGridExt : SfDataGrid
    {
        public SfDataGridExt()
        : base()
        {
            this.CellRenderers.Remove("Template");
            this.CellRenderers.Add("Template", new CustomGridCellTemplateRenderer());
            this.ExternalExceptionThrown += (sender, externalExceptionThrownEventArgs) =>
            {
                throw externalExceptionThrownEventArgs.Exception;
            };
            MergeIgnoredColumns = new List<string>();
        }

        #region Row Merging Properties

        public bool AllowRowMerging
        {
            get => (bool)GetValue(AllowRowMergingProperty);
            set => SetValue(AllowRowMergingProperty, value);
        }

        public static readonly DependencyProperty AllowRowMergingProperty =
            DependencyProperty.Register(nameof(AllowRowMerging), typeof(bool), typeof(SfDataGridExt),
                new PropertyMetadata(false, OnAllowRowMergingChanged));

        public string? MergeColumnName
        {
            get => (string?)GetValue(MergeColumnNameProperty);
            set => SetValue(MergeColumnNameProperty, value);
        }

        public static readonly DependencyProperty MergeColumnNameProperty =
            DependencyProperty.Register(nameof(MergeColumnName), typeof(string), typeof(SfDataGridExt));

        public IList<string> MergeIgnoredColumns
        {
            get => (IList<string>)GetValue(MergeIgnoredColumnsProperty);
            set => SetValue(MergeIgnoredColumnsProperty, value);
        }

        public static readonly DependencyProperty MergeIgnoredColumnsProperty =
            DependencyProperty.Register(nameof(MergeIgnoredColumns), typeof(IList<string>), typeof(SfDataGridExt));

        public static bool GetMergeColumn(DependencyObject obj) => (bool)obj.GetValue(MergeColumnProperty);
        public static void SetMergeColumn(DependencyObject obj, bool value) => obj.SetValue(MergeColumnProperty, value);

        public static readonly DependencyProperty MergeColumnProperty =
            DependencyProperty.RegisterAttached("MergeColumn", typeof(bool), typeof(SfDataGridExt),
                new PropertyMetadata(false, OnMergeColumnChanged));

        private static void OnMergeColumnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GridColumn column && column.DataGrid is SfDataGridExt grid)
            {
                if ((bool)e.NewValue)
                {
                    grid.MergeColumnName = column.MappingName;
                }
                else if (grid.MergeColumnName == column.MappingName)
                {
                    grid.MergeColumnName = null;
                }
            }
        }

        public static bool GetMergeIgnored(DependencyObject obj) => (bool)obj.GetValue(MergeIgnoredProperty);
        public static void SetMergeIgnored(DependencyObject obj, bool value) => obj.SetValue(MergeIgnoredProperty, value);

        public static readonly DependencyProperty MergeIgnoredProperty =
            DependencyProperty.RegisterAttached("MergeIgnored", typeof(bool), typeof(SfDataGridExt),
                new PropertyMetadata(false, OnMergeIgnoredChanged));

        private static void OnMergeIgnoredChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GridColumn column && column.DataGrid is SfDataGridExt grid)
            {
                if ((bool)e.NewValue)
                {
                    if (!grid.MergeIgnoredColumns.Contains(column.MappingName))
                        grid.MergeIgnoredColumns.Add(column.MappingName);
                }
                else
                {
                    if (grid.MergeIgnoredColumns.Contains(column.MappingName))
                        grid.MergeIgnoredColumns.Remove(column.MappingName);
                }
            }
        }

        private IPropertyAccessProvider? _propertyAccessor;

        private static void OnAllowRowMergingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (SfDataGridExt)d;
            bool enabled = (bool)e.NewValue;
            if (enabled)
            {
                grid.ItemsSourceChanged += grid.OnItemsSourceChanged;
                grid.QueryCoveredRange += grid.OnQueryCoveredRange;
            }
            else
            {
                grid.ItemsSourceChanged -= grid.OnItemsSourceChanged;
                grid.QueryCoveredRange -= grid.OnQueryCoveredRange;
            }
        }

        private void OnItemsSourceChanged(object? sender, GridItemsSourceChangedEventArgs e)
        {
            _propertyAccessor = View != null ? View.GetPropertyAccessProvider() : null;
        }

        private void OnQueryCoveredRange(object? sender, GridQueryCoveredRangeEventArgs e)
        {
            if (!AllowRowMerging || string.IsNullOrEmpty(MergeColumnName))
                return;

            var range = GetMergeRange(e.GridColumn, e.RowColumnIndex.RowIndex, e.RowColumnIndex.ColumnIndex, e.Record);
            if (range == null)
                return;

            if (!CoveredCells.IsInRange(range))
            {
                e.Range = range;
                e.Handled = true;
            }
        }

        private CoveredCellInfo? GetMergeRange(GridColumn column, int rowIndex, int columnIndex, object rowData)
        {
            if (IsIgnoredColumn(column))
                return null;

            int recordsCount = GroupColumnDescriptions.Count != 0
                ? View.TopLevelGroup.DisplayElements.Count + TableSummaryRows.Count + UnBoundRows.Count + (AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0)
                : View.Records.Count + TableSummaryRows.Count + UnBoundRows.Count + (AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0);

            var currentId = _propertyAccessor?.GetFormattedValue(rowData, MergeColumnName);
            var startIndex = ResolveStartIndexBasedOnPosition();

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
                var previousData = GetRecordEntryAtRowIndex(i);
                if (previousData == null || !previousData.IsRecords)
                    break;

                var previousId = _propertyAccessor?.GetFormattedValue((previousData as RecordEntry).Data, MergeColumnName);
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
                var nextData = GetRecordEntryAtRowIndex(i);
                if (nextData == null || !nextData.IsRecords)
                    break;

                var nextId = _propertyAccessor?.GetFormattedValue((nextData as RecordEntry).Data, MergeColumnName);
                if (nextId == null || !nextId.Equals(currentId))
                    break;

                rowIndex = i;
            }

            return rowIndex;
        }

        private bool IsIgnoredColumn(GridColumn column)
        {
            if (MergeIgnoredColumns == null)
                return false;
            foreach (var name in MergeIgnoredColumns)
            {
                if (column.MappingName == name)
                    return true;
            }
            return false;
        }

        #endregion

        protected override void OnTextInput(TextCompositionEventArgs e)
        {

            if (!SelectionController.CurrentCellManager.HasCurrentCell)
            {
                base.OnTextInput(e);
                return;
            }

            //Get the Current Row and Column index from the CurrentCellManager
            var rowColumnIndex = SelectionController.CurrentCellManager.CurrentRowColumnIndex;
            RowGenerator rowGenerator = this.RowGenerator;

            //Get the row from the Row index
            var dataRow = rowGenerator.Items.FirstOrDefault(item => item.RowIndex == rowColumnIndex.RowIndex);

            //Check whether the dataRow is null or not and the type as DataRow

            if (dataRow != null && dataRow is DataRow)
            {

                //Get the column from the VisibleColumn collection based on the column index
                var dataColumn = dataRow.VisibleColumns.FirstOrDefault(column => column.ColumnIndex == rowColumnIndex.ColumnIndex);

                //Convert the input text to char type 
                char text;
                char.TryParse(e.Text, out text);

                //Skip if the column is GridTemplateColumn and the column is not already in editing 

                //Allow Editing only pressed letters digits and Minus sign key 

                if (dataColumn != null && !dataColumn.IsEditing && SelectionController.CurrentCellManager.BeginEdit()) // && (e.Text.Equals("-") || char.IsLetterOrDigit(text)))
                {
                    dataColumn.Renderer.PreviewTextInput(e);
                }
            }
            base.OnTextInput(e);
        }
    }
}