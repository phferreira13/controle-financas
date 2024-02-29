namespace AccountService.Domain.DTOs.AccountTypes
{
    public class UpdateAccountTypeDto(int id, string name) : UpdateDto
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}
