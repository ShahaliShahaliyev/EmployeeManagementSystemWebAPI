using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Roles.GetRolesByID
{
    public class GetRolesByIdRequest:IRequest<GetRolesByIdResponse>
    {
        public int Id { get; set; }
    }
}