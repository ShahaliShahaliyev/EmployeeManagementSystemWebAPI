using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Abstractions.Token;
using EmployeeManagementAPI.Application.DTOs;
using EmployeeManagementAPI.Application.Exceptions;
using EmployeeManagementAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token  =await _authService.LoginAsync(request.UsernameorEmail,request.Password);
            return new LoginUserSuccessCommandResponse()
            {
                Token= token,
            };
        }
    }
}
