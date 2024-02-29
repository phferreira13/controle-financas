using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;

namespace AccountService.Domain.Filters
{
    public class ExpenseTypeFilter(string? name, string? description, int? userId, int? id, List<EStatus>? status) : IFilter<ExpenseType>
    {
        public string? Name { get; set; } = name;
        public string? Description { get; set; } = description;
        public int? UserId { get; set; } = userId;
        public int? Id { get; set; } = id;
        public List<EStatus>? Status { get; set; } = status;

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
