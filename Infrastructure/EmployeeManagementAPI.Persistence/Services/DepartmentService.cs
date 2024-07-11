using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentReadRepository _readRepository;

        public DepartmentService(IDepartmentReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public (object, int) GetAllDepartments(int page, int size)
        {
            var query = _readRepository.GetAll();

            IQueryable<Department> departmentsQuery = null;

            if (page != -1 && size != -1)
            {
                departmentsQuery = query.Skip(page * size).Take(size);
            }
            else
            {
                departmentsQuery = query;
            }
            return (departmentsQuery.Select(d => new { d.Id, d.Name }), query.Count());
        }

        public async Task<(int id, string name)> GetDepartmentbyId(int Id)
        {
            string departments = await _readRepository.GetByIdAsync(Id);
            return (Id, departments);
        }
    }
}
