using Controle.Financas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Business.AccountTypes
{
    public class AccountTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator AccountTypeResponse?(AccountType accountType)
        {
            if (accountType == null)
                return null;

            return new AccountTypeResponse
            {
                Id = accountType.Id,
                Name = accountType.Name
            };
        }
    }
}
