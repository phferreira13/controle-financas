using AccountService.Business.UseCases.AccountTypes;
using AccountService.Domain.DTOs.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

namespace AccountService.Business.UseCases.AccountTypes.UpdateAccountType
{
    public class UpdateAccountTypeCommand : IRequest<ApiResult<AccountTypeResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator UpdateAccountTypeDto(UpdateAccountTypeCommand updateAccountTypeCommand)
            => new(updateAccountTypeCommand.Id, updateAccountTypeCommand.Name);

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
