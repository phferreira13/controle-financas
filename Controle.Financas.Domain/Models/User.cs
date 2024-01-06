using Controle.Financas.Domain.DTOs.Users;
using Controle.Financas.Domain.Models.Base;

namespace Controle.Financas.Domain.Models
{
    public class User(AddUserDTO adicionarUsuarioDTO) : EntityBase
    {
        public string FullName { get; private set; } = adicionarUsuarioDTO.FullName;
        public string Email { get; private set; } = adicionarUsuarioDTO.Email;
        public string Password { get; private set; } = adicionarUsuarioDTO.Password;

        public void Update(UpdateUserDTO updateUserDTO)
        {
            FullName = updateUserDTO.FullName;
            Email = updateUserDTO.Email;
            Password = updateUserDTO.Password;
            UpdateDate();
        }
    }
}
