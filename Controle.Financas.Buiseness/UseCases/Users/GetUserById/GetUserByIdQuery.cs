using AccountService.Business.UseCases.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Users.GetUserById
{
    public class GetUserByIdQuery(int id) : IRequest<ApiResult<UserResponse>>
    {
        public int Id { get; set; } = id;

        internal class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, ApiResult<UserResponse>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<UserResponse>();
                await apiResult.ExecuteAsync(
                    func: async () => await _userRepository.GetUserByIdAsync(request.Id),
                    validation: data => data != null
                );

                return apiResult;
            }
        }
    }
}
