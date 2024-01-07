using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Infra.Contexts;

namespace Controle.Financas.EFConfiguration.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly DbSet<AccountType> _dbSet;
        private readonly ControleFinancasContext _context;
        public AccountTypeRepository(ControleFinancasContext context)
        {
            _dbSet = context.Set<AccountType>();
            _context = context;
        }

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

        public async Task<IEnumerable<AccountType>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<AccountType> AddAsync(AddAccountTypeDTO accountType)
        {
            var newAccountType = new AccountType(accountType);
            await _dbSet.AddAsync(newAccountType);
            await _context.SaveChangesAsync();
            return newAccountType;
        }

        public async Task<AccountType> UpdateAsync(UpdateAccountTypeDTO accountType)
        {
            var updatedAccountType = await _dbSet.FindAsync(accountType.Id) ?? throw new Exception("AccountType not found");
            updatedAccountType.Update(accountType);
            _dbSet.Update(updatedAccountType);
            await _context.SaveChangesAsync();
            return updatedAccountType;
        }

        public async Task DeleteAsync(int id)
        {
            var accountType = await _dbSet.FindAsync(id) ?? throw new Exception("AccountType not found");
            accountType.Delete();
            _dbSet.Update(accountType);
            await _context.SaveChangesAsync();
        }
    }
}
