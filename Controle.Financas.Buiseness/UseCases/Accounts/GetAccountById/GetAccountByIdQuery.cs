using AccountService.Domain.Filters.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Accounts.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<ApiResult<AccountResponse>>
    {
        public int Id { get; set; }

        public static implicit operator AccountFilter(GetAccountByIdQuery query) => new()
        {
            Id = query.Id
        };

        internal class GetAccountByIdQueryHandler(IAccountRepository accountRepository) : IRequestHandler<GetAccountByIdQuery, ApiResult<AccountResponse>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<AccountResponse>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountResponse>();
                AccountFilter filter = request;

                return await apiResult.ExecuteAsync(
                    func: async () => await _accountRepository.GetOneByFilter(filter),
                    validation: data => data != null
                );
            }
        }

    }
}
