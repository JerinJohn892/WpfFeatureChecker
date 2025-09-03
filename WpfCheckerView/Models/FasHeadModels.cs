using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfCheckerView.Models;

public partial class FasHead : ObservableValidator
{
    [ObservableProperty]
    public long fasCode;

    [ObservableProperty]
    public string fasName  = string.Empty;

    [ObservableProperty]
    public int categoryCode;

    [ObservableProperty]
    public string categoryHead  = string.Empty;
}

public partial class FasHeadSubCategories : ObservableValidator
{
    [ObservableProperty]
    public long subCode;

    [ObservableProperty]
    public string subName = string.Empty;

    [ObservableProperty]
    public string selectedBranch  = string.Empty;

    [ObservableProperty]
    public int categoryCode;

    [ObservableProperty]
    public string categoryHead = string.Empty;
}
