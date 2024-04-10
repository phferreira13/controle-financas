using AccountService.Domain.DTOs.ExpenseType;
using AccountService.Domain.Models;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IExpenseTypeRepository : IRepository<ExpenseType>
    {
        Task<ExpenseType> AddAsync(AddExpenseType addExpenseType);
        Task<ExpenseType> UpdateAsync(ExpenseType expenseType);
    }
}
