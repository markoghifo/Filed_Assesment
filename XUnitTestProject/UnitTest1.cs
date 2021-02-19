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

    }
}
