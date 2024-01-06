using Controle.Financas.Domain.DTOs.Account;
using Controle.Financas.Domain.Models.Base;

namespace Controle.Financas.Domain.Models
{
    public class Account : UserEntityBase
    {
        public string Name { get; private set; }
        public decimal InitialBalance { get; private set; }
        public decimal ActualBalance { get; private set; }
        public int AccountTypeId { get; private set; }
        public virtual AccountType? AccountType { get; private set; }

        public Account() { }

        public Account(AddAccountDTO addAccountDTO) : base(addAccountDTO.UserId)
        {
            Name = addAccountDTO.Name;
            InitialBalance = addAccountDTO.InitialBalance;
            ActualBalance = addAccountDTO.ActualBalance;
            AccountTypeId = addAccountDTO.AccountTypeId;
        }

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
