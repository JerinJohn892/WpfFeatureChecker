using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfCheckerView.Models;

namespace WpfCheckerView.ViewModels
{
    public partial class PaymentBalanceViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal totalAmount;

        public ObservableCollection<PaymentMethodEntry> PaymentMethods { get; } = new();

        public decimal RemainingAmount => TotalAmount - PaymentMethods.Sum(pm => pm.Amount);

        public PaymentBalanceViewModel()
        {
            PaymentMethods.CollectionChanged += PaymentMethods_CollectionChanged;
        }

        private void PaymentMethods_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PaymentMethodEntry item in e.NewItems)
                {
                    item.PropertyChanged += PaymentMethod_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (PaymentMethodEntry item in e.OldItems)
                {
                    item.PropertyChanged -= PaymentMethod_PropertyChanged;
                }
            }
            OnPropertyChanged(nameof(RemainingAmount));
        }

        private void PaymentMethod_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PaymentMethodEntry.Amount))
            {
                OnPropertyChanged(nameof(RemainingAmount));
            }
        }

        partial void OnTotalAmountChanged(decimal value)
        {
            OnPropertyChanged(nameof(RemainingAmount));
        }
    }
}
