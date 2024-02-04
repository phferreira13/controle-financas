using AccountService.Business.UseCases.Accounts;
using AccountService.Business.UseCases.Accounts.AddAccount;
using AccountService.Business.UseCases.Accounts.DeleteAccount;
using AccountService.Business.UseCases.Accounts.GetAccountById;
using AccountService.Business.UseCases.Accounts.GetAccounts;
using AccountService.Business.UseCases.Accounts.UpdateAccount;
using ApiResult.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<AccountResponse>>), 200)]
        public async Task<ApiResult<IEnumerable<AccountResponse>>> GetAccounts([FromQuery] GetAccountsQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<AccountResponse>), 200)]
        public async Task<ApiResult<AccountResponse>> GetAccountById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetAccountByIdQuery { Id = id });
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<AccountResponse>), 200)]
        public async Task<ApiResult<AccountResponse>> AddAccount([FromBody] AddAccountCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult<AccountResponse>), 200)]
        public async Task<ApiResult<AccountResponse>> UpdateAccount([FromRoute] int id, [FromBody] UpdateAccountCommand command)
        {
            command.Id = id;
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult<AccountResponse>), 200)]
        public async Task<ApiResult<AccountResponse>> DeleteAccount([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteAccountCommand { Id = id });
            return response;
        }
    }
}
