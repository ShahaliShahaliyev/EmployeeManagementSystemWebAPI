using MediatR;

namespace EmployeeManagementAPI.Application.Features.Commands.Roles.UpdateRole
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}