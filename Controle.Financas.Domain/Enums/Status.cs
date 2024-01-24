using System.ComponentModel;

namespace Controle.Financas.Domain.Enums
{
    public enum EStatus
    {
        [Description("Ativo")]
        Active = 1,
        [Description("Inativo")]
        Inactive = 2,
        [Description("Deletado")]
        Deleted = 3
    }
}
