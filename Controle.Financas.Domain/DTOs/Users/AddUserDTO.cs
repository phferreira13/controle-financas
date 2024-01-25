namespace AccountService.Domain.DTOs.Users
{
    public class AddUserDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
