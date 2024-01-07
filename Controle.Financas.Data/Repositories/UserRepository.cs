using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Infra.Contexts;

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

        public async Task<User?> GetUserById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> InsertUser(AddUserDTO user)
        {
            var newUser = new User(user);
            await _dbSet.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUser(UpdateUserDTO user)
        {
            var updatedUser = await _dbSet.FindAsync(user.Id) ?? throw new Exception("User not found");
            updatedUser.Update(user);
            _dbSet.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbSet.FindAsync(id) ?? throw new Exception("User not found");
            user.Delete();
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
