using AccountService.Domain.DTOs.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<ApiResult<AccountResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal ActualBalance { get; set; } = 0;

        public static implicit operator UpdateAccountDto(UpdateAccountCommand command)
            => new()
            {
                Id = command.Id,
                Name = command.Name,
                InitialBalance = command.InitialBalance,
                ActualBalance = command.ActualBalance
            };

        internal class UpdateAccountCommandHandler(IAccountRepository accountRepository) : IRequestHandler<UpdateAccountCommand, ApiResult<AccountResponse>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<AccountResponse>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountRepository.UpdateAsync(request),
                    validation: data => data != null
                );
            }
        }
    }
}
