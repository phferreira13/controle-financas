using AccountService.Domain.DTOs.AccountTypes;

namespace AccountService.Tests.Shared.Factories.AccountTypes
{
    public class UpdateAccountTypeDtoFactory
    {
        private readonly Faker<UpdateAccountTypeDto> _faker;

        public UpdateAccountTypeDtoFactory()
        {
            _faker = new Faker<UpdateAccountTypeDto>("pt_BR")
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.Id, f => f.Random.Int(min: 1));
        }

        public UpdateAccountTypeDtoFactory WithName(string name)
        {
            _faker.RuleFor(x => x.Name, f => name);
            return this;
        }

        public UpdateAccountTypeDtoFactory WithId(int id)
        {
            _faker.RuleFor(x => x.Id, f => id);
            return this;
        }

        public UpdateAccountTypeDto Generate()
        {
            return _faker.Generate();
        }

        public IEnumerable<UpdateAccountTypeDto> Generate(int quantity)
        {
            return _faker.Generate(quantity);
        }
    }
}
