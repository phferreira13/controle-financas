using AccountService.Domain.DTOs.ExpenseType;
using AccountService.Domain.Filters;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.ExpenseTypes.UpdateExpenseTypes
{
    public class UpdateExpenseTypeCommand(string name, string description) : IRequest<ApiResult<ExpenseTypeResponse>>
    {
        private int Id { get; set; }
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;

        public void SetId(int id) => Id = id;

        public static implicit operator UpdateExpenseType(UpdateExpenseTypeCommand command) 
            => new ()
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description
            };

        public static implicit operator ExpenseTypeFilter(UpdateExpenseTypeCommand command)
            => new ()
            {
                Id = command.Id
            };

        internal class UpdateExpenseTypeCommandHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<UpdateExpenseTypeCommand, ApiResult<ExpenseTypeResponse>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;
            public async Task<ApiResult<ExpenseTypeResponse>> Handle(UpdateExpenseTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseTypeResponse>();
                ExpenseTypeFilter filter = request;
                await apiResult.ExecuteAsync(
                    func: async () =>
                    {
                        var expenseType = await _expenseTypeRepository.GetOneByFilterAsync(filter);
                        if (expenseType is null) return null;

                        expenseType.Update(request);
                        await _expenseTypeRepository.UpdateAsync(expenseType);
                        return expenseType;
                    },
                    validation: e => e is not null);


                return apiResult;
            }
        }
    }
}
