using System.ComponentModel;

namespace WpfCheckerView.Models
{
    public class TransactionSubDetail : INotifyPropertyChanged
    {
        public string BranchCode { get; set; }
        public string MasterId { get; set; }
        public int? RowNo { get; set; }
        public int SubCategory { get; set; }
        public long AcCode { get; set; }
        public long SubCode { get; set; }

        private double? amount;
        public double? Amount
        {
            get => amount;
            set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
