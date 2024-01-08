using Controle.Financas.Domain.DTOs.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Tests.Shared.Factories.AccountType
{
    public class AddAccountTypeDtoFactory
    {
        private readonly Faker<AddAccountTypeDTO> _faker;

        public AddAccountTypeDtoFactory()
        {
            _faker = new Faker<AddAccountTypeDTO>("pt_BR")
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

        public AddAccountTypeDTO Generate()
        {
            return _faker.Generate();
        }

        public IEnumerable<AddAccountTypeDTO> Generate(int quantity)
        {
            return _faker.Generate(quantity);
        }
    }
}
