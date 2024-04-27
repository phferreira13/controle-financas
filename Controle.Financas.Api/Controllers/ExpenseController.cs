using AccountService.Business.UseCases.Expenses;
using AccountService.Business.UseCases.Expenses.AddExpenses;
using AccountService.Business.UseCases.Expenses.GetExpenseById;
using AccountService.Business.UseCases.Expenses.GetExpenses;
using AccountService.Business.UseCases.Expenses.UpdateExpenses;
using ApiResult.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/expense")]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<ExpenseResponse>>), 200)]
        public async Task<ApiResult<IEnumerable<ExpenseResponse>>> GetExpenses([FromQuery] GetExpensesQuery query)
        {
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<ExpenseResponse>), 200)]
        public async Task<ApiResult<ExpenseResponse>> AddExpense([FromBody] AddExpenseCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<ExpenseResponse>), 200)]
        public async Task<ApiResult<ExpenseResponse>> GetExpenseById([FromRoute] int id)
        {
            var query = new GetExpenseByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return response;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult<ExpenseResponse>), 200)]
        public async Task<ApiResult<ExpenseResponse>> UpdateExpense([FromRoute] int id, [FromBody] UpdateExpenseCommand command)
        {
            command.SetId(id);
            var response = await _mediator.Send(command);
            return response;
        }
    }
}


