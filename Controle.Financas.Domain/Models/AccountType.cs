using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Models.Base;

namespace Controle.Financas.Domain.Models
{
    public class AccountType : UserEntityBase
    {
        public string Name { get; private set; }
        public virtual ICollection<Account> Accounts { get; private set; } = new List<Account>();

        public AccountType() { }
        public AccountType(AddAccountTypeDTO addAccountTypeDTO) : base(addAccountTypeDTO.UserId)
        {
            Name = addAccountTypeDTO.Name;
        }

        public void Update(UpdateAccountTypeDTO updateAccountTypeDTO)
        {
            Name = updateAccountTypeDTO.Name;
            UpdateDate();
        }
    }
}
