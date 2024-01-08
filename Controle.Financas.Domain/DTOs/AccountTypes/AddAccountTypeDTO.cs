namespace Controle.Financas.Domain.DTOs.AccountTypes
{
    public class AddAccountTypeDto
    {
        public required string Name { get; set; }
        public int UserId { get; set; }
    }
}
