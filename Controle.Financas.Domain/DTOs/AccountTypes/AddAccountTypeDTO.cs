namespace Controle.Financas.Domain.DTOs.AccountTypes
{
    public class AddAccountTypeDTO
    {
        public required string Name { get; set; }
        public int UserId { get; set; }
    }
}
