using AccountService.Domain.Enums;
using AccountService.Domain.Extensions;
using AccountService.Domain.Models;

namespace AccountService.Business.UseCases.Users
{
    public class UserResponse
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public EStatus Status { get; set; }
        public string StatusDescription { get => Status.GetDescription(); }

        public static implicit operator UserResponse?(User user)
        {
            if (user == null)
                return null;

            return new UserResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Status = user.Status
            };
        }
    }
}
