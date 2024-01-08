using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Domain.DTOs.AccountTypes
{
    public class AddDefaultAccountTypeDTO
    {
        public required string Name { get; set; }
        public bool IsDefault { get; private set; } = true;
    }
}
