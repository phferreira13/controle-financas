using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.EFConfiguration.Repositories
{
    public abstract class BaseRepository<T>(DbSet<T> dbSet) : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = dbSet;

        public Task<List<T>> GetAllByFilterAsync(IFilter<T> filter)
        {
            var query = _dbSet.AsQueryable();
            query = filter.Apply(query);
            return query.ToListAsync();
        }

        public Task<T?> GetOneByFilterAsync(IFilter<T> filter)
        {
            var query = _dbSet.AsQueryable();
            query = filter.Apply(query);
            return query.FirstOrDefaultAsync();
        }
    }
}
