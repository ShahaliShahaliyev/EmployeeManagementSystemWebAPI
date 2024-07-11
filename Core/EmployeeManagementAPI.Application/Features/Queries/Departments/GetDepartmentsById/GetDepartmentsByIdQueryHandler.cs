using EmployeeManagementAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Queries.Departments.GetDepartmentsById
{
    public class GetDepartmentsByIdQueryHandler : IRequestHandler<GetDepartmentsByIdQueryRequest, GetDepartmentsByIdQueryResponse>
    {
        readonly IDepartmentService _departmentService;

        public GetDepartmentsByIdQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<GetDepartmentsByIdQueryResponse> Handle(GetDepartmentsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetDepartmentbyId(request.Id);

            return new()
            {
                Id = result.id,
                Name = result.name,
            };
        }
    }
}
