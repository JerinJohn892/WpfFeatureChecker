using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfCheckerView.Models;
public partial class Trn_ContraViewModel : ObservableValidator
{
    public Trn_ContraViewModel() : base()
    {
        OtherTranDetails.CollectionChanged += OtherTranDetails_CollectionChanged;
    }

    [ObservableProperty]
    public long? acCode;
    [ObservableProperty]
    public string memberId;
    [ObservableProperty]
    public double? suspenseAmt;
    [ObservableProperty]
    public long? bankFasCode;
    [ObservableProperty]
    public string? chequeNo;
    [ObservableProperty]
    public double? chequeAmt;
    [ObservableProperty]
    public string? transferBy;
    [ObservableProperty]
    public int? trBankCode;
    [ObservableProperty]
    public double? trAmount;
    [ObservableProperty]
    public string? trRemarks;
    [ObservableProperty]
    public string? sdAccountId;
    [ObservableProperty]
    public double? sdAmount;
    [ObservableProperty]
    public string? remarks;

    public ObservableCollection<TranDetailViewModel> OtherTranDetails { get; } = new();
    private void OtherTranDetails_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (TranDetailViewModel item in e.NewItems)
            {
                item.PropertyChanged += Detail_PropertyChanged;
            }
        }
        if (e.OldItems != null)
        {
            foreach (TranDetailViewModel item in e.OldItems)
            {
                item.PropertyChanged -= Detail_PropertyChanged;
            }
        }
        OnPropertyChanged(nameof(OtherHeadsAmount));
    }

    private void Detail_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TranDetailViewModel.EffectiveAdjAmount))
        {
            OnPropertyChanged(nameof(OtherHeadsAmount));
        }
    }

    public decimal OtherHeadsAmount => OtherTranDetails.Sum(d => (decimal)d.EffectiveAdjAmount);

    public int AdjAmount { get; set; }

    public decimal TotalSum()
    {
        return (decimal)((SuspenseAmt ?? 0) +
                         (ChequeAmt ?? 0) +
                         (TrAmount ?? 0) +
                         (SdAmount ?? 0)) + OtherHeadsAmount;
    }
}

