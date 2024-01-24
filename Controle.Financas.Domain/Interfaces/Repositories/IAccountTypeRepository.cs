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
        Task<IEnumerable<AccountType>> GetAllAsync(bool ingnoreDeleted = true);
        Task<AccountType> AddAsync(AddAccountTypeDto accountType);
        Task<AccountType> UpdateAsync(UpdateAccountTypeDto accountType);
        Task<AccountType> DeleteAsync(int id);
        Task<AccountType> ChangeStatus(int id, EStatus status);

    }
}
