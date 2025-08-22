using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCheckerView.Models
{
    public class TransactionContra
    {
        public double? TotalAdjustment { get; set; }
        public long? AcCode { get; set; }
        public string EmployeeId { get; set; }
        public double? SuspenseAmt { get; set; }
        public long? BankFasCode { get; set; }
        public string? ChequeNo { get; set; }
        public double? ChequeAmt { get; set; }
        public string? TransferBy { get; set; }
        public int? TrBankCode { get; set; }
        public double? TrAmount { get; set; }
        public string? TrRemarks { get; set; }
        public string? SdAccountId { get; set; }
        public double? SdAmount { get; set; }
        public string? Remarks { get; set; }
        public ObservableCollection<TransactionDetail> OtherTranDetails { get; set; } = new();

        public decimal OtherHeadsAmount => OtherTranDetails.Sum(d => (decimal)(d.AdjAmount ?? 0));


        public decimal TotalSum()
        {
            var otherTotal = OtherTranDetails.Sum(d => (decimal)(d.AdjAmount ?? 0));
            return (decimal)((SuspenseAmt ?? 0) +
                             (ChequeAmt ?? 0) +
                             (TrAmount ?? 0) +
                             (SdAmount ?? 0)) + OtherHeadsAmount;

        }
    }
}
