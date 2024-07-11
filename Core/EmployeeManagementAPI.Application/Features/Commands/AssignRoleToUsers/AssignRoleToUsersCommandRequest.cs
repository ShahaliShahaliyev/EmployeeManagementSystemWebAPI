using MediatR;

namespace EmployeeManagementAPI.Application.Features.Commands.AssignRoleToUsers
{
    public class AssignRoleToUsersCommandRequest :IRequest<AssignRoleToUsersCommandResponse>
    {
        public int UserId { get; set; }
        public string[]? Roles { get; set; }
    }
}