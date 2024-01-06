namespace Controle.Financas.Domain.DTOs.Account
{
    public class AddAccountDTO
    {
        public required string Name { get; set; }
        public decimal InitialBalance { get; set; } = 0;
        public decimal ActualBalance { get; set; } = 0;
        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
    }
}
