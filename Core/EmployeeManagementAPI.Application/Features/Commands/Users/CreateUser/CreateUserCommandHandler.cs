using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.DTOs.User;
using EmployeeManagementAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

         CreateUserResponseDTO response = await   _userService.CreateUserAsync(new()
            {
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                Password = request.Password,
               
            });

            return new()
            {
                Message = response.Message,
                Succedded = response.Succedded,
            };

        }
    }
}
