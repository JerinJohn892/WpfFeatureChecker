using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace WpfCheckerView.Models;

public partial class TranDetailViewModel : ObservableValidator
{
    public TranDetailViewModel() : base()
    {
        TranSubDetails.CollectionChanged += TranSubDetails_CollectionChanged;
    }

    public string MasterId;
    [ObservableProperty]
    public string branchCode;
    [ObservableProperty]
    public string entryFrom;
    [ObservableProperty]
    public int tranType;
    [ObservableProperty]
    public int rowNo;
    [ObservableProperty]
    public string? accountType;
    [ObservableProperty]
    public string? accountId;
    [ObservableProperty]
    public string? memberId;
    [ObservableProperty]
    public DateTime tranDate;
    [ObservableProperty]
    public int acCode;
    [ObservableProperty]
    public int categoryCode;
    partial void OnCategoryCodeChanged(int oldValue, int newValue)
    {
        if (oldValue != newValue)
        {
            CategoryCodeChange(newValue);
        }
    }


    [ObservableProperty]
    public string? categoryHead;
    [ObservableProperty]
    public double? cashAmount;
    [ObservableProperty]
    public double? adjAmount;

    [ObservableProperty]
    public bool isSubOptionsPresent;

    [ObservableProperty]
    public ObservableCollection<FasHead> fasHeads;
    [ObservableProperty]
    public ObservableCollection<FasHeadSubCategories> subFasHeads;

    public Dictionary<int, IList<FasHeadSubCategories>> GroupFasHeadSubCategories { get; set; }


    partial void OnAdjAmountChanged(double? oldValue, double? newValue)
    {
        if (oldValue != newValue)
        {
            OnPropertyChanged(nameof(EffectiveAdjAmount));
        }
    }

    public ObservableCollection<TranSubDetailViewModel> TranSubDetails { get; set; } = new();

    private void TranSubDetails_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (TranSubDetailViewModel item in e.NewItems)
            {
                item.PropertyChanged += SubDetail_PropertyChanged;
            }
        }
        if (e.OldItems != null)
        {
            foreach (TranSubDetailViewModel item in e.OldItems)
            {
                item.PropertyChanged -= SubDetail_PropertyChanged;
            }
        }
        OnPropertyChanged(nameof(EffectiveAdjAmount));
        OnPropertyChanged(nameof(SubDetailsTotal));
    }

    private void SubDetail_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TranSubDetailViewModel.Amount))
        {
            OnPropertyChanged(nameof(EffectiveAdjAmount));
            OnPropertyChanged(nameof(SubDetailsTotal));
        }
    }

    public double EffectiveAdjAmount => TranSubDetails.Any()
        ? TranSubDetails.Sum(d => d.Amount ?? 0)
        : (AdjAmount ?? 0);

    public double SubDetailsTotal => TranSubDetails.Sum(d => d.Amount ?? 0);

    private void CategoryCodeChange(int newValue)
    {
        //ToDo: Implement the logic to handle category code change
        // CategoryCode has changed, So update the SubFasHeads accordingly from GroupFasHeadSubCategories 
    }

}