using EmployeeManagementAPI.Application.Consts;
using EmployeeManagementAPI.Application.CustomAttributes;
using EmployeeManagementAPI.Application.Enums;
using EmployeeManagementAPI.Application.Features.Commands.Roles.CreateRole;
using EmployeeManagementAPI.Application.Features.Commands.Roles.DeleteRole;
using EmployeeManagementAPI.Application.Features.Commands.Roles.UpdateRole;
using EmployeeManagementAPI.Application.Features.Queries.Roles.GetRoles;
using EmployeeManagementAPI.Application.Features.Queries.Roles.GetRolesByID;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType =ActionTypes.Reading,Definition ="Get All Roles",Menu =AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest rolesQueryRequest)
        {
            GetRolesQueryResponse response = await _mediator.Send(rolesQueryRequest);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionTypes.Reading, Definition = "Get Role By ID", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetRoles([FromBody] GetRolesByIdRequest byIdRequest)
        {
            GetRolesByIdResponse response = await _mediator.Send(byIdRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionTypes.Writing, Definition = "Create Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(ActionType = ActionTypes.Updating, Definition = "Update Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionTypes.Deleting, Definition = "Delete Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            DeleteRoleCommandResponse response = await _mediator.Send(deleteRoleCommandRequest);
            return Ok(response);
        }

    }
}
