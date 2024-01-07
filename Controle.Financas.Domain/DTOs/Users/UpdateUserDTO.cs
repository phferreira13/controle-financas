﻿namespace Controle.Financas.Domain.DTOs.Users
{
    public class UpdateUserDTO : UpdateDTO
    {
        public required int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
