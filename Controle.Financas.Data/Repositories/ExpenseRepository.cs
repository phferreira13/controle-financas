using AccountService.Domain.DTOs.Expenses;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.Domain.Models;
using AccountService.EFConfiguration.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AccountService.EFConfiguration.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private readonly ControleFinancasContext _context;
        private readonly DbSet<Expense> _expenses;

        public ExpenseRepository(ControleFinancasContext context) : base(context.Expenses)
        {
            _context = context;
            _expenses = context.Expenses;
        }

        public async Task<Expense> AddAsync(AddExpense addExpense)
        {
            var expense = AddExpense.ToExpense(addExpense);
            await _expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> DeleteAsync(int id)
        {
            var expense = await _expenses.FindAsync(id);
            if(expense is { })
            {
                _expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
            return expense;
        }

        public async Task<Expense> UpdateAsync(Expense expense)
        {
            _expenses.Update(expense);
            await _context.SaveChangesAsync();
            return expense;
        }
    }
}
