using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Employees
{
    public class EmployeesCreateCommandHandler : IRequestHandler<EmployeesCreateCommandRequest, EmployeesCreateCommandResponse>
    {
        public Task<EmployeesCreateCommandResponse> Handle(EmployeesCreateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
