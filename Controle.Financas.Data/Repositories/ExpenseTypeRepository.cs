using AccountService.Domain.DTOs.ExpenseType;
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

        public async Task<ExpenseType> AddAsync(AddExpenseType addExpenseType)
        {
            var expenseType = new ExpenseType(addExpenseType);
            await expenseTypes.AddAsync(expenseType);
            await _context.SaveChangesAsync();
            return expenseType;
        }

        public async Task<ExpenseType> UpdateAsync(ExpenseType expenseType)
        {
            expenseTypes.Update(expenseType);
            await _context.SaveChangesAsync();
            return expenseType;
        }
    }
}
