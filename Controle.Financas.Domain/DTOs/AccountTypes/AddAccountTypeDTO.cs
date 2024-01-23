namespace Controle.Financas.Domain.DTOs.AccountTypes
{
    public class AddAccountTypeDto(string name, int userId)
    {
        public string Name { get; set; } = name;
        public int UserId { get; set; } = userId;
    }
}
