using AccountService.Domain.Filters.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Accounts.GetAccounts
{
    public class GetAccountsQuery : IRequest<ApiResult<IEnumerable<AccountResponse>>>
    {
        public int UserId { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public static implicit operator AccountFilter(GetAccountsQuery query) => new()
        {
            UserId = query.UserId,
            IgnoreDeleted = query.IgnoreDeleted
        };

        internal class GetAccountsQueryHandler(IAccountRepository accountRepository) : IRequestHandler<GetAccountsQuery, ApiResult<IEnumerable<AccountResponse>>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<IEnumerable<AccountResponse>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<AccountResponse>>();
                AccountFilter filter = request;

                await apiResult.ExecuteAsync(
                    func: async () =>
                        (await _accountRepository.GetAllByFilter(filter))
                        .ToList()
                        .ConvertAll<AccountResponse>(x => x)
                );
                return apiResult;
            }
        }
    }
}
