using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace WpfCheckerView.Models
{
    public partial class TransactionDetail : INotifyPropertyChanged
    {
        public string BranchCode { get; set; }
        public string EntryFrom { get; set; }
        public int TranType { get; set; }
        public string MasterId { get; set; }
        public int RowNo { get; set; }
        private string? accountType;
        public string? AccountType
        {
            get => accountType;
            set
            {
                if (accountType != value)
                {
                    accountType = value;
                    OnPropertyChanged(nameof(AccountType));
                }
            }
        }
        public string? AccountId { get; set; }
        public string? MemberId { get; set; }
        public DateTime TranDate { get; set; }
        public int AcCode { get; set; }
        public double? CashAmount { get; set; }

        private double? adjAmount;
        public double? AdjAmount
        {
            get => adjAmount;
            set
            {
                if (adjAmount != value)
                {
                    adjAmount = value;
                    OnPropertyChanged(nameof(AdjAmount));
                    OnPropertyChanged(nameof(EffectiveAdjAmount));
                }
            }
        }

        public ObservableCollection<TransactionSubDetail> MiscTranSubDetails { get; set; } = new();

        public TransactionDetail()
        {
            MiscTranSubDetails.CollectionChanged += MiscTranSubDetails_CollectionChanged;
        }

        private void MiscTranSubDetails_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TransactionSubDetail item in e.NewItems)
                {
                    item.PropertyChanged += SubDetail_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (TransactionSubDetail item in e.OldItems)
                {
                    item.PropertyChanged -= SubDetail_PropertyChanged;
                }
            }
            OnPropertyChanged(nameof(EffectiveAdjAmount));
            OnPropertyChanged(nameof(SubDetailsTotal));
        }

        private void SubDetail_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TransactionSubDetail.Amount))
            {
                OnPropertyChanged(nameof(EffectiveAdjAmount));
                OnPropertyChanged(nameof(SubDetailsTotal));
            }
        }

        public double EffectiveAdjAmount => MiscTranSubDetails.Any()
            ? MiscTranSubDetails.Sum(d => d.Amount ?? 0)
            : (AdjAmount ?? 0);

        public double SubDetailsTotal => MiscTranSubDetails.Sum(d => d.Amount ?? 0);

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
