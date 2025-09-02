using System.Collections.ObjectModel;
using System.Linq;

namespace WpfCheckerView.Models;

public class FasHead
{
    public long FasCode { get; set; }
    public string FasName { get; set; } = string.Empty;
    public int CategoryCode { get; set; }
    public string CategoryHead { get; set; } = string.Empty;
    public double AdjAmount { get; set; }
    public ObservableCollection<FasHeadSubCategory> SubHeads { get; } = new();
    public bool HasSubHeads => SubHeads.Any();
}

public class FasHeadSubCategory
{
    public long SubCode { get; set; }
    public string SubName { get; set; } = string.Empty;
    public double Amount { get; set; }
}

