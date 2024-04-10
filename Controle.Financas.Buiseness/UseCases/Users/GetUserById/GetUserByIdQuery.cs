using AccountService.Domain.Filters.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Users.GetUserById
{
    public class GetUserByIdQuery(int id) : IRequest<ApiResult<UserResponse>>
    {
        public int Id { get; set; } = id;

        public static implicit operator UserFilter(GetUserByIdQuery query) => new() { Id = query.Id };

        internal class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, ApiResult<UserResponse>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<UserResponse>();
                UserFilter filter = request;

                await apiResult.ExecuteAsync(
                    func: async () => await _userRepository.GetOneByFilterAsync(filter),
                    validation: data => data != null
                );

                return apiResult;
            }
        }
    }
}
