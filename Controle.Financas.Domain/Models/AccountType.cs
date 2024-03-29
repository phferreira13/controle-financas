﻿using AccountService.Domain.DTOs.AccountTypes;
using AccountService.Domain.Models.Base;

namespace AccountService.Domain.Models
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

        public AccountType(AddAccountTypeDto addAccountTypeDTO) : base(addAccountTypeDTO.UserId)
        {
            Name = addAccountTypeDTO.Name;
        }

        public AccountType(AddDefaultAccountTypeDto addDefaultAccountTypeDTO)
        {
            Name = addDefaultAccountTypeDTO.Name;
            IsDefault = addDefaultAccountTypeDTO.IsDefault;
        }

        public void Update(UpdateAccountTypeDto updateAccountTypeDTO)
        {
            Name = updateAccountTypeDTO.Name;
            UpdateDate();
        }
    }
}
