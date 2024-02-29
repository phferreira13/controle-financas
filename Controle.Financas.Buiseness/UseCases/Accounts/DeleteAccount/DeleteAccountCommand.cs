using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Accounts.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<ApiResult<AccountResponse>>
    {
        public int Id { get; set; }

        internal class DeleteAccountCommandHandler(IAccountRepository accountRepository) : IRequestHandler<DeleteAccountCommand, ApiResult<AccountResponse>>
        {
            private readonly IAccountRepository _accountRepository = accountRepository;

            public async Task<ApiResult<AccountResponse>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountRepository.DeleteAsync(request.Id),
                    validation: data => data != null
                );
            }
        }
    }
}
