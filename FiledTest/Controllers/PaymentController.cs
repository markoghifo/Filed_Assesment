using FiledTest.CustomAttributes;
using FiledTest.Models;
using FiledTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FiledTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepo;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepo = paymentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPaymentAsync([FromBody]PaymentPostModel data)
        {
            try
            {
                //if Bad request
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }

                //process payment
                var paymentState = await _paymentRepo.ProcessPaymentAsync(data);
                return Ok(paymentState);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured");
            }            
        }
    }
}
