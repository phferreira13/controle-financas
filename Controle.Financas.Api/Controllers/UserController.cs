using Controle.Financas.Buiseness.UseCases.Users;
using Controle.Financas.Buiseness.UseCases.Users.AddUser;
using Controle.Financas.Buiseness.UseCases.Users.DeleteUser;
using Controle.Financas.Buiseness.UseCases.Users.GetUserById;
using Controle.Financas.Buiseness.UseCases.Users.GetUsers;
using Controle.Financas.Buiseness.UseCases.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Financas.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), 201)]
        public async Task<UserResponse> AddUser([FromBody] AddUserCommand user)
        {
            var response = await _mediator.Send(user);
            return response;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), 200)]
        public async Task<IEnumerable<UserResponse>> GetUsers([FromQuery] GetUsersQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<UserResponse> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return response;
        }

        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<UserResponse> UpdateUser(int id, [FromBody] UpdateUserCommand user)
        {
            user.Id = id;
            var response = await _mediator.Send(user);
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        public async Task<UserResponse> DeleteUser(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return response;
        }
    }
}
