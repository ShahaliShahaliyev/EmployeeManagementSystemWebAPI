using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.DTOs.Employees;
using EmployeeManagementAPI.Application.DTOs.User;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Contexts;
using EmployeeManagementAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly EmployeeManagementAPIDbContext _context;
        readonly EmployeeReadRepository _employeeReadRepository;
        readonly DepartmentEmployeesService _departmentEmployeesService;

        public EmployeeService(EmployeeManagementAPIDbContext context,
                               EmployeeReadRepository employeeReadRepository,
                               DepartmentEmployeesService departmentEmployeesService)
        {
            _context = context;
            _employeeReadRepository = employeeReadRepository;
            _departmentEmployeesService = departmentEmployeesService;
        }

        public int TotalEmployeesCount => _context.Employees.Count();

        public Task AssignDepartmenttoEmployees(int employeeId, string[] departments)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ListEmployee>> GetAllEmployees(int page, int size)
        {
            var employees = await _context.Employees.Skip(page*size).Take(size).ToListAsync();

            return employees.Select(employee => new ListEmployee
            {
                Id = employee.Id,
                NameSurname = employee.Name + " " + employee.Surame
            }).ToList();
        }

        public async Task<string[]> GetDepartmentToEmployee(int employeeIdOrName)
        {
            //User? user = await _userManager.FindByIdAsync(userIdOrName.ToString());
            //if (user == null)
            //{
            //    user = await _userManager.FindByNameAsync(userIdOrName.ToString());
            //}
            //if (user != null)
            //{
            //    var userRoles = await _userManager.GetRolesAsync(user);
            //    return userRoles.ToArray();
            //}
            //return new string[] { };

            Employee? employee = await _employeeReadRepository.GetByIdAsync(employeeIdOrName);
            if (employee!=null)
            {
                  
            }
            return new string[] { };
        }

        public Task<string[]> GetDepartmentToEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
