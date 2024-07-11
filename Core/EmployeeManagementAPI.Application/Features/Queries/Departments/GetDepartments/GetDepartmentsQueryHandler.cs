using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Features.Queries.Roles.GetRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Queries.Departments.GetDepartments
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentQueryRequest, GetDepartmentQueryResponse>
    {
        readonly IDepartmentService _departmentService;

        public GetDepartmentsQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<GetDepartmentQueryResponse> Handle(GetDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var (datas, count) = _departmentService.GetAllDepartments(request.Page, request.Size);
            return new()
            {
                Datas = datas,
                TotalDepartmentCount = count
            };
        }
    }
}
