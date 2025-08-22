using System.ComponentModel;
using WpfCheckerView.ViewModels;
using WpfCheckerView.Models;
using Xunit;

namespace WpfCheckerView.Tests
{
    public class PaymentBalanceViewModelTests
    {
        [Fact]
        public void ProcessCommand_NotifiesRemainingAmount()
        {
            var vm = new PaymentBalanceViewModel { TotalAmount = 100m };
            vm.TransContra.ChequeAmt = 40;
            bool raised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(PaymentBalanceViewModel.RemainingAmount))
                {
                    raised = true;
                }
            };

            vm.ProcessCommand.Execute(null);

            Assert.True(raised);
        }
        //[Fact]
        //public void RemainingAmountUpdatesWithPayments()
        //{
        //    var vm = new PaymentBalanceViewModel { TotalAmount = 100m };
        //    vm.PaymentMethods.Add(new PaymentMethodEntry { Method = "Cash", Amount = 40m });
        //    vm.PaymentMethods.Add(new PaymentMethodEntry { Method = "Card", Amount = 30m });

        //    Assert.Equal(30m, vm.RemainingAmount);

        //    vm.PaymentMethods[0].Amount = 50m;

        //    Assert.Equal(20m, vm.RemainingAmount);
        //}
    }
}
