using AccountService.Business.UseCases.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

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
                    validation: data => data != null
                );
            }
        }
    }
}
