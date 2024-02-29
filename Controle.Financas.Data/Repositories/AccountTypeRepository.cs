using AccountService.Domain.DTOs.AccountTypes;
using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using AccountService.EFConfiguration.Contexts;
using AccountService.Shared.Enums;
using AccountService.Shared.Services;

namespace AccountService.EFConfiguration.Repositories
{
    public class AccountTypeRepository(ControleFinancasContext context) : IAccountTypeRepository
    {
        private readonly DbSet<AccountType> _dbSet = context.Set<AccountType>();
        private readonly ControleFinancasContext _context = context;

        public async Task<AccountType?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<AccountType?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(at => at.Name == name);
        }

        public async Task<AccountType?> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(at => at.UserId == userId);
        }

        public async Task<IEnumerable<AccountType>> GetAllAsync(bool ingnoreDeleted = true)
        {
            var query = _dbSet.AsQueryable();
            if (ingnoreDeleted)
                query = query.Where(at => at.Status != EStatus.Deleted);
            return await query.ToListAsync();
        }

        public async Task<AccountType> AddAsync(AddAccountTypeDto accountType)
        {
            var newAccountType = new AccountType(accountType);
            await _dbSet.AddAsync(newAccountType);
            await _context.SaveChangesAsync();
            return newAccountType;
        }

        public async Task<AccountType> UpdateAsync(UpdateAccountTypeDto accountType)
        {
            var updatedAccountType = await _dbSet.FindAsync(accountType.Id)
                ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "AccountType");
            updatedAccountType.Update(accountType);
            _dbSet.Update(updatedAccountType);
            await _context.SaveChangesAsync();
            return updatedAccountType;
        }

        public async Task<AccountType> DeleteAsync(int id)
        {
            return await ChangeStatus(id, EStatus.Deleted);
        }

        public async Task<AccountType> ChangeStatus(int id, EStatus status)
        {
            var accountType = await _dbSet.FindAsync(id)
                ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "AccountType");
            accountType.SetStatus(status);
            _dbSet.Update(accountType);
            await _context.SaveChangesAsync();
            return accountType;
        }

        public Task<AccountType?> GetOneByFilter(IFilter<AccountType> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountType>> GetAllByFilter(IFilter<AccountType> filter)
        {
            throw new NotImplementedException();
        }
    }
}
