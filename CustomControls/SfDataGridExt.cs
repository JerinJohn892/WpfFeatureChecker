using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

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