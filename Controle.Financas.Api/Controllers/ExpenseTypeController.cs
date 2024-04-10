using AccountService.Business.UseCases.ExpenseTypes;
using AccountService.Business.UseCases.ExpenseTypes.AddExpenseTypes;
using AccountService.Business.UseCases.ExpenseTypes.ExpenseTypeGetById;
using AccountService.Business.UseCases.ExpenseTypes.GetExpenseTypes;
using AccountService.Business.UseCases.ExpenseTypes.UpdateExpenseTypes;
using ApiResult.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/expense-type")]
    public class ExpenseTypeController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<ExpenseTypeResponse>>), 200)]
        public async Task<ApiResult<IEnumerable<ExpenseTypeResponse>>> GetExpenseTypes([FromQuery] GetExpenseTypesQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<ExpenseTypeResponse>), 200)]
        public async Task<ApiResult<ExpenseTypeResponse>> AddExpenseType([FromBody] AddExpenseTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<ExpenseTypeResponse>), 200)]
        public async Task<ApiResult<ExpenseTypeResponse>> GetExpenseTypeById([FromRoute] int id)
        {
            var query = new ExpenseTypeGetByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult<ExpenseTypeResponse>), 200)]
        public async Task<ApiResult<ExpenseTypeResponse>> UpdateExpenseType([FromRoute] int id, [FromBody] UpdateExpenseTypeCommand command)
        {
            command.SetId(id);
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
