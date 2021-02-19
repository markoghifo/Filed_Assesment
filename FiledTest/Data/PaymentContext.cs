using FiledTest.Data.Config;
using FiledTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FiledTest.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<PaymentStateModel> PaymentState { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PaymentModel>(
                pm => pm.HasOne(s => s.PaymentStatus)
                                .WithOne(ps => ps.PaymentModel)
                                .HasForeignKey<PaymentStateModel>(ad => ad.PaymentID)
                );
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new PaymentStateConfig());
        }
    }
}
