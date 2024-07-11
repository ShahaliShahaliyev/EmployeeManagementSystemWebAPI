using EmployeeManagementAPI.Application.Consts;
using EmployeeManagementAPI.Application.CustomAttributes;
using EmployeeManagementAPI.Application.Enums;
using EmployeeManagementAPI.Application.Features.Commands.AssignRoleToUsers;
using EmployeeManagementAPI.Application.Features.Commands.Users.CreateUser;
using EmployeeManagementAPI.Application.Features.Commands.Users.LoginUser;
using EmployeeManagementAPI.Application.Features.Commands.Users.UpdatePassword;
using EmployeeManagementAPI.Application.Features.Queries.Users.GetRolesToUsers;
using EmployeeManagementAPI.Application.Features.Queries.Users.GetUsers;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Application.WiewModels.UsersWiewModel;
using EmployeeManagementAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody]UpdatePasswordCommandReuqest updatePasswordCommandRequest )
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionTypes.Reading, Definition = "Get All Users", Menu = AuthorizeDefinitionConstants.Users)]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllusersQueryRequest getAllusersQueryRequest)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(getAllusersQueryRequest);
            return Ok(response);
        }

        [HttpGet("get-role-to-users/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionTypes.Reading, Definition = "Get Roles To Users", Menu = AuthorizeDefinitionConstants.Users)]
        public async Task<IActionResult> GetRolesToUsers([FromRoute] GetRolesToUsersQueryRequest getRolesToUsersQueryRequest)
        {
            GetRolesToUsersQueryResponse response = await _mediator.Send(getRolesToUsersQueryRequest);
            return Ok(response);
        }

        [HttpPost("assign-role-to-users")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionTypes.Writing, Definition = "Assign Role to Users", Menu = AuthorizeDefinitionConstants.Users)]
        public async Task<IActionResult> AssignRolesToUsers(AssignRoleToUsersCommandRequest roleToUsersCommandRequest)
        {
            AssignRoleToUsersCommandResponse response = await _mediator.Send(roleToUsersCommandRequest);
            return Ok(response);
        }
        
    }
}
