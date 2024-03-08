using AccountService.Domain.Filters.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Users.GetUsers
{
    public class GetUsersQuery : IRequest<ApiResult<IEnumerable<UserResponse>>>
    {
        public bool IgnoreDeleted { get; set; }
        public static implicit operator UserFilter(GetUsersQuery query) => new() { IgnoreDeleted = query.IgnoreDeleted };

        internal class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, ApiResult<IEnumerable<UserResponse>>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<IEnumerable<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<UserResponse>>();
                UserFilter filter = request;

                await apiResult.ExecuteAsync(
                    func: async () => 
                        (await _userRepository.GetAllByFilter(filter))
                        .ToList()
                        .ConvertAll<UserResponse>(u => u));

                return apiResult;
            }
        }
    }
}
