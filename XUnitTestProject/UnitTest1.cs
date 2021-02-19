using FiledTest.Controllers;
using FiledTest.CustomAttributes;
using FiledTest.Models;
using FiledTest.PaymentGateways;
using FiledTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestExpirationDate_InThePast_Fails()
        {
            var validationresult = new PaymentModelValidateExpirationDateAttribute().IsValid(new PaymentPostModel());
            Assert.False(validationresult);
        }

        [Fact]
        public void TestExpirationDate_Current_Fails()
        {
            var validationresult = new PaymentModelValidateExpirationDateAttribute()
                                        .IsValid(new PaymentPostModel() { ExpirationDate = DateTime.Now });
            Assert.False(validationresult);
        }

        [Fact]
        public void TestExpirationDate_Future_Passes()
        {
            var validationresult = new PaymentModelValidateExpirationDateAttribute()
                                        .IsValid(new PaymentPostModel() { ExpirationDate = DateTime.Now.AddDays(1)});
            Assert.True(validationresult);
        }

        //[Fact]
        //public async Task TestPaymentChannel_Cheap_FailAsync()
        //{
        //    var data = new PaymentPostModel() { Amount = 500 };
        //    var mockCheapRepo = new Mock<ICheapPaymentGateway>();
        //    mockCheapRepo.Setup(repo => repo.ProcessPayment(data))
        //        .Returns(PaymentState.failed);
        //    var mockExpensiveRepo = new Mock<IExpensivePaymentGateway>();
        //    mockExpensiveRepo.Setup(repo => repo.ProcessPayment(data))
        //        .Returns(PaymentState.failed);
        //    var mockPremRepo = new Mock<IPremiumPaymentService>();
        //    mockPremRepo.Setup(repo => repo.ProcessPayment(data))
        //        .Returns(PaymentState.failed);
        //    var mockDbContext = new Mock<IPremiumPaymentService>();
        //    mockPremRepo.Setup(repo => repo.ProcessPayment(data))
        //        .Returns(PaymentState.failed);
        //    var validationresult = await new PaymentRepository()
        //                                .ProcessPaymentAsync(data);
        //    Assert.True(validationresult);
        //}
    }
}
