using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Mapping.Transactions
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions", "dbo");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.SatrtDate)
                .IsRequired();

            builder.Property(c => c.EndDate);

            builder.HasOne(c => c.User)
               .WithMany(c => c.Transactions)
               .HasForeignKey(c => c.UserId);
        }
    }
}
