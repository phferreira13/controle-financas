using AccountService.Domain.DTOs.Accounts;

namespace AccountService.Tests.Shared.Factories.Accounts
{
    public class UpdateAccountDtoFactory
    {
        private readonly Faker<UpdateAccountDto> _faker;

        public UpdateAccountDtoFactory()
        {
            _faker = new Faker<UpdateAccountDto>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Int(min: 1))
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.ActualBalance, f => f.Random.Decimal(min: 0))
                .RuleFor(x => x.InitialBalance, f => f.Random.Decimal(min: 0))
                .RuleFor(x => x.AccountTypeId, f => f.Random.Int(min: 1));
        }

        public UpdateAccountDtoFactory WithId(int id)
        {
            _faker.RuleFor(x => x.Id, f => id);
            return this;
        }

        public UpdateAccountDtoFactory WithName(string name)
        {
            _faker.RuleFor(x => x.Name, f => name);
            return this;
        }

        public UpdateAccountDtoFactory WithActualBalance(decimal actualBalance)
        {
            _faker.RuleFor(x => x.ActualBalance, f => actualBalance);
            return this;
        }

        public UpdateAccountDtoFactory WithInitialBalance(decimal initialBalance)
        {
            _faker.RuleFor(x => x.InitialBalance, f => initialBalance);
            return this;
        }

        public UpdateAccountDtoFactory WithAccountTypeId(int accountTypeId)
        {
            _faker.RuleFor(x => x.AccountTypeId, f => accountTypeId);
            return this;
        }

        public UpdateAccountDto Generate()
        {
            return _faker.Generate();
        }

        public IEnumerable<UpdateAccountDto> Generate(int quantity)
        {
            return _faker.Generate(quantity);
        }
    }
}
