using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Enums;
using Controle.Financas.Domain.Models;

namespace Controle.Financas.Domain.Interfaces.Repositories
{
    public interface IAccountTypeRepository
    {
        Task<AccountType?> GetByIdAsync(int id);
        Task<AccountType?> GetByNameAsync(string name);
        Task<AccountType?> GetByUserIdAsync(int userId);
        Task<IEnumerable<AccountType>> GetAllAsync();
        Task<AccountType> AddAsync(AddAccountTypeDTO accountType);
        Task<AccountType> UpdateAsync(UpdateAccountTypeDTO accountType);
        Task DeleteAsync(int id);
        Task<AccountType> ChangeStatus(int id, EStatus status);

    }
}
