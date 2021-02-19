using FiledTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.PaymentGateways
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public PaymentState ProcessPayment(PaymentPostModel data)
        {
            throw new NotImplementedException();
        }
    }
}
