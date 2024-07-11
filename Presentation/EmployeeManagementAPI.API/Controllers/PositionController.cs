using EmployeeManagementAPI.Application.Consts;
using EmployeeManagementAPI.Application.CustomAttributes;
using EmployeeManagementAPI.Application.Enums;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Application.RequestParameters;
using EmployeeManagementAPI.Application.WiewModels;
using EmployeeManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes="Admin")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionReadRepository _positionReadRepository;
        private readonly IPositionWriteRepository _positionWriteRepository;

        public PositionController(IPositionWriteRepository positionWriteRepository, IPositionReadRepository positionReadRepository)
        {
            _positionReadRepository = positionReadRepository;
            _positionWriteRepository = positionWriteRepository;
        }

        [HttpGet]
        [AuthorizeDefinition(Menu =AuthorizeDefinitionConstants.Position,ActionType =ActionTypes.Reading,
            Definition = "Get All Positions")]
        public async  Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _positionReadRepository.GetAll().Count();
            var positions = (_positionReadRepository.GetAll().Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p =>new {
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
                positions
            });
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Position, ActionType = ActionTypes.Reading,
            Definition = "Get Position by Id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _positionReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Position, ActionType = ActionTypes.Writing,
            Definition = "Create Position")]
        public async Task<IActionResult> Post(WM_Create_Position model)
        {
            if (ModelState.IsValid)
            {

            }

            await _positionWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                IsDeleted = false
            });
            await _positionWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Position, ActionType = ActionTypes.Updating,
            Definition = "Update Position")]
        public async Task<IActionResult> Put(WM_Update_Position model)
        {
            Position position = await _positionReadRepository.GetByIdAsync(model.Id);
            position.Name = model.Name;
            await _positionWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Position, ActionType = ActionTypes.Reading,
            Definition = "Delete Position")]
        public async Task<IActionResult> Delete(int id)
        {
            await _positionWriteRepository.RemoveAsync(id);
            await _positionWriteRepository.SaveAsync();

            return Ok();
        }

    }
}
