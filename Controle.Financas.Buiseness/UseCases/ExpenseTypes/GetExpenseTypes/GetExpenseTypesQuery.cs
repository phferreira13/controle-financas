using AccountService.Domain.Enums;
using AccountService.Domain.Filters;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.ExpenseTypes.GetExpenseTypes
{
    public class GetExpenseTypesQuery : IRequest<ApiResult<IEnumerable<ExpenseTypeResponse>>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public List<EStatus>? Status { get; set; }

        public static implicit operator ExpenseTypeFilter(GetExpenseTypesQuery query)
        {
            return new ExpenseTypeFilter
            {
                Name = query.Name,
                Description = query.Description,
                UserId = query.UserId,
                Id = query.Id,
                Status = query.Status
            };
        }

        internal class GetExpenseTypesHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<GetExpenseTypesQuery, ApiResult<IEnumerable<ExpenseTypeResponse>>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;

            public async Task<ApiResult<IEnumerable<ExpenseTypeResponse>>> Handle(GetExpenseTypesQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<ExpenseTypeResponse>>();
                ExpenseTypeFilter filter = request;
                var res = await _expenseTypeRepository.GetAllByFilterAsync(filter);
                apiResult.Data = res.Select(x => (ExpenseTypeResponse)x);
                return apiResult;

            }
        }
    }
}
