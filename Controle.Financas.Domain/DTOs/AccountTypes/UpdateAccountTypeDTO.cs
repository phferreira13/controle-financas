namespace Controle.Financas.Domain.DTOs.AccountTypes
{
    public class UpdateAccountTypeDTO : UpdateDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
