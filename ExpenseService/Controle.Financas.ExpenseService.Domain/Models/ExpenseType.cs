using Controle.Financas.ExpenseService.Domain.Enums;
using Controle.Financas.ExpenseService.Domain.Models.Base;
namespace Controle.Financas.ExpenseService.Domain.Models
{
    public class ExpenseType : DbEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ExpenseType(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
            Status = EEntityStatus.Active;
        }

    }
}
