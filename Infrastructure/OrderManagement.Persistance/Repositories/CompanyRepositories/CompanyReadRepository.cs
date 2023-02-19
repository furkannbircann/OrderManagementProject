using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Application.Repositories.CompanyRepositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Persistance.Contexts;

namespace OrderManagement.Persistance.Repositories.CompanyRepositories
{
    public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(OrderManagementDbContext context) : base(context)
        {

        }
    }
}