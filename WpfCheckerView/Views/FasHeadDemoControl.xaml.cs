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
        FasGrid.DetailsViewManager.QueryDetailsViewExpanding += DetailsViewManager_QueryDetailsViewExpanding;
    }

    private void DetailsViewManager_QueryDetailsViewExpanding(object? sender, QueryDetailsViewExpandingEventArgs e)
    {
        if (e.Record is FasHead head && !head.HasSubHeads)
        {
            e.Cancel = true;
        }
    }
}

