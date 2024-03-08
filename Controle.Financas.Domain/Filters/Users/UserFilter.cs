using AccountService.Domain.Enums;
using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Domain.Filters.Users
{
    public class UserFilter : IFilter<User>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Id { get; set; }
        public IEnumerable<EStatus>? Status { get; set; }
        public bool IgnoreDeleted { get; set; } = true;

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            if (Id.HasValue)
                query = query.Where(u => u.Id == Id);
            if (!string.IsNullOrEmpty(FullName))
                query = query.Where(u => u.FullName.Contains(FullName));
            if (!string.IsNullOrEmpty(Email))
                query = query.Where(u => u.Email.Contains(Email));
            if (!string.IsNullOrEmpty(Password))
                query = query.Where(u => u.Password.Contains(Password));
            if (Status != null && Status.Any())
                query = query.Where(u => Status.Contains(u.Status));
            if (IgnoreDeleted)
                query = query.Where(u => u.Status != EStatus.Deleted);

            return query;
        }
    }
}
