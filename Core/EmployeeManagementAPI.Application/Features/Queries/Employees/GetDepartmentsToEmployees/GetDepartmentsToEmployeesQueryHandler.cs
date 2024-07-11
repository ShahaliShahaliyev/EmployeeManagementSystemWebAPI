using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Queries.Employees.GetDepartmentsToEmployees
{
    public class GetDepartmentsToEmployeesQueryHandler : IRequestHandler<GetDepartmentsToEmployeesQueryRequest, GetDepartmentsToEmployeesQueryResponse>
    {
        public Task<GetDepartmentsToEmployeesQueryResponse> Handle(GetDepartmentsToEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
