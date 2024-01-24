using Controle.Financas.Business.UseCases.Accounts;
using Controle.Financas.Domain.DTOs.Account;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Models;
using MediatR;

namespace Controle.Financas.Business.UseCases.Accounts.AddAccount
{
    public class AddAccountCommand : IRequest<ApiResult<AccountResponse>>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int AccountTypeId { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal ActualBalance { get; set; } = 0;

        public static implicit operator AddAccountDto(AddAccountCommand command)
            => new()
            {
                UserId = command.UserId,
                Name = command.Name,
                AccountTypeId = command.AccountTypeId,
                InitialBalance = command.InitialBalance,
                ActualBalance = command.ActualBalance
            };

        internal class AddAccountCommandHandler(IAccountRepository accountRepository) : IRequestHandler<AddAccountCommand, ApiResult<AccountResponse>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<AccountResponse>> Handle(AddAccountCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountRepository.AddAsync(request),
                    errorOnNull: true,
                    customErrorMessage: "Error on add account"
                );
            }
        }
    }
}
