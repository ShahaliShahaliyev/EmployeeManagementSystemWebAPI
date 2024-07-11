using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Users.GetUsers
{
    public class GetAllusersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}