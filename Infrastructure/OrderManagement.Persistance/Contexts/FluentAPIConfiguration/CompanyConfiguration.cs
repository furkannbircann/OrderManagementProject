using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Persistance.Contexts.FluentAPIConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .HasMany(i => i.Orders)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId);

            builder
                .HasMany(i => i.Products)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId);

            builder.Property(x => x.CompanyName).HasMaxLength(25);
            builder.Property(x => x.IsApproved).HasDefaultValue(true);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GetUtcDate()");
        }
    }
}
