using EmployeeManagementAPI.Application.DTOs.Employees;
using EmployeeManagementAPI.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public interface IEmployeeService
    {
        Task<List<ListEmployee>> GetAllEmployees(int page, int size);
        int TotalEmployeesCount { get; }
        Task AssignDepartmenttoEmployees(int employeeId, string[] departments);
        Task<string[]> GetDepartmentToEmployee(int employeeIdOrName);
        Task<string[]> GetDepartmentToEmployeeByName(string name);
    }
}
