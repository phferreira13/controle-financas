using AccountService.Domain.Models.Base;
using System;

namespace AccountService.Domain.Models
{
    public class Expense : UserEntityBase
    {
        public decimal Value { get; private set; }
        public bool IsPaid { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public string Description { get; private set; }

        public int AccountId { get; private set; }
        public virtual Account Account { get; private set; }

        public int ExpenseTypeId { get; private set; }
        public virtual ExpenseType ExpenseType { get; private set; }

        private Expense(
            decimal value,
            bool isPaid,
            DateTime registerDate,
            string description,
            int accountId,
            int expenseTypeId,
            DateTime? paymentDate = null)
        {
            Value = value;
            IsPaid = isPaid;
            RegisterDate = registerDate;
            Description = description;
            AccountId = accountId;
            ExpenseTypeId = expenseTypeId;
            PaymentDate = paymentDate;
        }

        public Expense(
            int userId, 
            decimal value, 
            bool isPaid, 
            DateTime registerDate, 
            string description, 
            int accountId, 
            int expenseTypeId, 
            DateTime? paymentDate = null) 
            : base(userId)
        {
            Value = value;
            IsPaid = isPaid;
            RegisterDate = registerDate;
            Description = description;
            AccountId = accountId;
            ExpenseTypeId = expenseTypeId;
            PaymentDate = paymentDate;
        }

        public void Pay(DateTime paymentDate)
        {
            IsPaid = true;
            PaymentDate = paymentDate;
            UpdateDate();
        }

        public void Update(
            decimal value,
            bool isPaid,
            DateTime registerDate,
            string description,
            int accountId,
            int expenseTypeId,
            DateTime? paymentDate = null)
        {
            Value = value;
            IsPaid = isPaid;
            RegisterDate = registerDate;
            Description = description;
            AccountId = accountId;
            ExpenseTypeId = expenseTypeId;
            PaymentDate = paymentDate;
            UpdateDate();
        }

    }
}
