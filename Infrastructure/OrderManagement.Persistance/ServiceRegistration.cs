using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Persistance.Contexts;

namespace OrderManagement.Persistance
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddDbContext<OrderManagementContext>(options=>options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
