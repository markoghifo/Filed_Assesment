using FiledTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PaymentContext context)
        {
            context.Database.EnsureCreated();

            // Look for any payments.
            if (context.Payments.Any())
            {
                return;   // DB has been seeded
            }

            var payments = new PaymentModel[]
            {
            new PaymentModel{CardHolder="Carson Alexander", ExpirationDate=DateTime.Parse("2005-09-01"), CreditCardNumber = "", Amount = 500, SecurityCode = "123"},
            new PaymentModel{CardHolder="Meredith Alonso",ExpirationDate=DateTime.Parse("2002-09-01"), CreditCardNumber = "", Amount = 200, SecurityCode = "123"},
            new PaymentModel{CardHolder="Arturo Anand",ExpirationDate=DateTime.Parse("2003-09-01"), CreditCardNumber = "", Amount = 100, SecurityCode = "123"},
            new PaymentModel{CardHolder="Gytis Barzdukas",ExpirationDate=DateTime.Parse("2002-09-01"), CreditCardNumber = "", Amount = 50},
            new PaymentModel{CardHolder="Yan Li",ExpirationDate=DateTime.Parse("2002-09-01"), CreditCardNumber = "", Amount = 1000, SecurityCode = "123"},
            new PaymentModel{CardHolder="Peggy Justice",ExpirationDate=DateTime.Parse("2001-09-01"), CreditCardNumber = "", Amount = 500, SecurityCode = "123"},
            new PaymentModel{CardHolder="Laura Norman",ExpirationDate=DateTime.Parse("2003-09-01"), CreditCardNumber = "", Amount = 200 },
            new PaymentModel{CardHolder="Nino Olivetto",ExpirationDate=DateTime.Parse("2005-09-01"), CreditCardNumber = "", Amount = 300, SecurityCode = "123"}
            };
            foreach (PaymentModel s in payments)
            {
                context.Payments.Add(s);
            }
            context.SaveChanges();
        }
    }
}
