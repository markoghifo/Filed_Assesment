using FiledTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.PaymentGateways
{
    public class PremiumPaymentService : IPremiumPaymentService
    {        
        public PaymentState ProcessPayment(PaymentPostModel data)
        {
            PaymentState processedState;
            try
            {
                processedState = processPayment(data);
                if (processedState != PaymentState.processed)
                {
                    for(int i = 0; i < 3; i++)
                    {
                        processedState = processPayment(data);
                        if (processedState == PaymentState.processed)
                        {
                            return processedState;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return processedState;
        }

        protected PaymentState processPayment(PaymentPostModel data)
        {
            var res = PaymentState.failed;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }
    }
}
