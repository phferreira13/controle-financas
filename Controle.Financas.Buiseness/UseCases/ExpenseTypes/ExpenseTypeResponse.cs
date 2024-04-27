using AccountService.Domain.Enums;
using AccountService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Business.UseCases.ExpenseTypes
{
    public class ExpenseTypeResponse(int id, string name, string description, EStatus status)
    {
        public int Id { get; private set; } = id;
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public EStatus Status { get; private set; } = status;

        public static implicit operator ExpenseTypeResponse(ExpenseType expenseType)
        {
            if (expenseType is null) return null;
            return new ExpenseTypeResponse(expenseType.Id, expenseType.Name, expenseType.Description, expenseType.Status);
        }
    }
}
