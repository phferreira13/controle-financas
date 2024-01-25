using AccountService.Business.UseCases.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

namespace AccountService.Business.UseCases.AccountTypes.GetAccountTypes
{
    public class GetAccountTypesQuery : IRequest<ApiResult<IEnumerable<AccountTypeResponse>>>
    {
        public bool IgnoreDeleted { get; set; }

        internal class GetAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<GetAccountTypesQuery, ApiResult<IEnumerable<AccountTypeResponse>>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<IEnumerable<AccountTypeResponse>>> Handle(GetAccountTypesQuery request, CancellationToken cancellationToken)
            {
                var accountTypes = await _accountTypeRepository.GetAllAsync(request.IgnoreDeleted);
                var response = new ApiResult<IEnumerable<AccountTypeResponse>>();
                response.SetData(accountTypes.ToList().ConvertAll<AccountTypeResponse>(at => at));
                return response;
            }
        }
    }
}
