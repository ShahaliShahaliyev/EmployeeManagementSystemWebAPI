using MediatR;

namespace EmployeeManagementAPI.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}