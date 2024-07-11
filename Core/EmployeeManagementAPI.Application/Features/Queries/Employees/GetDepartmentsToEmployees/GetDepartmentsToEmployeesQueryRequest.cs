using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Employees.GetDepartmentsToEmployees
{
    public class GetDepartmentsToEmployeesQueryRequest : IRequest<GetDepartmentsToEmployeesQueryResponse>
    {
        public int EmployeeId { get; set; }

    }
}