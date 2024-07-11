using EmployeeManagementAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.AssignRoleToUsers
{
    public class AssignRoleToUsersCommandHandler : IRequestHandler<AssignRoleToUsersCommandRequest, AssignRoleToUsersCommandResponse>
    {
        readonly IUserService _userService;

        public AssignRoleToUsersCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AssignRoleToUsersCommandResponse> Handle(AssignRoleToUsersCommandRequest request, CancellationToken cancellationToken)
        {

            await _userService.AssignRoletoUsers(request.UserId, request.Roles);
            return new();
        }
    }
}
