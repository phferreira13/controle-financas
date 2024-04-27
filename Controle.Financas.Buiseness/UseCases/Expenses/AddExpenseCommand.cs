using AccountService.Domain.DTOs.Expenses;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Expenses.AddExpenses
{
    public class AddExpenseCommand : IRequest<ApiResult<ExpenseResponse>>
    {
        public decimal Value { get; set; }
        public bool IsPaid { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public int ExpenseTypeId { get; set; }
        public int UserId { get; set; }

        public static implicit operator AddExpense(AddExpenseCommand command)
        {
            return new AddExpense(
                userId: command.UserId,
                value: command.Value,
                isPaid: command.IsPaid,
                registerDate: command.RegisterDate,
                description: command.Description,
                accountId: command.AccountId,
                expenseTypeId: command.ExpenseTypeId,
                paymentDate: command.PaymentDate);
        }

        internal class AddExpenseHandler(IExpenseRepository expenseRepository) : IRequestHandler<AddExpenseCommand, ApiResult<ExpenseResponse>>
        {
            private readonly IExpenseRepository _expenseRepository = expenseRepository;

            public async Task<ApiResult<ExpenseResponse>> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseResponse>();
                await apiResult
                    .ExecuteAsync(
                        func: async () => await _expenseRepository.AddAsync(request),
                        validation: e => e.Id > 0);
                return apiResult;
            }
        }
    }
}

