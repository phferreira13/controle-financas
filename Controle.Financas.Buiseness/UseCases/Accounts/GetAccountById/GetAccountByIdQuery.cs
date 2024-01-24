using Controle.Financas.Business.UseCases.Accounts;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Models;
using MediatR;

namespace Controle.Financas.Business.Accounts.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<ApiResult<AccountResponse>>
    {
        public int Id { get; set; }

        internal class GetAccountByIdQueryHandler(IAccountRepository accountRepository) : IRequestHandler<GetAccountByIdQuery, ApiResult<AccountResponse>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<AccountResponse>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountRepository.GetByIdAsync(request.Id),
                    errorOnNull: true,
                    customErrorMessage: "Account not found"
                );
            }
        }

    }
}
