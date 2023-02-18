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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(i => i.Company)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.CompanyId);

            builder
                 .HasOne(i => i.Product)
                 .WithMany(i => i.Orders)
                 .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Property(x => x.OrdererName).HasMaxLength(25);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GetUtcDate()");
        }
    }
}
