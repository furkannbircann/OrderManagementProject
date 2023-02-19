using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.Repositories.OrderRepositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Persistance.Contexts;

namespace OrderManagement.Persistance.Repositories.OrderRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(OrderManagementDbContext context) : base(context)
        {
        }
    }
}
