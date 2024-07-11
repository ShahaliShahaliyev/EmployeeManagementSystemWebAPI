using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Permission> _roleManager;

        public RoleService(RoleManager<Permission> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Name = name });
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(int Id)
        {
            Permission? permission = await _roleManager.FindByIdAsync(Id.ToString());

            IdentityResult result = await _roleManager.DeleteAsync(permission);
            return result.Succeeded;
        }

        public (object, int) GetAllRoles(int page, int size)
        {

            var query = _roleManager.Roles;

            IQueryable<Permission> rolesQuery = null;

            if (page != -1 && size != -1)
            {
                rolesQuery = query.Skip(page * size).Take(size);
            }
            else
            {
                rolesQuery = query;
            }
            return (rolesQuery.Select(r => new { r.Id, r.Name }), query.Count());
        }

        public async Task<(int id, string name)> GetRoleByID(int Id)
        {
            string roles = await _roleManager.GetRoleIdAsync(new() { Id = Id });
            return (Id, roles);
        }

        public async Task<bool> UpdateRoleAsync(int Id, string name)
        {
            Permission? permission = await _roleManager.FindByIdAsync(Id.ToString());
            permission.Name = name;

            IdentityResult result = await _roleManager.UpdateAsync(permission);
            return result.Succeeded;
        }
    }
}
