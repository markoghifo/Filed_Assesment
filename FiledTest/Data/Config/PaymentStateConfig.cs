using FiledTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Data.Config
{
    public class PaymentStateConfig : IEntityTypeConfiguration<PaymentStateModel>
    {
        public void Configure(EntityTypeBuilder<PaymentStateModel> builder)
        {
            builder.Property(e => e.ID)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PaymentID)
                        .IsRequired()
                        .IsUnicode(false);

            builder.Property(e => e.Status)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.PaymentID)
                .IsRequired();
        }
    }
}
