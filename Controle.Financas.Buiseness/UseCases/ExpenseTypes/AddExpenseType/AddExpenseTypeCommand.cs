using AccountService.Domain.DTOs.ExpenseType;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using ApiResult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.ExpenseTypes.AddExpenseTypes
{
    public class AddExpenseTypeCommand(string name, string description, int userId) : IRequest<ApiResult<ExpenseTypeResponse>>
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public int UserId { get; set; } = userId;

        public static implicit operator AddExpenseType(AddExpenseTypeCommand command)
        {
            return new AddExpenseType(command.Name, command.Description, command.UserId);
        }

        internal class AddExpenseTypeHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<AddExpenseTypeCommand, ApiResult<ExpenseTypeResponse>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;

            public async Task<ApiResult<ExpenseTypeResponse>> Handle(AddExpenseTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseTypeResponse>();
                await apiResult
                    .ExecuteAsync(
                        func: async () => await _expenseTypeRepository.AddAsync(request),
                        validation: e => e.Id > 0);
                return apiResult;
            }
        }
    }
}
