namespace Controle.Financas.Domain.Models.Base
{
    public abstract class UserEntityBase(int userId) : EntityBase
    {
        public int UserId { get; private set; } = userId;
        public virtual User? User { get; set; }
    }
}
