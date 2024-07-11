using MediatR;

namespace EmployeeManagementAPI.Application.Features.Commands.Employees
{
    public class EmployeesCreateCommandRequest :IRequest<EmployeesCreateCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirtOfDate { get; set; }
    }
}