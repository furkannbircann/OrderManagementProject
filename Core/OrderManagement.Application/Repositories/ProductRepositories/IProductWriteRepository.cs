using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Repositories.ProductRepositories
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
