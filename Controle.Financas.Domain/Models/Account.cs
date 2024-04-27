using AccountService.Domain.DTOs.Accounts;
using AccountService.Domain.Models.Base;

namespace AccountService.Domain.Models
{
    public class Account : UserEntityBase
    {
        public string Name { get; private set; }
        public decimal InitialBalance { get; private set; } = 0;
        public decimal ActualBalance { get; private set; } = 0;
        public int AccountTypeId { get; private set; }
        public virtual AccountType? AccountType { get; private set; }
        public virtual ICollection<Expense> Expenses { get; private set; } = new List<Expense>();

        private Account(string name, int accountTypeId)
        {
            Name = name;
            AccountTypeId = accountTypeId;
        }

        public Account(AddAccountDto addAccountDTO) : base(addAccountDTO.UserId)
        {
            Name = addAccountDTO.Name;
            InitialBalance = addAccountDTO.InitialBalance;
            ActualBalance = addAccountDTO.ActualBalance;
            AccountTypeId = addAccountDTO.AccountTypeId;
        }

        public void Update(UpdateAccountDto updateAccountDTO)
        {
            Name = updateAccountDTO.Name;
            InitialBalance = updateAccountDTO.InitialBalance;
            ActualBalance = updateAccountDTO.ActualBalance;
            AccountTypeId = updateAccountDTO.AccountTypeId;
            UpdateDate();
        }
    }
}
