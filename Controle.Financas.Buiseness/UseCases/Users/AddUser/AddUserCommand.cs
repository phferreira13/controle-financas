using AccountService.Business.UseCases.Users;
using AccountService.Domain.DTOs.Users;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Shared.Models;

namespace AccountService.Business.UseCases.Users.AddUser
{
    public class AddUserCommand : IRequest<ApiResult<UserResponse>>
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public static implicit operator AddUserDto(AddUserCommand user)
        {
            return new AddUserDto
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password
            };
        }

        internal class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, ApiResult<UserResponse>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<UserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<UserResponse>();

                return await apiResult.ExecuteAsync(
                    func: async () => await _userRepository.InsertUserAsync(request),
                    errorOnNull: true,
                    customErrorMessage: "Error on inserting new User"
                );
            }
        }
    }
}
