using MediatR;

namespace EmployeeManagementAPI.Application.Features.Queries.Employees.GetEmployees
{
    public class GetAllEmployeesQueryRequest : IRequest<GetAllEmployeesQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}