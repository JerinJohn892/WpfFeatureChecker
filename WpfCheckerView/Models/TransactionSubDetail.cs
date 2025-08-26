using CommunityToolkit.Mvvm.ComponentModel;
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
}
