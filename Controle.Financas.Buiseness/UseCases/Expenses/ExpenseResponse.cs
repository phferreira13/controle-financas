using AccountService.Domain.Enums;
using AccountService.Domain.Models;
using System;

namespace AccountService.Business.UseCases.Expenses
{
    public class ExpenseResponse(int id, decimal value, bool isPaid, DateTime registerDate, DateTime? paymentDate, string description, int accountId, int expenseTypeId, int userId)
    {
        public int Id { get; private set; } = id;
        public decimal Value { get; private set; } = value;
        public bool IsPaid { get; private set; } = isPaid;
        public DateTime RegisterDate { get; private set; } = registerDate;
        public DateTime? PaymentDate { get; private set; } = paymentDate;
        public string Description { get; private set; } = description;
        public int AccountId { get; private set; } = accountId;
        public int ExpenseTypeId { get; private set; } = expenseTypeId;
        public int UserId { get; private set; } = userId;

        public static implicit operator ExpenseResponse(Expense expense)
        {
            if (expense is null) return null;
            return new ExpenseResponse(expense.Id, expense.Value, expense.IsPaid, expense.RegisterDate, expense.PaymentDate, expense.Description, expense.AccountId, expense.ExpenseTypeId, expense.UserId ?? 0);
        }
    }
}
