using AccountService.Business.UseCases.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Users.DeleteUser
{
    public class DeleteUserCommand(int id) : IRequest<ApiResult<UserResponse>>
    {
        public int Id { get; set; } = id;

        internal class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, ApiResult<UserResponse>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<UserResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<UserResponse>();

                return await apiResult.ExecuteAsync(
                    func: async () => await _userRepository.DeleteUserAsync(request.Id),
                    validation: data => data != null
                );
            }
        }
    }
}
