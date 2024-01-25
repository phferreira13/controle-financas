using AccountService.Domain.Models;

namespace AccountService.Business.UseCases.AccountTypes
{
    public class AccountTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator AccountTypeResponse?(AccountType accountType)
        {
            if (accountType == null)
                return null;

            return new AccountTypeResponse
            {
                Id = accountType.Id,
                Name = accountType.Name
            };
        }
    }
}
