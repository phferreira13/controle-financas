using Controle.Financas.Domain.DTOs.AccountTypes;

namespace Controle.Financas.Infra.Configuration
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

            builder.Property(x => x.IsDefault)
                .HasDefaultValue(false)
                .IsRequired();


            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.AccountType)
                .HasForeignKey(x => x.AccountTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new AccountType(new AddDefaultAccountTypeDto { Name = "Conta Corrente" }),
                new AccountType(new AddDefaultAccountTypeDto { Name = "Conta Poupança" }),
                new AccountType(new AddDefaultAccountTypeDto { Name = "Conta Salário" }));

        }
    }
}
