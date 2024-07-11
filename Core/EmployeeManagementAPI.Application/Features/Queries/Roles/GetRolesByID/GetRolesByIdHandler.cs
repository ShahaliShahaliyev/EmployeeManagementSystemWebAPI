using EmployeeManagementAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Queries.Roles.GetRolesByID
{
    public class GetRolesByIdHandler : IRequestHandler<GetRolesByIdRequest, GetRolesByIdResponse>
    {
        readonly IRoleService _roleService;

        public GetRolesByIdHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        async Task<GetRolesByIdResponse> IRequestHandler<GetRolesByIdRequest, GetRolesByIdResponse>.Handle(GetRolesByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetRoleByID(request.Id);

            return new()
            {
                Id = result.id,
                Name = result.name,
            };
        }
    }
}
