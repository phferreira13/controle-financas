using AccountService.Domain.DTOs.Users;
using AccountService.Domain.Enums;
using AccountService.Domain.Models;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<IEnumerable<User>> GetAllUsersAsync(bool ingnoreDeleted = true);
        Task<User> InsertUserAsync(AddUserDto user);
        Task<User> UpdateUserAsync(UpdateUserDto user);
        Task<User> DeleteUserAsync(int id);
        Task<User> ChangeStatusAsync(int id, EStatus status);
    }
}
