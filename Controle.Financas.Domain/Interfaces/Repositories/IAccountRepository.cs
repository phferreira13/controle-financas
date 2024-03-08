using AccountService.Domain.DTOs.Accounts;
using AccountService.Domain.Models;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> AddAsync(AddAccountDto account);
        Task<Account> UpdateAsync(UpdateAccountDto account);
        Task<Account> DeleteAsync(int id);
    }
}
