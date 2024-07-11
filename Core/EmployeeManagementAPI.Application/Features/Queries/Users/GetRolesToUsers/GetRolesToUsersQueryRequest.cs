using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Users.GetRolesToUsers
{
    public class GetRolesToUsersQueryRequest :IRequest<GetRolesToUsersQueryResponse>
    {
        public int UserId { get; set; }
    }
}