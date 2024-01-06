using Controle.Financas.Domain.DTOs.Account;
using Controle.Financas.Domain.Models.Base;

namespace Controle.Financas.Domain.Models
{
    public class Account(AddAccountDTO addAccountDTO) : UserEntityBase(addAccountDTO.UserId)
    {
        public string Name { get; private set; } = addAccountDTO.Name;
        public decimal InitialBalance { get; private set; } = addAccountDTO.InitialBalance;
        public decimal ActualBalance { get; private set; } = addAccountDTO.ActualBalance;
        public int AccountTypeId { get; private set; } = addAccountDTO.AccountTypeId;
        public virtual AccountType? AccountType { get; private set; }

        public void Update(UpdateAccountDTO updateAccountDTO)
        {
            Name = updateAccountDTO.Name;
            InitialBalance = updateAccountDTO.InitialBalance;
            ActualBalance = updateAccountDTO.ActualBalance;
            AccountTypeId = updateAccountDTO.AccountTypeId;
            UpdateDate();
        }
    }
}
