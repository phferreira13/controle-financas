using Controle.Financas.Domain.DTOs.Users;
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

namespace Controle.Financas.Buiseness.UseCases.Users.AddUser
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
                var response = new ApiResult<UserResponse>();

                try
                {
                    UserResponse user = await _userRepository.InsertUserAsync(request);
                    if (user != null)
                        response.SetData(user);
                    else
                        response.AddError(ErrorMessageService.GetErrorMessage(EErrorType.InternalServerError, "Error on inserting new User"));
                        return response;
                }
                catch (Exception ex)
                {
                    response.AddError(ErrorMessageService.GetErrorMessage(EErrorType.InternalServerError, ex.Message));
                    return response;
                }
            }
        }
    }
}
