using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Models.Base;

namespace Controle.Financas.Domain.Models
{
    public class AccountType(AddAccountTypeDTO addAccountTypeDTO) : UserEntityBase(addAccountTypeDTO.UserId)
    {
        public string Name { get; private set; } = addAccountTypeDTO.Name;
        public virtual ICollection<Account> Accounts { get; private set; } = new List<Account>();

        public void Update(UpdateAccountTypeDTO updateAccountTypeDTO)
        {
            Name = updateAccountTypeDTO.Name;
            UpdateDate();
        }
    }
}
