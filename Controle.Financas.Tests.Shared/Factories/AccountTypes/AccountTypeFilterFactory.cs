using AccountService.Domain.Enums;
using AccountService.Domain.Filters.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Tests.Shared.Factories.AccountTypes
{
    public class AccountTypeFilterFactory
    {
        private readonly Faker<AccountTypeFilter> _faker;

        public AccountTypeFilterFactory()
        {
            _faker = new Faker<AccountTypeFilter>("pt_BR")
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.IsDefault, f => f.Random.Bool())
                .RuleFor(x => x.Id, f => f.Random.Int(min: 1))
                .RuleFor(x => x.UserId, f => f.Random.Int(min: 1))
                .RuleFor(x => x.Status, f => new List<EStatus>() { f.Random.EnumValues<EStatus>().FirstOrDefault() })
                .RuleFor(x => x.IgnoreDeleted, f => f.Random.Bool());
        }

        public AccountTypeFilterFactory WithName(string name)
        {
            _faker.RuleFor(x => x.Name, f => name);
            return this;
        }

        public AccountTypeFilterFactory WithIsDefault(bool isDefault)
        {
            _faker.RuleFor(x => x.IsDefault, f => isDefault);
            return this;
        }

        public AccountTypeFilterFactory WithId(int id)
        {
            _faker.RuleFor(x => x.Id, f => id);
            return this;
        }

        public AccountTypeFilterFactory WithUserId(int userId)
        {
            _faker.RuleFor(x => x.UserId, f => userId);
            return this;
        }

        public AccountTypeFilterFactory WithStatus(EStatus status)
        {
            _faker.RuleFor(x => x.Status, f => new List<EStatus>() { status });
            return this;
        }

        public AccountTypeFilterFactory WithIgnoreDeleted(bool ignoreDeleted)
        {
            _faker.RuleFor(x => x.IgnoreDeleted, f => ignoreDeleted);
            return this;
        }

        public AccountTypeFilter Generate()
        {
            return _faker.Generate();
        }
    }
}
