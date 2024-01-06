using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Models.Base;

namespace Controle.Financas.Domain.Models
{
    public class User : EntityBase
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User() { }
        public User(AddUserDTO addUserDTO)
        {
            FullName = addUserDTO.FullName;
            Email = addUserDTO.Email;
            Password = addUserDTO.Password;
        }

        public void Update(UpdateUserDTO updateUserDTO)
        {
            FullName = updateUserDTO.FullName;
            Email = updateUserDTO.Email;
            Password = updateUserDTO.Password;
            UpdateDate();
        }
    }
}
