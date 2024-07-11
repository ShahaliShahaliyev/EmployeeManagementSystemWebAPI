using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Departments.GetDepartmentsById
{
    public class GetDepartmentsByIdQueryRequest :IRequest<GetDepartmentsByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}