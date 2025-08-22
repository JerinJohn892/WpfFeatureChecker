using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            if (sender is ToggleButton toggle && toggle.DataContext is TransactionDetail detail)
            {
                OtherHeadsDataGrid.SelectedItem = detail;
                SubDetailsExpander.IsExpanded = true;
            }
        }

        private void SubHeadToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggle && toggle.DataContext is TransactionDetail detail)
            {
                detail.MiscTranSubDetails.Clear();
            }
            SubDetailsExpander.IsExpanded = false;
        }
    }
}
