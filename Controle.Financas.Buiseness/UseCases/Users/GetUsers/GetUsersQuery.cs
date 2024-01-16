using Controle.Financas.Domain.Interfaces.Repositories;
using MediatR;

namespace Controle.Financas.Buiseness.UseCases.Users.GetUsers
{
    public class GetUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
        public bool IgnoreDeleted { get; set; }
        internal class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, IEnumerable<UserResponse>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<IEnumerable<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetAllUsersAsync(request.IgnoreDeleted);

                return users.ToList().ConvertAll<UserResponse>(u => u);
            }
        }
    }
}
