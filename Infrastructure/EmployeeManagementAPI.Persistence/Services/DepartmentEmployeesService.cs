using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.DTOs.DepartmentEmployees;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Services
{
    public class DepartmentEmployeesService : IDepartmentEmployeesService
    {
        readonly EmployeeManagementAPIDbContext _context;
        readonly IEmployeeReadRepository _employeeReadRepository;

        public DepartmentEmployeesService(EmployeeManagementAPIDbContext context, IEmployeeReadRepository employeeReadRepository)
        {
            _context = context;
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<object> GetEmployeeDepartmentsByIdAsync(int employeeId)
        {

            var query = from de in _context.DepartmentEmployees
                        join d in _context.Departments
                        on de.DepartmentId equals d.Id
                        join e in _context.Employees
                        on de.EmployeeId equals e.Id
                        where de.EmployeeId == employeeId
                        select new
                        {
                            DepartmentName = d.Name,
                            EmployeeName = e.Name
                        };
            var depEmp = await query.ToListAsync();

            return depEmp;
            
        }

        async Task<object> IDepartmentEmployeesService.AddEmployeeToDepartment(DEAddDTO dEAddDTO)
        {
            DepartmentEmployees de = new DepartmentEmployees()
            {
                DepartmentId = dEAddDTO.DepartmentId,
                EmployeeId = dEAddDTO.EmployeeId
            };

            var newED = await _context.DepartmentEmployees.AddAsync(de);

            DEOutputDTO dEOutput = new DEOutputDTO()
            {
                DepartmentId = newED.Entity.DepartmentId,
                EmployeeId = newED.Entity.EmployeeId
            };

            await _context.SaveChangesAsync();
            return dEOutput;
        }
    }
}
