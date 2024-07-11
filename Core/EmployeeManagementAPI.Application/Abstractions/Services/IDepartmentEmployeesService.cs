using EmployeeManagementAPI.Application.DTOs.DepartmentEmployees;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Abstractions.Services
{
    public interface IDepartmentEmployeesService
    {
        Task<object> AddEmployeeToDepartment(DEAddDTO dEAddDTO);
        Task<object> GetEmployeeDepartmentsByIdAsync(int employeeId);
    }
}
