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

namespace AccountService.Domain.Filters.Users
{
    public class UserFilter : FilterQuery<User>, IFilter<User>
    {
        [Filtered(ECompareRule.Like)]
        public string? FullName { get; set; }
        [Filtered(ECompareRule.Like)]
        public string? Email { get; set; }
        [Filtered(ignoreCase: false)]
        public string? Password { get; set; }
        [Filtered]
        public int? Id { get; set; }


        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            query = ApplyAttributeFilters(query);
            if (Status != null && Status.Any())
                query = query.Where(u => Status.Contains(u.Status));
            if (IgnoreDeleted)
                query = query.Where(u => u.Status != EStatus.Deleted);

            return query;
        }
    }
}
