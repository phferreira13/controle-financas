using AccountService.Domain.Enums;
using AccountService.Domain.Filters.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Accounts.GetAccounts
{
    public class GetAccountsQuery : IRequest<ApiResult<IEnumerable<AccountResponse>>>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public decimal? InitialBalance { get; set; }
        public decimal? ActualBalance { get; set; }
        public int? AccountTypeId { get; set; }
        public int? UserId { get; set; }
        public bool IgnoreDeleted { get; set; } = true;
        public IEnumerable<EStatus>? Status { get; set; }

        public static implicit operator AccountFilter(GetAccountsQuery query) => new()
        {
            Id = query.Id,
            Name = query.Name,
            InitialBalance = query.InitialBalance,
            ActualBalance = query.ActualBalance,
            AccountTypeId = query.AccountTypeId,
            UserId = query.UserId,
            IgnoreDeleted = query.IgnoreDeleted,
            Status = query.Status
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
                        (await _accountRepository.GetAllByFilterAsync(filter))
                        .ToList()
                        .ConvertAll<AccountResponse>(x => x)
                );
                return apiResult;
            }
        }
    }
}
