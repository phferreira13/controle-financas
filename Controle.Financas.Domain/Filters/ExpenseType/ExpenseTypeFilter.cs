using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using AutoFilterQuery.Attributes;
using AutoFilterQuery.Enums;
using AutoFilterQuery.Models;

namespace AccountService.Domain.Filters
{
    public class ExpenseTypeFilter : FilterQuery<ExpenseType>, IFilter<ExpenseType>
    {
        [Filtered(ECompareRule.Like)]
        public string? Name { get; set; }
        [Filtered(ECompareRule.Like)]
        public string? Description { get; set; }
        [Filtered]
        public int? UserId { get; set; }
        [Filtered]
        public int? Id { get; set; }


        public List<EStatus>? Status { get; set; }

        public IQueryable<ExpenseType> Apply(IQueryable<ExpenseType> query)
        {
            query = ApplyAttributeFilters(query);
            if (Status != null && Status.Count != 0)
                query = query.Where(x => Status.Contains(x.Status));

            return query;
        }
    }
}
