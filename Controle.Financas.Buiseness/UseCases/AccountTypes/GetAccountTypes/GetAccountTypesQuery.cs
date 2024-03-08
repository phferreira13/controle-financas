using AccountService.Domain.Filters.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.AccountTypes.GetAccountTypes
{
    public class GetAccountTypesQuery : IRequest<ApiResult<List<AccountTypeResponse>>>
    {
        public bool IgnoreDeleted { get; set; }
        public static implicit operator AccountTypeFilter(GetAccountTypesQuery query)
        {
            return new AccountTypeFilter { IgnoreDeleted = query.IgnoreDeleted };
        }

        internal class GetAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<GetAccountTypesQuery, ApiResult<List<AccountTypeResponse>>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<List<AccountTypeResponse>>> Handle(GetAccountTypesQuery request, CancellationToken cancellationToken)
            {
                AccountTypeFilter filter = request;
                var accountTypes = await _accountTypeRepository.GetAllByFilter(filter);
                var response = new ApiResult<List<AccountTypeResponse>>
                {
                    Data = accountTypes.ToList().ConvertAll<AccountTypeResponse>(at => at)
                };
                return response;

            }
        }
    }
}
