using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Buiseness.UseCases.Users.AddUser
{
    public class AddUserCommand : IRequest<UserResponse>
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

        internal class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, UserResponse>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<UserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                UserResponse user = await _userRepository.InsertUserAsync(request);

                return user ?? throw ErrorMessageService.GetException(EErrorType.InternalServerError, "Error on inserting new User");
            }
        }
    }
}
