using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Models
{
    public class ProcessPaymentResp
    {
        public string payment_channel { get; set; }
        public PaymentState payment_state { get; set; }
    }
}
