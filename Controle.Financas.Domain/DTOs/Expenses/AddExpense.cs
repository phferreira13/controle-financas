using AccountService.Domain.Models;
using System;

namespace AccountService.Domain.DTOs.Expenses
{
    public class AddExpense(decimal value, bool isPaid, DateTime registerDate, DateTime? paymentDate, string description, int accountId, int expenseTypeId, int userId)
    {
        public decimal Value { get; private set; } = value;
        public bool IsPaid { get; private set; } = isPaid;
        public DateTime RegisterDate { get; private set; } = registerDate;
        public DateTime? PaymentDate { get; private set; } = paymentDate;
        public string Description { get; private set; } = description;
        public int AccountId { get; private set; } = accountId;
        public int ExpenseTypeId { get; private set; } = expenseTypeId;
        public int UserId { get; private set; } = userId;

        public static Expense ToExpense(AddExpense addExpense)
        {
            return new Expense(
                addExpense.UserId,
                addExpense.Value,
                addExpense.IsPaid,
                addExpense.RegisterDate,
                addExpense.Description,
                addExpense.AccountId,
                addExpense.ExpenseTypeId,
                addExpense.PaymentDate
            );
        }
    }
}
