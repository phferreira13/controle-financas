using Controle.Financas.ExpenseService.Domain.Enums;
using Controle.Financas.ExpenseService.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.ExpenseService.Domain.Models
{
    public class Expense : DbEntity
    {
        public int AccountId { get; private set; }
        public int UserId { get; private set; }
        public int ExpenseTypeId { get; private set; }
        public string? Description { get; private set; }
        public decimal Value { get; private set; }
        public DateTime ExpenseDate { get; private set; }

        public ExpenseType? ExpenseType { get; private set; }

        public Expense(int accountId, int userId, int expenseTypeId, decimal value, DateTime expenseDate, string? description = null)
        {
            AccountId = accountId;
            UserId = userId;
            ExpenseTypeId = expenseTypeId;
            Description = description;
            Value = value;
            ExpenseDate = expenseDate;
            CreatedAt = DateTime.Now;
            Status = EEntityStatus.Active;
        }
    }
}
