using AccountService.Domain.Enums;
using AccountService.Domain.Filters;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.Expenses.GetExpenses
{
    public class GetExpensesQuery : IRequest<ApiResult<IEnumerable<ExpenseResponse>>>
    {
        public decimal? Value { get; set; }
        public bool? IsPaid { get; set; }
        public int? AccountId { get; set; }
        public int? ExpenseTypeId { get; set; }
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public DateTime? StartDateRegistered { get; set; }
        public DateTime? EndDateRegistered { get; set; }
        public DateTime? StartDatePayment { get; set; }
        public DateTime? EndDatePayment { get; set; }
        public List<EStatus>? Status { get; set; }

        public static implicit operator ExpenseFilter(GetExpensesQuery query)
        {
            return new ExpenseFilter
            {
                Value = query.Value,
                IsPaid = query.IsPaid,
                AccountId = query.AccountId,
                ExpenseTypeId = query.ExpenseTypeId,
                UserId = query.UserId,
                Id = query.Id,
                StartDateRegistered = query.StartDateRegistered,
                EndDateRegistered = query.EndDateRegistered,
                StartDatePayment = query.StartDatePayment,
                EndDatePayment = query.EndDatePayment,
                Status = query.Status
            };
        }

        internal class GetExpensesHandler(IExpenseRepository expenseRepository) : IRequestHandler<GetExpensesQuery, ApiResult<IEnumerable<ExpenseResponse>>>
        {
            private readonly IExpenseRepository _expenseRepository = expenseRepository;

            public async Task<ApiResult<IEnumerable<ExpenseResponse>>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<ExpenseResponse>>();
                ExpenseFilter filter = request;
                var res = await _expenseRepository.GetAllByFilterAsync(filter);
                apiResult.Data = res.Select(x => (ExpenseResponse)x);
                return apiResult;
            }
        }
    }
}

