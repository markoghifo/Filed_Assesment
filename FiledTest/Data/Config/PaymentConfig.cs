using FiledTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Data.Config
{

    public class PaymentConfig : IEntityTypeConfiguration<PaymentModel>
    {
        public void Configure(EntityTypeBuilder<PaymentModel> builder)
        {
            builder.Property(e => e.ID)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreditCardNumber)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.CardHolder)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.ExpirationDate)
                .IsRequired();

            builder.Property(e => e.SecurityCode)
                .HasMaxLength(3);

            builder.Property(e => e.Amount)
                .IsRequired();            
        }
    }
}
