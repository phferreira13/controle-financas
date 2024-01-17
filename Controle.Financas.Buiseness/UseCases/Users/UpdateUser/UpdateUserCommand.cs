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

namespace Controle.Financas.Buiseness.UseCases.Users.UpdateUser
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
                var response = new ApiResult<UserResponse>();

                try
                {
                    UserResponse user = await _userRepository.UpdateUserAsync(request);
                    if (user != null)
                        response.SetData(user);
                    else
                        response.AddError(ErrorMessageService.GetErrorMessage(EErrorType.InternalServerError, "Error on updating User"));
                        return response;
                }
                catch (Exception ex)
                {
                    response.AddError(ex.Message);
                    return response;
                }
            }
        }
    }
}
