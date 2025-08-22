using System.Windows;
using System.Windows.Controls;

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
    }
}
