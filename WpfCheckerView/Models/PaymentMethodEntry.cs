using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfCheckerView.Models
{
    public partial class PaymentMethodEntry : ObservableObject
    {
        [ObservableProperty]
        private string method = string.Empty;

        [ObservableProperty]
        private decimal amount;
    }
}
