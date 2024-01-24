using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Models;
using Controle.Financas.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Buiseness.UseCases.Users.DeleteUser
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
                    errorOnNull: true,
                    customErrorMessage: "Error on deleting User"
                );
            }
        }
    }
}
