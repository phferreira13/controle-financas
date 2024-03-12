using AccountService.Domain.Filters.AccountTypes;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.AccountTypes.GetAccountTypeById
{
    public class GetAccountTypeByIdQuery(int id) : IRequest<ApiResult<AccountTypeResponse>>
    {
        public int Id { get; set; } = id;

        public static implicit operator AccountTypeFilter(GetAccountTypeByIdQuery query)
        {
            return new AccountTypeFilter { Id = query.Id };
        }

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
                AccountTypeFilter filter = request;
                return await apiResult.ExecuteAsync(
                    func: async () => await _accountTypeRepository.GetOneByFilter(filter),
                    validation: data => data is not null
                    );
            }
        }
    }
}
