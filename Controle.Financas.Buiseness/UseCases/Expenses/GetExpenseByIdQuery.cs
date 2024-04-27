using AccountService.Domain.Filters;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.Expenses.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ApiResult<ExpenseResponse>>
    {
        public int Id { get; set; }

        public static implicit operator ExpenseFilter(GetExpenseByIdQuery query)
            => new()
            {
                Id = query.Id
            };

        internal class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ApiResult<ExpenseResponse>>
        {
            private readonly IExpenseRepository _expenseRepository;

            public GetExpenseByIdQueryHandler(IExpenseRepository expenseRepository)
            {
                _expenseRepository = expenseRepository;
            }

            public async Task<ApiResult<ExpenseResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
            {
                ExpenseFilter filter = request;
                var apiResult = new ApiResult<ExpenseResponse>();
                await apiResult.ExecuteAsync(
                    func: async () => await _expenseRepository.GetOneByFilterAsync(filter),
                    validation: e => e is not null);
                return apiResult;
            }
        }
    }
}

