using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Repositories
{
    public interface IEmployeePositionWriteRepository<T> : IContainedRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);

        Task<int> SaveAsync();
    }
}
