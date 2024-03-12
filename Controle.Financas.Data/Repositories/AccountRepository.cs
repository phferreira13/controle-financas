using AccountService.Domain.DTOs.Accounts;
using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using AccountService.EFConfiguration.Contexts;
using AccountService.Shared.Enums;
using AccountService.Shared.Services;

namespace AccountService.EFConfiguration.Repositories
{
    public class AccountRepository(ControleFinancasContext context) 
        : BaseRepository<Account>(context.Accounts), IAccountRepository
    {
        private readonly DbSet<Account> _dbSet = context.Accounts;
        private readonly ControleFinancasContext _context = context;

        public async Task<Account> AddAsync(AddAccountDto account)
        {
            var newAccount = new Account(account);
            await _dbSet.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            return newAccount;
        }

        public async Task<Account> UpdateAsync(UpdateAccountDto account)
        {
            var updatedAccount = await _dbSet.FindAsync(account.Id) ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "Account");
            updatedAccount.Update(account);
            _dbSet.Update(updatedAccount);
            await _context.SaveChangesAsync();
            return updatedAccount;
        }

        public async Task<Account> DeleteAsync(int id)
        {
            var account = await _dbSet.FindAsync(id) ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "Account");
            account.SetStatus(EStatus.Deleted);
            _dbSet.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}
