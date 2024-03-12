using AccountService.Domain.DTOs.Users;
using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using AccountService.EFConfiguration.Contexts;
using AccountService.Shared.Enums;
using AccountService.Shared.Services;

namespace AccountService.EFConfiguration.Repositories
{
    public class UserRepository(ControleFinancasContext context) : BaseRepository<User>(context.Users), IUserRepository
    {
        private readonly DbSet<User> Users = context.Users;
        private readonly ControleFinancasContext _context = context;

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
