using AccountService.Business.UseCases.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.AccountTypes.GetAccountTypes
{
    public class GetAccountTypesQuery : IRequest<ApiResult<List<AccountTypeResponse>>>
    {
        public bool IgnoreDeleted { get; set; }

        internal class GetAccountTypesQueryHandler(IAccountTypeRepository accountTypeRepository) : IRequestHandler<GetAccountTypesQuery, ApiResult<List<AccountTypeResponse>>>
        {
            private readonly IAccountTypeRepository _accountTypeRepository = accountTypeRepository;

            public async Task<ApiResult<List<AccountTypeResponse>>> Handle(GetAccountTypesQuery request, CancellationToken cancellationToken)
            {
                var accountTypes = await _accountTypeRepository.GetAllAsync(request.IgnoreDeleted);
                var response = new ApiResult<List<AccountTypeResponse>>();
                return await response.ExecuteAsync(() => Task.Run(() => accountTypes.ToList().ConvertAll<AccountTypeResponse>(at => at)));
                 
            }
        }
    }
}
