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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(i => i.Orders)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne(i => i.Company)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.CompanyId);

            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.ProductName).HasMaxLength(25);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GetDate()");
        }
    }
}
