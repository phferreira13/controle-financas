using AccountService.Domain.Enums;
using AccountService.Domain.Filters.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.AccountTypes.GetAccountTypes
{
    public class GetAccountTypesQuery : IRequest<ApiResult<List<AccountTypeResponse>>>
    {
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; }
        public static implicit operator AccountTypeFilter(GetAccountTypesQuery query)
        {
            return new() 
            {
                Name = query.Name,
                IsDefault = query.IsDefault,
                Id = query.Id,
                UserId = query.UserId,
                Status = query.Status,
                IgnoreDeleted = query.IgnoreDeleted
            };
        }

        internal class GetAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<GetAccountTypesQuery, ApiResult<List<AccountTypeResponse>>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<List<AccountTypeResponse>>> Handle(GetAccountTypesQuery request, CancellationToken cancellationToken)
            {
                AccountTypeFilter filter = request;
                var accountTypes = await _accountTypeRepository.GetAllByFilterAsync(filter);
                var response = new ApiResult<List<AccountTypeResponse>>
                {
                    Data = accountTypes.ToList().ConvertAll<AccountTypeResponse>(at => at)
                };
                return response;

            }
        }
    }
}
