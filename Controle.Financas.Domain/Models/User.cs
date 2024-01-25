using AccountService.Domain.DTOs.Users;
using AccountService.Domain.Models.Base;

namespace AccountService.Domain.Models
{
    public class User : EntityBase
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public User(AddUserDto addUserDTO)
        {
            FullName = addUserDTO.FullName;
            Email = addUserDTO.Email;
            Password = addUserDTO.Password;
        }

        public void Update(UpdateUserDto updateUserDTO)
        {
            FullName = updateUserDTO.FullName;
            Email = updateUserDTO.Email;
            Password = updateUserDTO.Password;
            UpdateDate();
        }
    }
}
