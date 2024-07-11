using EmployeeManagementAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
    {
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        async Task<AssignRoleEndpointCommandResponse> IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>.Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
           await _authorizationEndpointService.AsignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);

            return new()
            {

            };
        }
    }
}
