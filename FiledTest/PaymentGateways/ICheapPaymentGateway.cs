using FiledTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.PaymentGateways
{
    public interface ICheapPaymentGateway
    {
        PaymentState ProcessPayment(PaymentPostModel data);
    }
}
