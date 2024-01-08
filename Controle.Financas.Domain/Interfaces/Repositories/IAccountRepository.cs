using Controle.Financas.Domain.DTOs.Account;
using Controle.Financas.Domain.Models;

namespace Controle.Financas.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(int id);
        Task<Account?> GetByNameAsync(string name);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<IEnumerable<Account>> GetAllByUserIdAsync(int userId);
        Task<Account> AddAsync(AddAccountDto account);
        Task<Account> UpdateAsync(UpdateAccountDto account);
        Task DeleteAsync(int id);
    }
}
