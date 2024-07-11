using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Repositories
{
    public class EmployeePositionWriteRepository : WriteContainedRepository<EmployeePosition>, IEmployeePositionWriteRepository
    {
        public EmployeePositionWriteRepository(EmployeeManagementAPIDbContext context) : base(context)
        {
        }
    }
}
