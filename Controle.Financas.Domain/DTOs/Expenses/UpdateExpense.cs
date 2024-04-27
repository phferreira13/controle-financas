using AccountService.Domain.Models;
using System;

namespace AccountService.Domain.DTOs.Expenses
{
    public class UpdateExpense(decimal value, bool isPaid, DateTime registerDate, string description, int accountId, int expenseTypeId, DateTime? paymentDate)
    {
        public decimal Value { get; private set; } = value;
        public bool IsPaid { get; private set; } = isPaid;
        public DateTime RegisterDate { get; private set; } = registerDate;
        public string Description { get; private set; } = description;
        public int AccountId { get; private set; } = accountId;
        public int ExpenseTypeId { get; private set; } = expenseTypeId;
        public DateTime? PaymentDate { get; private set; } = paymentDate;

        public Expense ApplyUpdate(Expense expense)
        {
            expense.Update(
                Value,
                IsPaid,
                RegisterDate,
                Description,
                AccountId,
                ExpenseTypeId,
                PaymentDate
            );
            return expense;
        }
    }
}

