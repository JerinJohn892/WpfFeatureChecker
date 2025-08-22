using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using WpfCheckerView.Models;

namespace WpfCheckerView.Views
{
    public partial class PaymentBalanceControl : UserControl
    {
        public PaymentBalanceControl()
        {
            InitializeComponent();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            if (sender != ChequeExpander)
                ChequeExpander.IsExpanded = false;
            if (sender != TransferExpander)
                TransferExpander.IsExpanded = false;
            if (sender != SdExpander)
                SdExpander.IsExpanded = false;
            if (sender != OtherExpander)
                OtherExpander.IsExpanded = false;
        }

        private void SubHeadToggle_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggle)
            {
                var row = FindAncestor<DataGridRow>(toggle);
                if (row != null)
                {
                    row.IsSelected = true;
                    SubDetailsExpander.IsExpanded = true;
                }
            }
        }

        private void SubHeadToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggle)
            {
                var row = FindAncestor<DataGridRow>(toggle);
                if (row?.DataContext is TransactionDetail detail)
                {
                    detail.MiscTranSubDetails.Clear();
                }
            }
            SubDetailsExpander.IsExpanded = false;
        }

        private static T? FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T target)
                    return target;
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }
    }
}
