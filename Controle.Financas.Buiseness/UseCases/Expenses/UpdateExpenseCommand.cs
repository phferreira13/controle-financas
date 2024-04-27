using AccountService.Domain.DTOs.Expenses;
using AccountService.Domain.Filters;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.Expenses.UpdateExpenses
{
    public class UpdateExpenseCommand : IRequest<ApiResult<ExpenseResponse>>
    {
        private int Id { get; set; }
        public decimal Value { get; set; }
        public bool IsPaid { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public int ExpenseTypeId { get; set; }
        public DateTime? PaymentDate { get; set; }

        public void SetId(int id) => Id = id;

        public static implicit operator UpdateExpense(UpdateExpenseCommand command)
            => new(
                    value: command.Value,
                    isPaid: command.IsPaid,
                    registerDate: command.RegisterDate,
                    description: command.Description,
                    accountId: command.AccountId,
                    expenseTypeId: command.ExpenseTypeId,
                    paymentDate: command.PaymentDate
                );

        public static implicit operator ExpenseFilter(UpdateExpenseCommand command)
            => new()
            {
                Id = command.Id
            };

        internal class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, ApiResult<ExpenseResponse>>
        {
            private readonly IExpenseRepository _expenseRepository;

            public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository)
            {
                _expenseRepository = expenseRepository;
            }

            public async Task<ApiResult<ExpenseResponse>> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseResponse>();
                ExpenseFilter filter = request;
                await apiResult.ExecuteAsync(
                    func: async () =>
                    {
                        var expense = await _expenseRepository.GetOneByFilterAsync(filter);
                        if (expense is null) return null;
                        
                        UpdateExpense update = request;
                        expense = update.ApplyUpdate(expense);

                        await _expenseRepository.UpdateAsync(expense);
                        return expense;
                    },
                    validation: e => e is not null);

                return apiResult;
            }
        }
    }
}

