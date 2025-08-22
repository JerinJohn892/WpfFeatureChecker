using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfCheckerView.Models
{
    public partial class TransactionContra : ObservableObject
    {
        public double? TotalAdjustment { get; set; }
        public long? AcCode { get; set; }
        public string EmployeeId { get; set; }

        [ObservableProperty]
        private double? suspenseAmt;

        public long? BankFasCode { get; set; }
        public string? ChequeNo { get; set; }

        [ObservableProperty]
        private double? chequeAmt;

        public string? TransferBy { get; set; }
        public int? TrBankCode { get; set; }

        [ObservableProperty]
        private double? trAmount;

        public string? TrRemarks { get; set; }
        public string? SdAccountId { get; set; }

        [ObservableProperty]
        private double? sdAmount;

        public string? Remarks { get; set; }

        public ObservableCollection<TransactionDetail> OtherTranDetails { get; } = new();

        public TransactionContra()
        {
            OtherTranDetails.CollectionChanged += OtherTranDetails_CollectionChanged;
        }

        private void OtherTranDetails_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TransactionDetail item in e.NewItems)
                {
                    item.PropertyChanged += Detail_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (TransactionDetail item in e.OldItems)
                {
                    item.PropertyChanged -= Detail_PropertyChanged;
                }
            }
            OnPropertyChanged(nameof(OtherHeadsAmount));
        }

        private void Detail_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TransactionDetail.EffectiveAdjAmount))
            {
                OnPropertyChanged(nameof(OtherHeadsAmount));
            }
        }

        public decimal OtherHeadsAmount => OtherTranDetails.Sum(d => (decimal)d.EffectiveAdjAmount);

        public decimal TotalSum()
        {
            return (decimal)((SuspenseAmt ?? 0) +
                             (ChequeAmt ?? 0) +
                             (TrAmount ?? 0) +
                             (SdAmount ?? 0)) + OtherHeadsAmount;
        }
    }
}

