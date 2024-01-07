using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Models;

namespace Controle.Financas.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByEmailAndPassword(string email, string password);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> InsertUser(AddUserDTO user);
        Task<User> UpdateUser(UpdateUserDTO user);
        Task DeleteUser(int id);
    }
}
