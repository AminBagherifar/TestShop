using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Mapping.Users
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasKey(c => c.Id);
            builder.Ignore(p => p.FullName);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Family)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(80);
        }
    }
}
