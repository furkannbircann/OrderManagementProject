using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Repositories.CompanyRepositories;
using OrderManagement.Application.Repositories.OrderRepositories;
using OrderManagement.Application.Repositories.ProductRepositories;
using OrderManagement.Persistance.Contexts;
using OrderManagement.Persistance.Repositories.CompanyRepositories;
using OrderManagement.Persistance.Repositories.OrderRepositories;
using OrderManagement.Persistance.Repositories.ProductRepositories;

namespace OrderManagement.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<OrderManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            service.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            service.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
