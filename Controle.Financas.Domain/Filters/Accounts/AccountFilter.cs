using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Domain.Filters.Accounts
{
    public class AccountFilter : IFilter<Account>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public decimal? InitialBalance { get; set; }
        public decimal? ActualBalance { get; set; }
        public int? AccountTypeId { get; set; }
        public int? UserId { get; set; }
        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public IQueryable<Account> Apply(IQueryable<Account> query)
        {
            if (Id.HasValue)
                query = query.Where(a => a.Id == Id);
            if (!string.IsNullOrEmpty(Name))
                query = query.Where(a => a.Name.Contains(Name));
            if (InitialBalance.HasValue)
                query = query.Where(a => a.InitialBalance == InitialBalance);
            if (ActualBalance.HasValue)
                query = query.Where(a => a.ActualBalance == ActualBalance);
            if (AccountTypeId.HasValue)
                query = query.Where(a => a.AccountTypeId == AccountTypeId);
            if (UserId.HasValue)
                query = query.Where(a => a.UserId == UserId);
            if (Status != null && Status.Any())
                query = query.Where(a => Status.Contains(a.Status));
            if (IgnoreDeleted)
                query = query.Where(a => a.Status != EStatus.Deleted);

            return query;
        }
    }
}
