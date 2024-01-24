using Controle.Financas.Domain.Enums;

namespace Controle.Financas.Domain.Models.Base
{
    public abstract class EntityBase
    {
        public int Id { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; private set; }
        public EStatus Status { get; private set; } = EStatus.Active;

        public void SetStatus(EStatus status)
        {
            Status = status;
            UpdateDate();
        }
        protected void UpdateDate() => UpdatedDate = DateTime.Now;
    }
}
