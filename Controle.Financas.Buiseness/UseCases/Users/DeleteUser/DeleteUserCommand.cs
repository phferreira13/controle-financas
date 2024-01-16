using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Buiseness.UseCases.Users.DeleteUser
{
    public class DeleteUserCommand(int id) : IRequest<UserResponse>
    {
        public int Id { get; set; } = id;

        internal class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, UserResponse>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                UserResponse user = await _userRepository.DeleteUserAsync(request.Id);

                return user ?? throw ErrorMessageService.GetException(EErrorType.InternalServerError, "Error on deleting User");
            }
        }
    }
}
