using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCheckerView.Models
{
    public class TransactionDetail
    {
        public string BranchCode { get; set; }
        public string EntryFrom { get; set; }
        public int TranType { get; set; }
        public string MasterId { get; set; }
        public int RowNo { get; set; }
        public string? AccountType { get; set; }
        public string? AccountId { get; set; }
        public string? MemberId { get; set; }
        public DateTime TranDate { get; set; }
        public int AcCode { get; set; }
        public double? CashAmount { get; set; }
        public double? AdjAmount { get; set; }
        public ObservableCollection<TransactionSubDetail> MiscTranSubDetails { get; set; }
    }

}
