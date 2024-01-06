using Controle.Financas.Data.Configuration.Base;
using Controle.Financas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle.Financas.Data.Configuration
{
    public class AccountTypeConfiguration : UserEntityBaseConfiguration<AccountType>
    {
        public new virtual void Configure(EntityTypeBuilder<AccountType> builder)
        {
            base.Configure(builder);
            builder.ToTable("AccountsTypes");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.AccountType)
                .HasForeignKey(x => x.AccountTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
