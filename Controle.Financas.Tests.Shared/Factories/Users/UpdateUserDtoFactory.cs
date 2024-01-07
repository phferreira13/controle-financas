namespace Controle.Financas.Tests.Shared.Factories.Users
{
    public class UpdateUserDtoFactory
    {
        private readonly Faker<UpdateUserDTO> _faker;

        public UpdateUserDtoFactory()
        {
            _faker = new Faker<UpdateUserDTO>("pt_BR")
                .RuleFor(x => x.FullName, f => f.Person.FullName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Password, f => f.Internet.Password());
        }

        public UpdateUserDtoFactory WithFullName(string fullName)
        {
            _faker.RuleFor(x => x.FullName, fullName);
            return this;
        }

        public UpdateUserDtoFactory WithEmail(string email)
        {
            _faker.RuleFor(x => x.Email, email);
            return this;
        }

        public UpdateUserDtoFactory WithPassword(string password)
        {
            _faker.RuleFor(x => x.Password, password);
            return this;
        }

        public UpdateUserDtoFactory WithId(int id)
        {
            _faker.RuleFor(x => x.Id, id);
            return this;
        }

        public UpdateUserDTO Build()
        {
            return _faker.Generate();
        }

        public IEnumerable<UpdateUserDTO> BuildList(int count)
        {
            return _faker.Generate(count);
        }
    }
}
