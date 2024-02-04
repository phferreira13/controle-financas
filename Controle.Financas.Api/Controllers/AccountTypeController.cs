using AccountService.Business.UseCases.AccountTypes;
using AccountService.Business.UseCases.AccountTypes.AddAccountType;
using AccountService.Business.UseCases.AccountTypes.DeleteAccountType;
using AccountService.Business.UseCases.AccountTypes.GetAccountTypeById;
using AccountService.Business.UseCases.AccountTypes.GetAccountTypes;
using AccountService.Business.UseCases.AccountTypes.UpdateAccountType;
using ApiResult.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/account-types")]
    public class AccountTypeController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<AccountTypeResponse>>), 200)]
        public async Task<ApiResult<List<AccountTypeResponse>>> GetAccountTypes([FromQuery] GetAccountTypesQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<AccountTypeResponse>), 200)]
        public async Task<ApiResult<AccountTypeResponse>> GetAccountTypeById(int id)
        {
            var response = await _mediator.Send(new GetAccountTypeByIdQuery(id));
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<AccountTypeResponse>), 201)]
        public async Task<ApiResult<AccountTypeResponse>> AddAccountType([FromBody] AddAccountTypeCommand accountType)
        {
            var response = await _mediator.Send(accountType);
            return response;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResult<AccountTypeResponse>), 200)]
        public async Task<ApiResult<AccountTypeResponse>> UpdateAccountType(int id, [FromBody] UpdateAccountTypeCommand accountType)
        {
            accountType.Id = id;
            var response = await _mediator.Send(accountType);
            return response;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult<AccountTypeResponse>), 200)]
        public async Task<ApiResult<AccountTypeResponse>> DeleteAccountType(int id)
        {
            var response = await _mediator.Send(new DeleteAccountTypeCommand(id));
            return response;
        }

    }
}
