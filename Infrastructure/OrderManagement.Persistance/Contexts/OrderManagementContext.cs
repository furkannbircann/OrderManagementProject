using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Persistance.Contexts
{
    public class OrderManagementContext : DbContext
    {
        public OrderManagementContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //Order & Company
            modelBuilder.Entity<Order>()
                .HasOne(i => i.Company)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.CompanyId);
            modelBuilder.Entity<Company>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId);

            //Order & Product
            modelBuilder.Entity<Order>()
                .HasOne(i => i.Product)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<Product>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.ClientNoAction);

            //Company & Product
            modelBuilder.Entity<Product>()
                .HasOne(i => i.Company)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.CompanyId);
            modelBuilder.Entity<Company>()
                .HasMany(i => i.Products)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId);

            //Product
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("money");
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasMaxLength(25);
            modelBuilder.Entity<Product>().Property(x => x.CreatedDate).HasDefaultValueSql("GetUtcDate()");
            //Order
            modelBuilder.Entity<Order>().Property(x => x.OrdererName).HasMaxLength(25);
            modelBuilder.Entity<Order>().Property(x => x.CreatedDate).HasDefaultValueSql("GetUtcDate()");
            //Company
            modelBuilder.Entity<Company>().Property(x => x.CompanyName).HasMaxLength(25);
            modelBuilder.Entity<Company>().Property(x => x.IsApproved).HasDefaultValue(true);
            modelBuilder.Entity<Company>().Property(x => x.CreatedDate).HasDefaultValueSql("GetUtcDate()");

        }
    }
}
