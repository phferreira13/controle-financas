using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Enums;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.Infra.Contexts;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;

namespace Controle.Financas.EFConfiguration.Repositories
{
    public class UserRepository(ControleFinancasContext context) : IUserRepository
    {
        private readonly DbSet<User> Users = context.Users;
        private readonly ControleFinancasContext _context = context;

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool ingnoreDeleted = true)
        {
            var query = Users.AsQueryable();
            if (ingnoreDeleted)
                query = query.Where(u => u.Status != EStatus.Deleted);
            return await query.ToListAsync();
        }

        public async Task<User> InsertUserAsync(AddUserDto user)
        {
            var newUser = new User(user);
            await Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(UpdateUserDto user)
        {
            var updatedUser = await Users.FindAsync(user.Id) 
                ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "User");
            updatedUser.Update(user);
            Users.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            return await ChangeStatusAsync(id, EStatus.Deleted);
        }

        public async Task<User> ChangeStatusAsync(int id, EStatus status)
        {
            var user = await Users.FindAsync(id)
                ?? throw ErrorMessageService.GetException(EErrorType.NotFound, "User");
            user.SetStatus(status);
            Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
