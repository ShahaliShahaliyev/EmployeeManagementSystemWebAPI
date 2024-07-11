using EmployeeManagementAPI.Application.Consts;
using EmployeeManagementAPI.Application.CustomAttributes;
using EmployeeManagementAPI.Application.DTOs.Configuration;
using EmployeeManagementAPI.Application.DTOs.Departments;
using EmployeeManagementAPI.Application.Enums;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Application.RequestParameters;
using EmployeeManagementAPI.Application.WiewModels;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Timers;

namespace EmployeeManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentReadRepository _departmentReadRepository;

        private readonly IDepartmentWriteRepository _departmentWriteRepository;
        public DepartmentsController(IDepartmentReadRepository departmentReadRepository
            , IDepartmentWriteRepository departmentWriteRepository)
        {
            _departmentReadRepository = departmentReadRepository;
            _departmentWriteRepository = departmentWriteRepository;
        }

        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionTypes.Reading,
            Definition = "Get All Departments")]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _departmentReadRepository.GetAll().Count();
            var departments = (_departmentReadRepository.GetAll().Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new {
                p.Id,
                p.Name,
                p.CreateDate,
                p.DeletedDate,
                p.ModifiedDate,
                p.IsDeleted
            }).ToList());
            return Ok(new
            {
                totalCount,
                departments
            });
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionTypes.Reading,
            Definition = "Get Department by Id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _departmentReadRepository.GetByIdAsync(id));
        }

        [HttpGet("GetAllDepartmentsForList")]
        public async Task<IActionResult> GetAllDepartmentsForList() 
        {
            var departments = _departmentReadRepository.GetAll();
            return Ok(departments);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionTypes.Writing,
            Definition = "Create Department")]
        public async Task<IActionResult> Post(CreateDepartment model)
        {
            if (ModelState.IsValid)
            {

            }

            await _departmentWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                IsDeleted = false
            });
            await _departmentWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionTypes.Updating,
            Definition = "Update Department")]
        public async Task<IActionResult> Put(UpdateDepartment model)
        {
            Department department = await _departmentReadRepository.GetByIdAsync(model.Id);
            department.Name = model.Name;
            await _departmentWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionTypes.Reading,
           Definition = "Delete Department")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentWriteRepository.RemoveAsync(id);
            await _departmentWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
