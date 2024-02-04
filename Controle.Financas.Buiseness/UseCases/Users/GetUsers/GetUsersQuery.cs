using AccountService.Business.UseCases.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Users.GetUsers
{
    public class GetUsersQuery : IRequest<ApiResult<IEnumerable<UserResponse>>>
    {
        public bool IgnoreDeleted { get; set; }
        internal class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, ApiResult<IEnumerable<UserResponse>>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<IEnumerable<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                //var users = await _userRepository.GetAllUsersAsync(request.IgnoreDeleted);

                var response = new ApiResult<IEnumerable<UserResponse>>();
                return await response.ExecuteAsync(
                    async () => (await _userRepository.GetAllUsersAsync(request.IgnoreDeleted)).ToList().ConvertAll<UserResponse>(u => u));
            }
        }
    }
}
