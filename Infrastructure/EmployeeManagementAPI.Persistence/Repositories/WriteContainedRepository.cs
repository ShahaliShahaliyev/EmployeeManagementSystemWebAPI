using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Repositories
{
    public class WriteContainedRepository<T> : IEmployeePositionWriteRepository<T> where T : class
    {
        private readonly EmployeeManagementAPIDbContext _context;

        public WriteContainedRepository(EmployeeManagementAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
