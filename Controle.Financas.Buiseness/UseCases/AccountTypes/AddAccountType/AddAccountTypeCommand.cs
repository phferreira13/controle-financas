using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Domain.Models;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Business.AccountTypes.AddAccountType
{
    public class AddAccountTypeCommand(string name, int userId) : IRequest<ApiResult<AccountTypeResponse>>
    {
        public string Name { get; set; } = name;
        public int UserId { get; set; } = userId;

        public static implicit operator AddAccountTypeDto(AddAccountTypeCommand addAccountTypeCommand)
            => new (addAccountTypeCommand.Name, addAccountTypeCommand.UserId);

        internal class AddAccountTypeCommandHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<AddAccountTypeCommand, ApiResult<AccountTypeResponse>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<AccountTypeResponse>> Handle(AddAccountTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountTypeResponse>();

                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.AddAsync(request),
                    errorOnNull: true,
                    customErrorMessage: "Error on inserting new Account Type"
                    );
            }
        }

    }
}
