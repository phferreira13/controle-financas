namespace AccountService.Domain.DTOs.AccountTypes
{
    public class AddDefaultAccountTypeDto
    {
        public required string Name { get; set; }
        public bool IsDefault { get; private set; } = true;
    }
}
