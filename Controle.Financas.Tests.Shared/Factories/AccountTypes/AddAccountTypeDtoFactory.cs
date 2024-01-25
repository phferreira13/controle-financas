using AccountService.Domain.DTOs.AccountTypes;

namespace AccountService.Tests.Shared.Factories.AccountTypes
{
    public class AddAccountTypeDtoFactory
    {
        private readonly Faker<AddAccountTypeDto> _faker;

        public AddAccountTypeDtoFactory()
        {
            _faker = new Faker<AddAccountTypeDto>("pt_BR")
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.UserId, f => f.Random.Int(min: 1));
        }

        public AddAccountTypeDtoFactory WithName(string name)
        {
            _faker.RuleFor(x => x.Name, f => name);
            return this;
        }

        public AddAccountTypeDtoFactory WithUserId(int userId)
        {
            _faker.RuleFor(x => x.UserId, f => userId);
            return this;
        }

        public AddAccountTypeDto Generate()
        {
            return _faker.Generate();
        }

        public IEnumerable<AddAccountTypeDto> Generate(int quantity)
        {
            return _faker.Generate(quantity);
        }
    }
}
