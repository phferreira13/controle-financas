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

namespace Controle.Financas.Buiseness.UseCases.Users.GetUserById
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
                    errorOnNull: true,
                    customErrorMessage: "User not found"
                );

                return apiResult;
            }
        }
    }
}
