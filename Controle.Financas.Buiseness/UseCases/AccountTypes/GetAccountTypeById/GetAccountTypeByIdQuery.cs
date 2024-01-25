using AccountService.Business.UseCases.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

namespace AccountService.Business.UseCases.AccountTypes.GetAccountTypeById
{
    public class GetAccountTypeByIdQuery(int id) : IRequest<ApiResult<AccountTypeResponse>>
    {
        public int Id { get; set; } = id;

        internal class GetAccountTypeByIdQueryHandler : IRequestHandler<GetAccountTypeByIdQuery, ApiResult<AccountTypeResponse>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository;

            public GetAccountTypeByIdQueryHandler(IAccountTypeRepository accountTypeRepository)
            {
                _accountTypeRepository = accountTypeRepository;
            }

            public async Task<ApiResult<AccountTypeResponse>> Handle(GetAccountTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<AccountTypeResponse>();
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.GetByIdAsync(request.Id),
                    errorOnNull: true,
                    customErrorMessage: "Account type not found"
                    );
            }
        }
    }
}
