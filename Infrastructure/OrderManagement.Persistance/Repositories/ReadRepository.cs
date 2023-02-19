using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Repositories;
using OrderManagement.Domain.Entities.Common;
using OrderManagement.Persistance.Contexts;

namespace OrderManagement.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OrderManagementDbContext _context;

        public ReadRepository(OrderManagementDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
            => filter == null ? Table : Table.Where(filter);

        public async Task<T> GetByIdAsync(int id)
            //=> Table.FirstOrDefaultAsync(data => data.Id == id);
            => await Table.FindAsync(id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
            => await Table.FirstOrDefaultAsync(filter);

    }
}
