namespace Controle.Financas.Domain.DTOs.Account
{
    public class UpdateAccountDTO
    {
        public required string Name { get; set; }
        public decimal InitialBalance { get; set; } = 0;
        public decimal ActualBalance { get; set; } = 0;
        public int AccountTypeId { get; set; }
    }
}
