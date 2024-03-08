using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Domain.Filters.AccountTypes
{
    public class AccountTypeFilter : IFilter<AccountType>
    {
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public IQueryable<AccountType> Apply(IQueryable<AccountType> query)
        {
            if (Id.HasValue)
                query = query.Where(at => at.Id == Id);
            if (UserId.HasValue)
                query = query.Where(at => at.UserId == UserId);
            if (!string.IsNullOrEmpty(Name))
                query = query.Where(at => at.Name.Contains(Name));
            if (IsDefault.HasValue)
                query = query.Where(at => at.IsDefault == IsDefault);
            if (Status != null && Status.Any())
                query = query.Where(at => Status.Contains(at.Status));
            if (IgnoreDeleted)
                query = query.Where(at => at.Status != EStatus.Deleted);

            return query;
        }
    }
}
