using AccountService.Business.UseCases.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

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

                var accounts = await _accountRepository.GetAllByUserIdAsync(request.UserId, request.IgnoreDeleted);
                var response = accounts.Select(x => (AccountResponse)x);

                apiResult.SetData(response);

                return apiResult;
            }
        }
    }
}
