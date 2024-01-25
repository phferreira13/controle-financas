using AccountService.Domain.DTOs.Accounts;

namespace AccountService.Tests.Shared.Factories.Accounts
{
    public class AddAccountDtoFactory
    {
        private readonly Faker<AddAccountDto> _faker;

        public AddAccountDtoFactory()
        {
            _faker = new Faker<AddAccountDto>("pt_BR")
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.ActualBalance, f => f.Random.Decimal(min: 0))
                .RuleFor(x => x.InitialBalance, f => f.Random.Decimal(min: 0))
                .RuleFor(x => x.AccountTypeId, f => f.Random.Int(min: 1))
                .RuleFor(x => x.UserId, f => f.Random.Int(min: 1));
        }

        public AddAccountDtoFactory WithName(string name)
        {
            _faker.RuleFor(x => x.Name, f => name);
            return this;
        }

        public AddAccountDtoFactory WithActualBalance(decimal actualBalance)
        {
            _faker.RuleFor(x => x.ActualBalance, f => actualBalance);
            return this;
        }

        public AddAccountDtoFactory WithInitialBalance(decimal initialBalance)
        {
            _faker.RuleFor(x => x.InitialBalance, f => initialBalance);
            return this;
        }

        public AddAccountDtoFactory WithAccountTypeId(int accountTypeId)
        {
            _faker.RuleFor(x => x.AccountTypeId, f => accountTypeId);
            return this;
        }

        public AddAccountDtoFactory WithUserId(int userId)
        {
            _faker.RuleFor(x => x.UserId, f => userId);
            return this;
        }

        public AddAccountDto Generate()
        {
            return _faker.Generate();
        }

        public IEnumerable<AddAccountDto> Generate(int quantity)
        {
            return _faker.Generate(quantity);
        }
    }
}
