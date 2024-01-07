using Controle.Financas.Domain.DTOs.Account;
using Controle.Financas.Domain.Enums;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Infra.Contexts;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;

namespace Controle.Financas.EFConfiguration.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbSet<Account> _dbSet;
        private readonly ControleFinancasContext _context;
        public AccountRepository(ControleFinancasContext context)
        {
            _dbSet = context.Set<Account>();
            _context = context;
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Account?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllByUserIdAsync(int userId)
        {
            return await _dbSet.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Account> AddAsync(AddAccountDTO account)
        {
            var newAccount = new Account(account);
            await _dbSet.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            return newAccount;
        }

        public async Task<Account> UpdateAsync(UpdateAccountDTO account)
        {
            var updatedAccount = await _dbSet.FindAsync(account.Id) ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "Account");
            updatedAccount.Update(account);
            _dbSet.Update(updatedAccount);
            await _context.SaveChangesAsync();
            return updatedAccount;
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _dbSet.FindAsync(id) ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "Account");
            account.SetStatus(EStatus.Deleted);
            _dbSet.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
