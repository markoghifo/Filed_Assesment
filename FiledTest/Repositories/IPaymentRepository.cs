using FiledTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Repositories
{
    public interface IPaymentRepository
    {
        Task<ProcessPaymentResp> ProcessPaymentAsync(PaymentPostModel data);
    }
}
