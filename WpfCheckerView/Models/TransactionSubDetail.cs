using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfCheckerView.Models;

public partial class TranSubDetailViewModel : ObservableValidator
{
    public string MasterId;
    [ObservableProperty]
    public string branchCode;
    [ObservableProperty]
    public int? rowNo;
    [ObservableProperty]
    public int subCategory;
    [ObservableProperty]
    public long acCode;
    [ObservableProperty]
    public long subCode;
    [ObservableProperty]
    public double? amount;

    [ObservableProperty]
    public FasHeadSubCategories fasHeadSub;

    [ObservableProperty]
    public ObservableCollection<FasHeadSubCategories> fasHeadSubCategories;

    public TranSubDetailViewModel()
    {
        FasHeadSubCategories = new();
        //FasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 201, SubName = "Member C", CategoryCode = 2, CategoryHead = "Agent Name", SelectedBranch = "Main" });
        //FasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 202, SubName = "Member D", CategoryCode = 2, CategoryHead = "Agent Name", SelectedBranch = "Main" });
        //FasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 203, SubName = "Jose J", CategoryCode = 5, CategoryHead = "Staff", SelectedBranch = "Main" });
        //FasHeadSubCategories.Add(new FasHeadSubCategories { SubCode = 204, SubName = "Joko S", CategoryCode = 5, CategoryHead = "Staff", SelectedBranch = "Main" });
    }
}
