using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Repositories
{
    public interface IReadContainedRepository<T>:IContainedRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool tracking = true);
    }
}
