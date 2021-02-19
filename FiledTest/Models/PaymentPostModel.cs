using FiledTest.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Models
{
    public class PaymentPostModel
    {
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("\\d{4}-?\\d{4}-?\\d{4}-?\\d{4}", ErrorMessage = "Credit card number isn't valid")]
        public string CreditCardNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CardHolder { get; set; }
        [Required]
        [PaymentModelValidateExpirationDate]
        public DateTime ExpirationDate { get; set; }
        [StringLength(3, ErrorMessage = "Security code must be 3 characters")]
        public string SecurityCode { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
    }

    public enum PaymentState
    {
        pending, processed, failed
    }

    public class PaymentModel
    {
        public int ID { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public PaymentStateModel PaymentStatus { get; set; }
    }

    public class PaymentStateModel
    {
        public int ID { get; set; }
        public int PaymentID { get; set; }
        public PaymentModel PaymentModel { get; set; }
        public string Status { get; set; }
    }
}
