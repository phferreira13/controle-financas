using AccountService.Domain.Interfaces.Filters;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using AccountService.EFConfiguration.Contexts;

namespace AccountService.EFConfiguration.Repositories
{
    public class ExpenseTypeRepository(ControleFinancasContext context) 
        : BaseRepository<ExpenseType>(context.ExpenseTypes), IExpenseTypeRepository
    {
        private readonly ControleFinancasContext _context = context;
        private readonly DbSet<ExpenseType> expenseTypes = context.ExpenseTypes;
    }
}
