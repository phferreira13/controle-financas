using AccountService.Domain.Interfaces.Filters;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetOneByFilter(IFilter<T> filter);
        public Task<List<T>> GetAllByFilter(IFilter<T> filter);
    }
}
