using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public  interface IDepartmentService
    {
        (object, int) GetAllDepartments(int page, int size);
        Task<(int id,string name)>GetDepartmentbyId(int Id);
    }
}
