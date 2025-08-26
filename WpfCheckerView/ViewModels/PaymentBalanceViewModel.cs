using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfCheckerView.Models;

namespace WpfCheckerView.ViewModels
{
    public partial class PaymentBalanceViewModel : ObservableObject
    {

        public PaymentBalanceViewModel()
        {
            TransContra.PropertyChanged += TransContra_PropertyChanged;
        }

        //[ObservableProperty]
        //private decimal totalAmount;

        [ObservableProperty]
        private decimal totalAdj;

        [ObservableProperty]
        private Trn_ContraViewModel transContra = new();

        public decimal RemainingAmount => TotalAdj - TransContra.TotalSum();

        [RelayCommand]
        private void Process()
        {
            OnPropertyChanged(nameof(RemainingAmount));
        }



        partial void OnTransContraChanging(Trn_Contra value)
        {
            if (value != null)
            {
                value.PropertyChanged -= TransContra_PropertyChanged;
            }
        }

        partial void OnTransContraChanged(Trn_Contra value)
        {
            if (value != null)
            {
                value.PropertyChanged += TransContra_PropertyChanged;
            }
        }

        private void TransContra_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Trn_ContraViewModel.SuspenseAmt) ||
                e.PropertyName == nameof(Trn_ContraViewModel.ChequeAmt) ||
                e.PropertyName == nameof(Trn_ContraViewModel.TrAmount) ||
                e.PropertyName == nameof(Trn_ContraViewModel.SdAmount) ||
                e.PropertyName == nameof(Trn_ContraViewModel.OtherHeadsAmount))
            {
                OnPropertyChanged(nameof(RemainingAmount));
            }
        }

        partial void OnTotalAdjChanged(decimal value)
        {
            OnPropertyChanged(nameof(RemainingAmount));
        }
    }
}
