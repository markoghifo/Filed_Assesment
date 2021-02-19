using FiledTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.CustomAttributes
{
    public class PaymentModelValidateExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var expirationDate = ((PaymentPostModel)value).ExpirationDate;
            var today = DateTime.Now;

            if (DateTime.Compare(expirationDate, today) < 0)
            {
                return new ValidationResult("Expiration date can not be in the past");
            }

            return ValidationResult.Success;
        }
    }
}
