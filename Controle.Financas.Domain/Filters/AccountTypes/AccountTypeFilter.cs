using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using AutoFilterQuery.Attributes;
using AutoFilterQuery.Enums;
using AutoFilterQuery.Models;

namespace AccountService.Domain.Filters.AccountTypes
{
    public class AccountTypeFilter : FilterQuery<AccountType>, IFilter<AccountType>
    {
        [Filtered(ECompareRule.Like)]
        public string? Name { get; set; }

        [Filtered]
        public bool? IsDefault { get; set; }

        [Filtered]
        public int? Id { get; set; }

        [Filtered]
        public int? UserId { get; set; }


        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public IQueryable<AccountType> Apply(IQueryable<AccountType> query)
        {
            query = ApplyAttributeFilters(query);
            if (IgnoreDeleted)
                query = query.Where(at => at.Status != EStatus.Deleted);
            if (Status != null && Status.Any())
                query = query.Where(at => Status.Contains(at.Status));

            return query;
        }
    }
}
