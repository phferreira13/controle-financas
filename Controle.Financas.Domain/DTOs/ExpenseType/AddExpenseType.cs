namespace AccountService.Domain.DTOs.ExpenseType
{
    public class AddExpenseType(string name, string description, int userId)
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public int UserId { get; set; } = userId;
    }
}
