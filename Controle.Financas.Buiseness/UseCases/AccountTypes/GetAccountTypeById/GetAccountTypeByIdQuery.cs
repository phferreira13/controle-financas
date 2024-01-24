using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Models;
using Controle.Financas.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Business.AccountTypes.GetAccountTypeById
{
    public class GetAccountTypeByIdQuery(int id) : IRequest<ApiResult<AccountTypeResponse>>
    {
        public int Id { get; set; } = id;

        internal class GetAccountTypeByIdQueryHandler : IRequestHandler<GetAccountTypeByIdQuery, ApiResult<AccountTypeResponse>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository;

            public GetAccountTypeByIdQueryHandler(IAccountTypeRepository accountTypeRepository)
            {
                _accountTypeRepository = accountTypeRepository;
            }

            public async Task<ApiResult<AccountTypeResponse>> Handle(GetAccountTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountTypeResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.GetByIdAsync(request.Id),
                    errorOnNull: true,
                    customErrorMessage: "Account type not found"
                    );
            }
        }
    }
}
