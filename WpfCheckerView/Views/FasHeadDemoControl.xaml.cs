using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Grid;
using WpfCheckerView.Models;
using WpfCheckerView.ViewModels;

namespace WpfCheckerView.Views;

public partial class FasHeadDemoControl : UserControl
{
    public FasHeadDemoControl()
    {
        InitializeComponent();
        DataContextChanged += FasHeadDemoControl_DataContextChanged;
    }

    private void FasHeadDemoControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue is FasHeadDemoViewModel oldVm)
        {
            oldVm.TranDetails.CollectionChanged -= TranDetails_CollectionChanged;
            foreach (var item in oldVm.TranDetails)
            {
                item.PropertyChanged -= TranDetail_PropertyChanged;
            }
        }

        if (e.NewValue is FasHeadDemoViewModel newVm)
        {
            newVm.TranDetails.CollectionChanged += TranDetails_CollectionChanged;
            foreach (var item in newVm.TranDetails)
            {
                item.PropertyChanged += TranDetail_PropertyChanged;
            }
        }
    }

    private void TranDetails_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (TranDetailViewModel item in e.NewItems)
            {
                item.PropertyChanged += TranDetail_PropertyChanged;
            }
        }
        if (e.OldItems != null)
        {
            foreach (TranDetailViewModel item in e.OldItems)
            {
                item.PropertyChanged -= TranDetail_PropertyChanged;
            }
        }
    }

    private void TranDetail_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TranDetailViewModel.IsSubOptionsPresent))
        {
            FasGrid.View?.Refresh();
        }
    }

    private void FasGrid_DetailsViewExpanding(object sender, GridViewExpandingEventArgs e)
    {
        if (e.Record is TranDetailViewModel detail && !detail.IsSubOptionsPresent)
        {
            e.Cancel = true;
        }
    }

    private void FasGrid_QueryDetailsViewExpanderState(object sender, QueryDetailsViewExpanderStateEventArgs e)
    {
        if (e.Record is TranDetailViewModel detail)
        {
            e.ExpanderVisibility = detail.IsSubOptionsPresent;
        }
    }
}
