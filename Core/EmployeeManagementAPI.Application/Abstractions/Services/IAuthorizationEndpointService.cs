using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public interface IAuthorizationEndpointService
    {
        public Task AsignRoleEndpointAsync(string[] roles,string menu, string code,Type type);
        public Task<List<string>> GetRolesToEndpointAsync(string code,string menu);
    }
}
