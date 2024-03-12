using AccountService.Domain.DTOs.AccountTypes;
using AccountService.Domain.Enums;
using AccountService.Domain.Models;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IAccountTypeRepository : IRepository<AccountType>
    {
        Task<AccountType> AddAsync(AddAccountTypeDto accountType);
        Task<AccountType> UpdateAsync(UpdateAccountTypeDto accountType);
        Task<AccountType> DeleteAsync(int id);
        Task<AccountType> ChangeStatus(int id, EStatus status);

    }
}
