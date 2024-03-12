using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using AutoFilterQuery.Attributes;
using AutoFilterQuery.Enums;
using AutoFilterQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Domain.Filters.Accounts
{
    public class AccountFilter : FilterQuery<Account>, IFilter<Account>
    {
        [Filtered]
        public int? Id { get; set; }
        [Filtered(ECompareRule.Like)]
        public string? Name { get; set; }
        [Filtered]
        public decimal? InitialBalance { get; set; }
        [Filtered]
        public decimal? ActualBalance { get; set; }
        [Filtered]
        public int? AccountTypeId { get; set; }
        [Filtered]
        public int? UserId { get; set; }


        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public IQueryable<Account> Apply(IQueryable<Account> query)
        {
            query = ApplyAttributeFilters(query);
            if (Status != null && Status.Any())
                query = query.Where(a => Status.Contains(a.Status));
            if (IgnoreDeleted)
                query = query.Where(a => a.Status != EStatus.Deleted);

            return query;
        }
    }
}
