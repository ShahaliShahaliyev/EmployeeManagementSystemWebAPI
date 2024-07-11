using EmployeeManagementAPI.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDTO> CreateUserAsync(UserCreateDTO model);
        Task UpdatePasswordAsync(int userId, string resetToken, string newPassword);
        Task<List<ListUser>> GetAllUsers(int page, int size);
        int TotalUsersCount { get; }
        Task AssignRoletoUsers(int userId, string[] roles);
        Task<string[]> GetRolesToUser(int userIdOrName);
        Task<string[]> GetRolesToUserByName(string name);

        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
