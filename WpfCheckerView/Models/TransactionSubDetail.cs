using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCheckerView.Models
{
    public class TransactionSubDetail
    {

        public string BranchCode { get; set; }
        public string MasterId { get; set; }
        public int? RowNo { get; set; }
        public int SubCategory { get; set; }
        public long AcCode { get; set; }
        public long SubCode { get; set; }
        public double? Amount { get; set; }
    }
}
