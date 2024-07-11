using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.DTOs.User;
using EmployeeManagementAPI.Application.Exceptions;
using EmployeeManagementAPI.Application.Features.Commands.Users.CreateUser;
using EmployeeManagementAPI.Application.Helpers;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<User> _userManager;
        readonly IEndpointReadRepository _endpointReadRepository;

        public UserService(UserManager<User> userManager,
            IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
        }



        public async Task<CreateUserResponseDTO> CreateUserAsync(UserCreateDTO model)
        {

            IdentityResult identityResult = await _userManager.CreateAsync(new()
            {
                UserName = model.UserName,
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                Password = model.Password,
                IsActive = true,
                IsDeleted = false,


                // HashedPassword = request.Password.GetHashCode(),

            }, model.Password);

            CreateUserResponseDTO response = new() { Succedded = identityResult.Succeeded };

            if (identityResult.Succeeded)
                response.Message = "User Created Successfully!";
            else
                foreach (var error in identityResult.Errors)

                    response.Message += $"{error.Code} - {error.Description}";
            return response;
        }

        public async Task<List<ListUser>> GetAllUsers(int page, int size)
        {
            var users = await _userManager.Users.Skip(page * size).Take(size).ToListAsync();

            return users.Select(user => new ListUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Surname = user.Surname,
                Name = user.Name,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted
            }).ToList();
        }

        public int TotalUsersCount => _userManager.Users.Count();

        public async Task UpdatePasswordAsync(int userId, string resetToken, string newPassword)
        {
            User? user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();

                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }

        public async Task AssignRoletoUsers(int userId, string[] roles)
        {
            User? user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, roles);
            }
        }

        public async Task<string[]> GetRolesToUser(int userIdOrName)
        {
            User? user = await _userManager.FindByIdAsync(userIdOrName.ToString());
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(userIdOrName.ToString());
            }
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<string[]> GetRolesToUserByName(string name)
        {
            User? user = await _userManager.FindByNameAsync(name);            
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            var userRoles = await GetRolesToUserByName(name);
            if (!userRoles.Any())
            {
                return false;
            }

            Endpoint? endpoint = await _endpointReadRepository.Table
                .Include(e => e.Roles)
                .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null)
            {
                return false;
            }

            //var hasRole = false;

            var endpoinRoles = endpoint.Roles.Select(r => r.Name);


            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpoinRoles)

                    if (userRole == endpointRole)
                        return true;

            }
            return false;
        }

       
    }
}
