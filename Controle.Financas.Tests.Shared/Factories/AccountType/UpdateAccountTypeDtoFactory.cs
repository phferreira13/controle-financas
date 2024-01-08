using Controle.Financas.Domain.DTOs.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Tests.Shared.Factories.AccountType
{
    public class UpdateAccountTypeDtoFactory
    {
        private readonly Faker<UpdateAccountTypeDTO> _faker;

        public UpdateAccountTypeDtoFactory()
        {
            _faker = new Faker<UpdateAccountTypeDTO>("pt_BR")
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

        public UpdateAccountTypeDTO Generate()
        {
            return _faker.Generate();
        }

        public IEnumerable<UpdateAccountTypeDTO> Generate(int quantity)
        {
            return _faker.Generate(quantity);
        }
    }
}
