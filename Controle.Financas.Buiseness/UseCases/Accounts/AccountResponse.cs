using AccountService.Domain.Models;

namespace AccountService.Business.UseCases.Accounts
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountTypeId { get; set; }
        public string? AccountTypeName { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal ActualBalance { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public static implicit operator AccountResponse(Account account)
        {
            return new AccountResponse
            {
                Id = account.Id,
                Name = account.Name,
                AccountTypeId = account.AccountTypeId,
                AccountTypeName = account.AccountType?.Name,
                InitialBalance = account.InitialBalance,
                ActualBalance = account.ActualBalance,
                CreatedDate = account.CreatedDate,
                UpdatedDate = account.UpdatedDate
            };
        }
    }
}
