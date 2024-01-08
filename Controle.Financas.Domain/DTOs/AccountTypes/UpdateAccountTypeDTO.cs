namespace Controle.Financas.Domain.DTOs.AccountTypes
{
    public class UpdateAccountTypeDto : UpdateDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
