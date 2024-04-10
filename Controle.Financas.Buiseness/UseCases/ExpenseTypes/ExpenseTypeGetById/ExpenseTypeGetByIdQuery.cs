using AccountService.Domain.Filters;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.ExpenseTypes.ExpenseTypeGetById
{
    public class ExpenseTypeGetByIdQuery : IRequest<ApiResult<ExpenseTypeResponse>>
    {
        public int Id { get; set; }

        public static implicit operator ExpenseTypeFilter(ExpenseTypeGetByIdQuery query) 
            => new ()
            {
                Id = query.Id
            };

        internal class ExpenseTypeGetByIdQueryHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<ExpenseTypeGetByIdQuery, ApiResult<ExpenseTypeResponse>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;

            public async Task<ApiResult<ExpenseTypeResponse>> Handle(ExpenseTypeGetByIdQuery request, CancellationToken cancellationToken)
            {
                ExpenseTypeFilter filter = request;
                var apiResult = new ApiResult<ExpenseTypeResponse>();
                await apiResult.ExecuteAsync(
                    func: async () => await _expenseTypeRepository.GetOneByFilterAsync(filter),
                    validation: e => e is not null);
                return apiResult;
            }
        }
    }
}
