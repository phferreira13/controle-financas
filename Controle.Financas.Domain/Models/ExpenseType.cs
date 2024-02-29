using AccountService.Domain.DTOs.ExpenseType;
using AccountService.Domain.Models.Base;
namespace AccountService.Domain.Models
{
    public class ExpenseType : UserEntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ExpenseType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public ExpenseType(AddExpenseType addExpenseType) : base(addExpenseType.UserId)
        {
            Name = addExpenseType.Name;
            Description = addExpenseType.Description;
        }
    }
}
