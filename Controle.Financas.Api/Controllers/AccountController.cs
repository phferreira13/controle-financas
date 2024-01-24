using Controle.Financas.Business.Accounts.GetAccountById;
using Controle.Financas.Business.UseCases.Accounts;
using Controle.Financas.Business.UseCases.Accounts.AddAccount;
using Controle.Financas.Business.UseCases.Accounts.DeleteAccount;
using Controle.Financas.Business.UseCases.Accounts.GetAccounts;
using Controle.Financas.Business.UseCases.Accounts.UpdateAccount;
using Controle.Financas.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controle.Financas.Api.Controllers
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
