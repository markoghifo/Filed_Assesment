using FiledTest.Data;
using FiledTest.Models;
using FiledTest.PaymentGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentService _premiumPaymentService;

        public PaymentRepository(PaymentContext context, ICheapPaymentGateway cheapPaymentGateway, 
            IExpensivePaymentGateway expensivePaymentGateway, IPremiumPaymentService premiumPaymentService)
        {
            _context = context;
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentService = premiumPaymentService;
        }

        public async Task<ProcessPaymentResp> ProcessPaymentAsync(PaymentPostModel data)
        {
            ProcessPaymentResp processedState = new ProcessPaymentResp { payment_state = PaymentState.pending };
            try
            {
                var createresp = await CreatePaymentDataAsync(data);
                if (createresp != null)
                {
                    if (data.Amount <= 20)
                    {
                        //use ICheapPaymentGateway
                        processedState.payment_channel = "cheap payment gateway";
                        processedState.payment_state = _cheapPaymentGateway.ProcessPayment(data);
                    }
                    else if (data.Amount > 20 && data.Amount <= 500)
                    {
                        //use IExpensivePaymentGateway if available
                        if(_expensivePaymentGateway != null)
                        {
                            processedState.payment_channel = "expensive payment gateway";
                            processedState.payment_state = _expensivePaymentGateway.ProcessPayment(data);
                        }
                        else
                        {
                            processedState.payment_channel = "cheap payment gateway";
                            processedState.payment_state = _cheapPaymentGateway.ProcessPayment(data);
                        }
                    }
                    else if (data.Amount > 500)
                    {
                        //use IPremiumPaymentService
                        processedState.payment_channel = "premium payment service";
                        processedState.payment_state = _premiumPaymentService.ProcessPayment(data);
                    }

                    //update payment status
                    await storePaymentStatusAsync(createresp, processedState.payment_state);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return processedState;
        }

        private async Task<PaymentModel> CreatePaymentDataAsync(PaymentPostModel data)
        {
            PaymentModel res;
            try
            {
                res = new PaymentModel
                {
                    Amount = data.Amount,
                    CardHolder = data.CardHolder,
                    CreditCardNumber = data.CreditCardNumber,
                    ExpirationDate = data.ExpirationDate,
                    SecurityCode = data.SecurityCode
                };
                await _context.Payments.AddAsync(res);
                await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> storePaymentStatusAsync(PaymentModel data, PaymentState status)
        {
            string processedStatus = string.Empty;
            try
            {
                
                switch (status)
                {
                    case PaymentState.pending:
                        processedStatus = "pending";
                        break;
                    case PaymentState.processed:
                        processedStatus = "processed";
                        break;
                    case PaymentState.failed:
                        processedStatus = "failed";
                        break;
                    default:
                        break;
                }
                data.PaymentStatus.Status = processedStatus;
                //update the process state
                await _context.PaymentState.AddAsync(data.PaymentStatus);
            }
            catch (Exception)
            {

                throw;
            }
            return processedStatus;
        }
    }
}
