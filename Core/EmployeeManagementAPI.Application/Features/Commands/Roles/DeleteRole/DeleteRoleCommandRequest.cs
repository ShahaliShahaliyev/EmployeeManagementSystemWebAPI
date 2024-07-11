using MediatR;

namespace EmployeeManagementAPI.Application.Features.Commands.Roles.DeleteRole
{
    public class DeleteRoleCommandRequest :IRequest<DeleteRoleCommandResponse>
    {
        public int Id { get; set; }
    }
}