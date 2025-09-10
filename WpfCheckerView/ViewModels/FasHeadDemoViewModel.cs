using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using WpfCheckerView.Models;

namespace WpfCheckerView.ViewModels;

public partial class FasHeadDemoViewModel : ObservableValidator
{
    [ObservableProperty]
    public ObservableCollection<TranDetailViewModel> tranDetails  = new();

    [ObservableProperty]
    public ObservableCollection<FasHead> fasHeads  = new();

    [ObservableProperty]
    public ObservableCollection<FasHeadSubCategories> fullFasHeadSubCategories  = new();

    private Dictionary<int, IList<FasHeadSubCategories>> groupFasHeadSubCategories;
    public FasHeadDemoViewModel()
    {
        FasHeads.Add(new FasHead { FasCode = 1, FasName = "Share Capital A Class", CategoryCode = 1, CategoryHead = "Agent Name" });
        FasHeads.Add(new FasHead { FasCode = 2, FasName = "Loan to Members Ordinary", CategoryCode = 2, CategoryHead = "Agent Name" });
        FasHeads.Add(new FasHead { FasCode = 3, FasName = "Interest on Loans Ordinary", CategoryCode = 3, CategoryHead = "Due-by Head" });
        FasHeads.Add(new FasHead { FasCode = 3, FasName = "Interest on Loans Ordinary", CategoryCode = 4, CategoryHead = "Due-to Head" });
        FasHeads.Add(new FasHead { FasCode = 3, FasName = "Interest on Loans Ordinary", CategoryCode = 5, CategoryHead = "Staff" });
        FasHeads.Add(new FasHead { FasCode = 3, FasName = "Interest on Loans Ordinary", CategoryCode = 0, CategoryHead = "Misslaneass" });

        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 201, SubName = "Member A", CategoryCode = 2, CategoryHead = "Agent Name", SelectedBranch = "Main" });
        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 202, SubName = "Member B", CategoryCode = 2, CategoryHead = "Agent Name", SelectedBranch = "Main" });
        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 203, SubName = "Jose", CategoryCode = 5, CategoryHead = "Staff", SelectedBranch = "Main" });
        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 204, SubName = "Joko B", CategoryCode = 5, CategoryHead = "Staff", SelectedBranch = "Main" });
        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 205, SubName = "Jiby", CategoryCode = 5, CategoryHead = "Staff", SelectedBranch = "Main" });
        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 206, SubName = "Loan", CategoryCode = 3, CategoryHead = "Due-by Head", SelectedBranch = "Main" });
        FullFasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 207, SubName = "GoldLoan", CategoryCode = 3, CategoryHead = "Due-by Head", SelectedBranch = "Main" });

        groupFasHeadSubCategories = GetSortedSubFasHeads(FullFasHeadSubCategories);
    }

    private Dictionary<int, IList<FasHeadSubCategories>> GetSortedSubFasHeads(IList<FasHeadSubCategories> fullSubFasHeads)
    {
        return fullSubFasHeads
            .GroupBy(x => x.CategoryCode)
            .ToDictionary(g => g.Key, g => (IList<FasHeadSubCategories>)g.ToList());
    }

    private void UpdateTranDetail(TranDetailViewModel tranDetailViewModel,
        ObservableCollection<FasHead> fasHeads,
        Dictionary<int, IList<FasHeadSubCategories>> goupedsUBFasHeads)
    {
        tranDetailViewModel.FasHeads = fasHeads;
        tranDetailViewModel.GroupFasHeadSubCategories = goupedsUBFasHeads;
    }

    [RelayCommand]
    protected void AddNewRow(object e)
    {
        var eventDetails = e as AddNewRowInitiatingEventArgs;
        if (eventDetails?.NewObject == null)
            return;

        switch (eventDetails.NewObject)
        {
            case TranDetailViewModel tranDetailViewModel:
                UpdateTranDetail(tranDetailViewModel, FasHeads, groupFasHeadSubCategories);
                //SetFormDetailsTochildViewModel(lADetail);
                break;

            case TranSubDetailViewModel tranSubDetailViewModel:
                if (eventDetails.OriginalSender is SfDataGrid grid && grid.DataContext is TranDetailViewModel parent)
                {
                    tranSubDetailViewModel.FasHeadSubCategories = parent.SubFasHeads;
                }
                break;

            default:
                // Handle unknown types or log as needed
                break;
        }
    }
}
