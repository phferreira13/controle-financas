using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.Expenses.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<ApiResult<ExpenseResponse>>
    {
        public int Id { get; set; }

        internal class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, ApiResult<ExpenseResponse>>
        {
            private readonly IExpenseRepository _expenseRepository;

            public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository)
            {
                _expenseRepository = expenseRepository;
            }

            public async Task<ApiResult<ExpenseResponse>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _expenseRepository.DeleteAsync(request.Id),
                    validation: data => data != null
                );
            }
        }
    }
}


