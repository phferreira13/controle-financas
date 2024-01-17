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
                var user = await _userRepository.GetUserByIdAsync(request.Id);

                var response = new ApiResult<UserResponse>();
                if(user != null)
                    response.SetData(user);
                else
                    response.AddError(ErrorMessageService.GetErrorMessage(EErrorType.NotFound, "User not found"));

                return response;
            }
        }
    }
}
