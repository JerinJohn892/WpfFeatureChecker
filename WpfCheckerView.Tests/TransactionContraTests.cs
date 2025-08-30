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
            var contra = new Trn_ContraViewModel();
            Assert.Equal(0m, contra.TotalSum());
        }

        [Fact]
        public void TotalSum_SumsProvidedValues()
        {
            var contra = new Trn_ContraViewModel
            {
                SuspenseAmt = 10,
                ChequeAmt = 5,
                TrAmount = 15,
                SdAmount = 20
            };

            Assert.Equal(50m, contra.TotalSum());
        }

        [Fact]
        public void TotalSum_IncludesOtherTransactionDetails()
        {
            var contra = new Trn_ContraViewModel
            {
                ChequeAmt = 10
            };
            contra.OtherTranDetails.Add(new TranDetailViewModel { AdjAmount = 5 });
            contra.OtherTranDetails.Add(new TranDetailViewModel { AdjAmount = 15 });

            Assert.Equal(30m, contra.TotalSum());
        }

        [Fact]
        public void OtherHeadsAmount_SumsDetails()
        {
            var contra = new Trn_ContraViewModel();
            contra.OtherTranDetails.Add(new TranDetailViewModel { AdjAmount = 2 });
            contra.OtherTranDetails.Add(new TranDetailViewModel { AdjAmount = 3 });

            Assert.Equal(5m, contra.OtherHeadsAmount);
        }

        [Fact]
        public void OtherHeadsAmount_UsesSubDetailAmounts()
        {
            var contra = new Trn_ContraViewModel();
            var detail = new TranDetailViewModel();
            detail.TranSubDetails.Add(new TranSubDetailViewModel { Amount = 2 });
            detail.TranSubDetails.Add(new TranSubDetailViewModel { Amount = 3 });
            contra.OtherTranDetails.Add(detail);

            Assert.Equal(5m, contra.OtherHeadsAmount);
        }

        [Fact]
        public void TotalSum_IncludesSubDetailAmounts()
        {
            var contra = new Trn_ContraViewModel
            {
                ChequeAmt = 10
            };
            var detail = new TranDetailViewModel();
            detail.TranSubDetails.Add(new TranSubDetailViewModel { Amount = 5 });
            contra.OtherTranDetails.Add(detail);

            Assert.Equal(15m, contra.TotalSum());
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
