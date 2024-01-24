using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Business.AccountTypes.GetAccountTypes
{
    public class GetAccountTypesQuery: IRequest<ApiResult<IEnumerable<AccountTypeResponse>>>
    {
        public bool IgnoreDeleted { get; set; }

        internal class GetAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<GetAccountTypesQuery, ApiResult<IEnumerable<AccountTypeResponse>>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<IEnumerable<AccountTypeResponse>>> Handle(GetAccountTypesQuery request, CancellationToken cancellationToken)
            {
                var accountTypes = await _accountTypeRepository.GetAllAsync(request.IgnoreDeleted);
                var response = new ApiResult<IEnumerable<AccountTypeResponse>>();
                response.SetData(accountTypes.ToList().ConvertAll<AccountTypeResponse>(at => at));
                return response;
            }
        }
    }
}
