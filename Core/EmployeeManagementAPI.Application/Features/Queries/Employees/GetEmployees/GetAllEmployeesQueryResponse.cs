namespace EmployeeManagementAPI.Application.Features.Queries.Employees.GetEmployees
{
    public class GetAllEmployeesQueryResponse
    {
        public object Employees { get; set; }
        public int TotalEmployeesCount { get; set; }
    }
}