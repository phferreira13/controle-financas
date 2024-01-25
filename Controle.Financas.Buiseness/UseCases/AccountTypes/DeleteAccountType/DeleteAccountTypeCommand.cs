using AccountService.Business.UseCases.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

namespace AccountService.Business.UseCases.AccountTypes.DeleteAccountType
{
    public class DeleteAccountTypeCommand(int id) : IRequest<ApiResult<AccountTypeResponse>>
    {
        public int Id { get; set; } = id;

        internal class DeleteAccountTypeCommandHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<DeleteAccountTypeCommand, ApiResult<AccountTypeResponse>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<AccountTypeResponse>> Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountTypeResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.DeleteAsync(request.Id),
                    errorOnNull: true,
                    customErrorMessage: "Error on deleting Account Type"
                );
            }
        }
    }
}
