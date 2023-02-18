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

    }
}
