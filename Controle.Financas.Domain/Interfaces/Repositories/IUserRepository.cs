using AccountService.Domain.DTOs.Users;
using AccountService.Domain.Enums;
using AccountService.Domain.Models;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> InsertUserAsync(AddUserDto user);
        Task<User> UpdateUserAsync(UpdateUserDto user);
        Task<User> DeleteUserAsync(int id);
        Task<User> ChangeStatusAsync(int id, EStatus status);
    }
}
