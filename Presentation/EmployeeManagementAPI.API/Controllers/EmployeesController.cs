using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Consts;
using EmployeeManagementAPI.Application.CustomAttributes;
using EmployeeManagementAPI.Application.DTOs.DepartmentEmployees;
using EmployeeManagementAPI.Application.DTOs.Departments;
using EmployeeManagementAPI.Application.DTOs.Employees;
using EmployeeManagementAPI.Application.Enums;
using EmployeeManagementAPI.Application.Features.Commands.AssignRoleToUsers;
using EmployeeManagementAPI.Application.Features.Queries.Users.GetRolesToUsers;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Application.RequestParameters;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Contexts;
using EmployeeManagementAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IDepartmentEmployeeWriteRepository _departmentEmployeeWriteRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IDepartmentEmployeesService _departmentEmployeesService;
        readonly EmployeeManagementAPIDbContext _dbContext;

        public EmployeesController(IMediator mediator,
                                   IEmployeeReadRepository employeeReadRepository,
                                   IEmployeeWriteRepository employeeWriteRepository,
                                   IDepartmentEmployeesService departmentEmployeesService,
                                   IDepartmentEmployeeWriteRepository departmentEmployeeWriteRepository,
                                   EmployeeManagementAPIDbContext dbContext)
        {
            _mediator = mediator;
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _departmentEmployeesService = departmentEmployeesService;
            _departmentEmployeeWriteRepository = departmentEmployeeWriteRepository;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] Pagination pagination)
        {
            var totalCount = _employeeReadRepository.GetAll().Count();
            var employees = (_employeeReadRepository.GetAll().Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(e => new
            {
                e.Id,
                e.Name,
                e.Surame,
                e.DateOfBirth,
                e.CreateDate,
                e.ModifiedDate,
                e.DeletedDate,
            }).ToList());
            return Ok(new
            {
                totalCount,
                employees
            });
        }


        [HttpPost]
        public async Task<IActionResult> PostEmployee(CreateEmployee model)
        {
            if (ModelState.IsValid)
            {

            }

            await _employeeWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Surame = model.Surname,
                DateOfBirth = model.BirthOfDate,
                CreateDate = DateTime.Now,
                ModifiedDate = null,
                DeletedDate = null,
                IsDeleted = false
            });
            await _employeeWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateEmployee model)
        {
            Employee employee = await _employeeReadRepository.GetByIdAsync(model.Id);
            employee.Name = model.Name;
            employee.Surame = model.Surname;
            employee.PositionId = model.PositionId;
            employee.ManagerId = model.ManagerId;
            employee.ModifiedDate = DateTime.Now;
            await _employeeWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeWriteRepository.RemoveAsync(id);

            await _employeeWriteRepository.SaveAsync();

            return Ok();
        }


        [HttpGet("getDepartmentEmployeesById")]
        public async Task<IActionResult> GetEmployeeDepartmentsById(int employeeId)
        {
            var de = await _departmentEmployeesService.GetEmployeeDepartmentsByIdAsync(employeeId);
            return Ok(de);
        }

        [HttpPost("addEmployeeToDepartment")]
        public async Task<object> AddEmployeeToDepartments(DEAddDTO dEAddDTO)
        {
            var de = await _departmentEmployeesService.AddEmployeeToDepartment(dEAddDTO);
            return Ok(de);
        }


        //[HttpGet("get-department-to-employees/{EmployeeId}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(ActionType = ActionTypes.Reading, Definition = "Get Departments To Employees", Menu = AuthorizeDefinitionConstants.Employees)]
        //public async Task<IActionResult> GetDepartmentsToEmployees([FromRoute] GetRolesToUsersQueryRequest getRolesToUsersQueryRequest)
        //{
        //    GetRolesToUsersQueryResponse response = await _mediator.Send(getRolesToUsersQueryRequest);
        //    return Ok(response);
        //}

        //[HttpPost("assign-role-to-users")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(ActionType = ActionTypes.Writing, Definition = "Assign Role to Users", Menu = AuthorizeDefinitionConstants.Users)]
        //public async Task<IActionResult> AssignRolesToUsers(AssignRoleToUsersCommandRequest roleToUsersCommandRequest)
        //{
        //    AssignRoleToUsersCommandResponse response = await _mediator.Send(roleToUsersCommandRequest);
        //    return Ok(response);
        //}

    }
}
