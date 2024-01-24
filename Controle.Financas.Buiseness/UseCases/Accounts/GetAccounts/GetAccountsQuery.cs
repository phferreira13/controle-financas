using Controle.Financas.Business.UseCases.Accounts;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Business.UseCases.Accounts.GetAccounts
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
