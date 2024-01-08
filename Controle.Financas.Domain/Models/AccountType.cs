﻿using Controle.Financas.Domain.DTOs.AccountTypes;
using Controle.Financas.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle.Financas.Domain.Models
{
    public class AccountType : UserEntityBase
    {
        public string Name { get; private set; }
        public bool IsDefault { get; private set; } = false;
        public virtual ICollection<Account> Accounts { get; private set; } = new List<Account>();

        private AccountType(string name, bool isDefault)
        {
            Name = name;
            IsDefault = isDefault;
        }

        public AccountType(AddAccountTypeDTO addAccountTypeDTO) : base(addAccountTypeDTO.UserId)
        {
            Name = addAccountTypeDTO.Name;
        }

        public AccountType(AddDefaultAccountTypeDTO addDefaultAccountTypeDTO)
        {
            Name = addDefaultAccountTypeDTO.Name;
            IsDefault = addDefaultAccountTypeDTO.IsDefault;
        }

        public void Update(UpdateAccountTypeDTO updateAccountTypeDTO)
        {
            Name = updateAccountTypeDTO.Name;
            UpdateDate();
        }
    }
}
