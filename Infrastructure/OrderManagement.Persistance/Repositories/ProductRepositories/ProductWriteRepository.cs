using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.Repositories.ProductRepositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Persistance.Contexts;

namespace OrderManagement.Persistance.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(OrderManagementDbContext context) : base(context)
        {
        }
    }
}
