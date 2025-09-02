using System.Collections.ObjectModel;
using WpfCheckerView.Models;

namespace WpfCheckerView.ViewModels;

public class FasHeadDemoViewModel
{
    public ObservableCollection<TranDetailViewModel> TranDetails { get; } = new();
    public ObservableCollection<FasHead> FasHeads { get; } = new();
    public ObservableCollection<FasHeadSubCategories> FasHeadSubCategories { get; } = new();

    public FasHeadDemoViewModel()
    {
        FasHeads.Add(new FasHead { FasCode = 1, FasName = "Share Capital A Class", CategoryCode = 1, CategoryHead = "Agent Name" });
        FasHeads.Add(new FasHead { FasCode = 2, FasName = "Loan to Members Ordinary", CategoryCode = 2, CategoryHead = "Agent Name" });
        FasHeads.Add(new FasHead { FasCode = 3, FasName = "Interest on Loans Ordinary", CategoryCode = 3, CategoryHead = "Due-by Head" });

        FasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 201, SubName = "Member A", CategoryCode = 2, CategoryHead = "Agent Name", SelectedBranch = "Main" });
        FasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 202, SubName = "Member B", CategoryCode = 2, CategoryHead = "Agent Name", SelectedBranch = "Main" });

        var detail1 = new TranDetailViewModel { AcCode = 1, CategoryCode = 1, CategoryHead = "Agent Name", AdjAmount = 1000 };
        TranDetails.Add(detail1);

        var detail2 = new TranDetailViewModel { AcCode = 2, CategoryCode = 2, CategoryHead = "Agent Name" };
        detail2.TranSubDetails.Add(new TranSubDetailViewModel { SubCode = 201, Amount = 300 });
        detail2.TranSubDetails.Add(new TranSubDetailViewModel { SubCode = 202, Amount = 200 });
        TranDetails.Add(detail2);

        var detail3 = new TranDetailViewModel { AcCode = 3, CategoryCode = 3, CategoryHead = "Due-by Head", AdjAmount = 150 };
        TranDetails.Add(detail3);
    }
}
