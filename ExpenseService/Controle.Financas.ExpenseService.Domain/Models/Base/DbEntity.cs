using Controle.Financas.ExpenseService.Domain.Enums;

namespace Controle.Financas.ExpenseService.Domain.Models.Base
{
    public abstract class DbEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set;}
        public DateTime? DeletedAt { get; protected set; }
        public EEntityStatus Status { get; protected set; }

    }
}
