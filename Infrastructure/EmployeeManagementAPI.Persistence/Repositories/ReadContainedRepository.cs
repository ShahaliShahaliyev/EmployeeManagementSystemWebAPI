using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Repositories
{
    public class ReadContainedRepository<T> : IReadContainedRepository<T> where T : class
    {
        private readonly EmployeeManagementAPIDbContext _context;

        public ReadContainedRepository(EmployeeManagementAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
