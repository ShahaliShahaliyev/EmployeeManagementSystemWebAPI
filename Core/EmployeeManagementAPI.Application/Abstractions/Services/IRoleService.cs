using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public interface  IRoleService
    {
        (object,int) GetAllRoles(int page,int size);
        Task<(int id, string name)> GetRoleByID(int Id);
        Task<bool> CreateRoleAsync(string name);
        Task<bool> UpdateRoleAsync(int Id,string name);
        Task<bool> DeleteRoleAsync(int Id);
    }
}
