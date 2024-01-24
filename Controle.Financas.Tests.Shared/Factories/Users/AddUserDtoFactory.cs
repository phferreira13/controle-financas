namespace Controle.Financas.Tests.Shared.Factories.Users
{
    public class AddUserDtoFactory
    {
        private readonly Faker<AddUserDto> _faker;

        public AddUserDtoFactory()
        {
            _faker = new Faker<AddUserDto>("pt_BR")
                .RuleFor(x => x.FullName, f => f.Person.FullName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Password, f => f.Internet.Password());
        }

        public AddUserDtoFactory WithFullName(string fullName)
        {
            _faker.RuleFor(x => x.FullName, fullName);
            return this;
        }

        public AddUserDtoFactory WithEmail(string email)
        {
            _faker.RuleFor(x => x.Email, email);
            return this;
        }

        public AddUserDtoFactory WithPassword(string password)
        {
            _faker.RuleFor(x => x.Password, password);
            return this;
        }

        public AddUserDto Build()
        {
            return _faker.Generate();
        }

        public IEnumerable<AddUserDto> BuildList(int count)
        {
            return _faker.Generate(count);
        }
    }
}
