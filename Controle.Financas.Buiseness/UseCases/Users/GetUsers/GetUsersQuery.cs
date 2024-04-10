using AccountService.Domain.Enums;
using AccountService.Domain.Filters.Users;
using AccountService.Domain.Interfaces.Repositories;
using ApiResult.Models;
using AutoFilterQuery.Attributes;
using AutoFilterQuery.Enums;

namespace AccountService.Business.UseCases.Users.GetUsers
{
    public class GetUsersQuery : IRequest<ApiResult<IEnumerable<UserResponse>>>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Id { get; set; }
        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public static implicit operator UserFilter(GetUsersQuery query) => new() 
        { 
            FullName = query.FullName,
            Email = query.Email,
            Password = query.Password,
            Id = query.Id,
            IgnoreDeleted = query.IgnoreDeleted,
            Status = query.Status
        };

        internal class GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, ApiResult<IEnumerable<UserResponse>>>
        {
            private readonly IUserRepository _userRepository = userRepository;

            public async Task<ApiResult<IEnumerable<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<UserResponse>>();
                UserFilter filter = request;

                await apiResult.ExecuteAsync(
                    func: async () => 
                        (await _userRepository.GetAllByFilterAsync(filter))
                        .ToList()
                        .ConvertAll<UserResponse>(u => u));

                return apiResult;
            }
        }
    }
}
