using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfCheckerView.Models;

namespace WpfCheckerView.ViewModels
{
    public partial class PaymentBalanceViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal totalAmount;

        [ObservableProperty]
        private TransactionContra transContra  = new();

        public decimal RemainingAmount => TotalAmount - TransContra.TotalSum();

        [RelayCommand]
        private void Process()
        {
            OnPropertyChanged(nameof(RemainingAmount));
        }

        public PaymentBalanceViewModel()
        {
            TransContra.PropertyChanged += TransContra_PropertyChanged;
        }

        partial void OnTransContraChanging(TransactionContra value)
        {
            if (value != null)
            {
                value.PropertyChanged -= TransContra_PropertyChanged;
            }
        }

        partial void OnTransContraChanged(TransactionContra value)
        {
            if (value != null)
            {
                value.PropertyChanged += TransContra_PropertyChanged;
            }
        }

        private void TransContra_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TransactionContra.SuspenseAmt) ||
                e.PropertyName == nameof(TransactionContra.ChequeAmt) ||
                e.PropertyName == nameof(TransactionContra.TrAmount) ||
                e.PropertyName == nameof(TransactionContra.SdAmount) ||
                e.PropertyName == nameof(TransactionContra.OtherHeadsAmount))
            {
                OnPropertyChanged(nameof(RemainingAmount));
            }
        }

        //private void PaymentMethods_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.NewItems != null)
        //    {
        //        foreach (PaymentMethodEntry item in e.NewItems)
        //        {
        //            item.PropertyChanged += PaymentMethod_PropertyChanged;
        //        }
        //    }
        //    if (e.OldItems != null)
        //    {
        //        foreach (PaymentMethodEntry item in e.OldItems)
        //        {
        //            item.PropertyChanged -= PaymentMethod_PropertyChanged;
        //        }
        //    }
        //    OnPropertyChanged(nameof(RemainingAmount));
        //}

        //private void PaymentMethod_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == nameof(PaymentMethodEntry.Amount))
        //    {
        //        OnPropertyChanged(nameof(RemainingAmount));
        //    }
        //}

        partial void OnTotalAmountChanged(decimal value)
        {
            OnPropertyChanged(nameof(RemainingAmount));
        }
    }
}
