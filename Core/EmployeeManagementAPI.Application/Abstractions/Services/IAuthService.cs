using EmployeeManagementAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public  interface IAuthService
    {
        Task<TokenDTO> LoginAsync(string usernameOrEmail, string password);

        Task PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken,int userId);
    }
}
