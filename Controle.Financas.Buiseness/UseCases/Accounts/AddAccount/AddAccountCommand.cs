using AccountService.Business.UseCases.Accounts;
using AccountService.Domain.DTOs.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

namespace AccountService.Business.UseCases.Accounts.AddAccount
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
