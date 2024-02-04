using AccountService.Business.UseCases.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Accounts.GetAccounts
{
    public class GetAccountsQuery : IRequest<ApiResult<IEnumerable<AccountResponse>>>
    {
        public int UserId { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        internal class GetAccountsQueryHandler(IAccountRepository accountRepository) : IRequestHandler<GetAccountsQuery, ApiResult<IEnumerable<AccountResponse>>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<IEnumerable<AccountResponse>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<AccountResponse>>();

                await apiResult.ExecuteAsync(
                    func: async () => 
                        (await _accountRepository.GetAllByUserIdAsync(request.UserId, request.IgnoreDeleted))
                        .ToList().ConvertAll<AccountResponse>(x => x)
                );
                return apiResult;
            }
        }
    }
}
