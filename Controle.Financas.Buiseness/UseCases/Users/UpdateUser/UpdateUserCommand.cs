using AccountService.Domain.DTOs.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;

namespace AccountService.Business.UseCases.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<ApiResult<UserResponse>>
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public static implicit operator UpdateUserDto(UpdateUserCommand user)
        {
            return new UpdateUserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password
            };
        }

        internal class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, ApiResult<UserResponse>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<UserResponse>();

                return await apiResult.ExecuteAsync(
                    func: async () => await _userRepository.UpdateUserAsync(request),
                    validation: data => data != null
                );
            }
        }
    }
}
