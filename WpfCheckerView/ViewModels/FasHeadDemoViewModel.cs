using System.Collections.ObjectModel;
using WpfCheckerView.Models;

namespace WpfCheckerView.ViewModels;

public class FasHeadDemoViewModel
{
    public ObservableCollection<FasHead> FasHeads { get; } = new();

    public FasHeadDemoViewModel()
    {
        FasHeads.Add(new FasHead
        {
            FasCode = 1,
            FasName = "Share Capital A Class",
            CategoryCode = 1,
            CategoryHead = "Agent Name",
            AdjAmount = 1000
        });

        var loanHead = new FasHead
        {
            FasCode = 2,
            FasName = "Loan to Members Ordinary",
            CategoryCode = 2,
            CategoryHead = "Agent Name"
        };
        loanHead.SubHeads.Add(new FasHeadSubCategory { SubCode = 201, SubName = "Member A", Amount = 300 });
        loanHead.SubHeads.Add(new FasHeadSubCategory { SubCode = 202, SubName = "Member B", Amount = 200 });
        FasHeads.Add(loanHead);

        FasHeads.Add(new FasHead
        {
            FasCode = 3,
            FasName = "Interest on Loans Ordinary",
            CategoryCode = 2,
            CategoryHead = "Due-by Head",
            AdjAmount = 150
        });
    }
}

