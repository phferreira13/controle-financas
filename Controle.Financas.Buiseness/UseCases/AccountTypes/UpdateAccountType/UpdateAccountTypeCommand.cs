using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Business.AccountTypes.UpdateAccountType
{
    public class UpdateAccountTypeCommand : IRequest<ApiResult<AccountTypeResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator UpdateAccountTypeDto(UpdateAccountTypeCommand updateAccountTypeCommand)
            => new (updateAccountTypeCommand.Id, updateAccountTypeCommand.Name);

        internal class UpdateAccountTypeCommandHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<UpdateAccountTypeCommand, ApiResult<AccountTypeResponse>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<AccountTypeResponse>> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountTypeResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.UpdateAsync(request),
                    errorOnNull: true,
                    customErrorMessage: "Error on updating Account Type"
                );
            }
        }
    }
}
