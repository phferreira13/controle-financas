using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Buiseness.UseCases.Users.GetUserById
{
    public class GetUserByIdQuery(int id) : IRequest<UserResponse>
    {
        public int Id { get; set; } = id;

        internal class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserResponse>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetUserByIdAsync(request.Id);

                return user ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "User not found");
            }
        }
    }
}
