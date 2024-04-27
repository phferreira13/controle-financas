using AccountService.Domain.DTOs.Expenses;
using AccountService.Domain.Models;

namespace AccountService.Domain.Interfaces.Repositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<Expense> AddAsync(AddExpense addExpense);
        Task<Expense> DeleteAsync(int id);
        Task<Expense> UpdateAsync(Expense expense);
    }
}
