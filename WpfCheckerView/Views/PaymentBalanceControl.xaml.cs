using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        private void SubHeadButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var row = FindAncestor<DataGridRow>(button);
                if (row != null)
                {
                    row.IsSelected = true;
                    SubDetailsExpander.IsExpanded = !SubDetailsExpander.IsExpanded;
                }
            }
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
