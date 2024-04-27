using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using AutoFilterQuery.Attributes;
using AutoFilterQuery.Enums;
using AutoFilterQuery.Models;
using System.Collections.Generic;
using System.Linq;

namespace AccountService.Domain.Filters
{
    public class ExpenseFilter : FilterQuery<Expense>, IFilter<Expense>
    {
        [Filtered(ECompareRule.Equals)]
        public decimal? Value { get; set; }

        [Filtered(ECompareRule.Equals)]
        public bool? IsPaid { get; set; }

        [Filtered(ECompareRule.Equals)]
        public int? AccountId { get; set; }

        [Filtered(ECompareRule.Equals)]
        public int? ExpenseTypeId { get; set; }

        [Filtered(ECompareRule.Equals)]
        public int? UserId { get; set; }

        [Filtered(ECompareRule.Equals)]
        public int? Id { get; set; }

        public DateTime? StartDateRegistered { get; set; }
        public DateTime? EndDateRegistered { get; set; }
        public DateTime? StartDatePayment { get; set; }
        public DateTime? EndDatePayment { get; set; }
        public List<EStatus>? Status { get; set; }

        public IQueryable<Expense> Apply(IQueryable<Expense> query)
        {
            query = ApplyAttributeFilters(query);

            if (Status != null && Status.Count != 0)
                query = query.Where(x => Status.Contains(x.Status));

            if (StartDateRegistered is DateTime)
                query = query.Where(x => x.RegisterDate >= StartDateRegistered);

            if (EndDateRegistered is DateTime)
                query = query.Where(x => x.RegisterDate <= EndDateRegistered);

            if (StartDatePayment is DateTime)
                query = query.Where(x => x.PaymentDate >= StartDatePayment);

            if (EndDatePayment is DateTime)
                query = query.Where(x => x.PaymentDate <= EndDatePayment);

            return query;
        }
    }
}
