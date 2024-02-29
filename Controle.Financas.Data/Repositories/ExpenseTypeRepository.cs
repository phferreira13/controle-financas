using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using AccountService.EFConfiguration.Contexts;

namespace AccountService.EFConfiguration.Repositories
{
    public class ExpenseTypeRepository(ControleFinancasContext context) : IExpenseTypeRepository
    {
        private readonly ControleFinancasContext _context = context;
        private readonly DbSet<ExpenseType> expenseTypes = context.ExpenseTypes;

        public async Task<IEnumerable<ExpenseType>> GetAllByFilter(IFilter<ExpenseType> filter)
        {
            var query = expenseTypes.AsQueryable();
            query = filter.Apply(query);
            return await query.ToListAsync();
        }

        public Task<ExpenseType?> GetOneByFilter(IFilter<ExpenseType> filter)
        {
            var query = expenseTypes.AsQueryable();
            query = filter.Apply(query);
            return query.FirstOrDefaultAsync();
        }
    }
}
