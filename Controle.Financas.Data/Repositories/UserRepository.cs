using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Enums;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Infra.Contexts;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;

namespace Controle.Financas.EFConfiguration.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        private readonly ControleFinancasContext _context;
        public UserRepository(ControleFinancasContext context)
        {
            _dbSet = context.Set<User>();
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> InsertUserAsync(AddUserDto user)
        {
            var newUser = new User(user);
            await _dbSet.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(UpdateUserDto user)
        {
            var updatedUser = await _dbSet.FindAsync(user.Id) 
                ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "User");
            updatedUser.Update(user);
            _dbSet.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            await ChangeStatusAsync(id, EStatus.Deleted);
        }

        public async Task<User> ChangeStatusAsync(int id, EStatus status)
        {
            var user = await _dbSet.FindAsync(id)
                ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "User");
            user.SetStatus(status);
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
