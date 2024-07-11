using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Departments.GetDepartments
{
    public class GetDepartmentQueryRequest :IRequest<GetDepartmentQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}