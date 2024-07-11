using EmployeeManagementAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    public class LoginUserSuccessCommandResponse:LoginUserCommandResponse
    {
        public TokenDTO Token { get; set; }
    }
    public class LoginUserErrorCommandResponse:LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}
