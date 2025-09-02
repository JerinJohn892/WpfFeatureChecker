namespace WpfCheckerView.Models;

public class FasHead
{
    public long FasCode { get; set; }
    public string FasName { get; set; } = string.Empty;
    public int CategoryCode { get; set; }
    public string CategoryHead { get; set; } = string.Empty;
}

public class FasHeadSubCategories
{
    public long SubCode { get; set; }
    public string SubName { get; set; } = string.Empty;
    public string SelectedBranch { get; set; } = string.Empty;
    public int CategoryCode { get; set; }
    public string CategoryHead { get; set; } = string.Empty;
}
