using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;

namespace AccountService.Domain.Filters
{
    public class ExpenseTypeFilter : IFilter<ExpenseType>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public List<EStatus>? Status { get; set; }

        public IQueryable<ExpenseType> Apply(IQueryable<ExpenseType> query)
        {
            if (!string.IsNullOrEmpty(Name))
                query = query.Where(x => x.Name.Contains(Name));
            if (!string.IsNullOrEmpty(Description))
                query = query.Where(x => x.Description.Contains(Description));
            if (UserId.HasValue)
                query = query.Where(x => x.UserId == UserId);
            if (Id.HasValue)
                query = query.Where(x => x.Id == Id);
            if (Status != null && Status.Any())
                query = query.Where(x => Status.Contains(x.Status));

            return query;
        }
    }
}
