using Controle.Financas.Domain.Enums;
using Controle.Financas.Domain.Extensions;
using Controle.Financas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Buiseness.UseCases.Users
{
    public class UserResponse
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public EStatus Status { get; set; }
        public string StatusDescription { get => Status.GetDescription(); }

        public static implicit operator UserResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Status = user.Status
            };
        }
    }
}
