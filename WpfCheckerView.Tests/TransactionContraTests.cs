using WpfCheckerView.Models;
using WpfCheckerView.ViewModels;
using Xunit;

namespace WpfCheckerView.Tests
{
    public class TransactionContraTests
    {
        [Fact]
        public void TotalSum_HandlesNullValues()
        {
            var contra = new TransactionContra();
            Assert.Equal(0m, contra.TotalSum());
        }

        [Fact]
        public void TotalSum_SumsProvidedValues()
        {
            var contra = new TransactionContra
            {
                SuspenseAmt = 10,
                ChequeAmt = 5,
                TrAmount = 15,
                SdAmount = 20
            };

            Assert.Equal(50m, contra.TotalSum());
        }

        [Fact]
        public void RemainingAmount_UsesTransactionContraTotal()
        {
            var vm = new PaymentBalanceViewModel
            {
                TotalAmount = 100m
            };
            vm.TransContra.SuspenseAmt = 10;
            vm.TransContra.ChequeAmt = 5;

            Assert.Equal(85m, vm.RemainingAmount);
        }
    }
}
