using AccountService.Domain.Interfaces.Filters;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetOneByFilterAsync(IFilter<T> filter);
        public Task<List<T>> GetAllByFilterAsync(IFilter<T> filter);
    }
}
