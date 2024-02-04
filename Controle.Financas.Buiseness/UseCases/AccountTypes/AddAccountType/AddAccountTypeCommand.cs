using AccountService.Domain.DTOs.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.AccountTypes.AddAccountType
{
    public class AddAccountTypeCommand(string name, int userId) : IRequest<ApiResult<AccountTypeResponse>>
    {
        public string Name { get; set; } = name;
        public int UserId { get; set; } = userId;

        public static implicit operator AddAccountTypeDto(AddAccountTypeCommand addAccountTypeCommand)
            => new(addAccountTypeCommand.Name, addAccountTypeCommand.UserId);

        internal class AddAccountTypeCommandHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<AddAccountTypeCommand, ApiResult<AccountTypeResponse>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<AccountTypeResponse>> Handle(AddAccountTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountTypeResponse>();

                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.AddAsync(request),
                    validation: data => data != null
                    );
            }
        }

    }
}
