using AccountService.Business.UseCases.Users;
using AccountService.Business.UseCases.Users.AddUser;
using AccountService.Business.UseCases.Users.DeleteUser;
using AccountService.Business.UseCases.Users.GetUserById;
using AccountService.Business.UseCases.Users.GetUsers;
using AccountService.Business.UseCases.Users.UpdateUser;
using ApiResult.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<UserResponse>), 201)]
        public async Task<ApiResult<UserResponse>> AddUser([FromBody] AddUserCommand user)
        {
            var response = await _mediator.Send(user);
            return response;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<UserResponse>>), 200)]
        public async Task<ApiResult<IEnumerable<UserResponse>>> GetUsers([FromQuery] GetUsersQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResult<UserResponse>), 200)]
        public async Task<ApiResult<UserResponse>> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return response;
        }

        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResult<UserResponse>), 200)]
        public async Task<ApiResult<UserResponse>> UpdateUser(int id, [FromBody] UpdateUserCommand user)
        {
            user.Id = id;
            var response = await _mediator.Send(user);
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResult<UserResponse>), 200)]
        public async Task<ApiResult<UserResponse>> DeleteUser(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return response;
        }
    }
}
