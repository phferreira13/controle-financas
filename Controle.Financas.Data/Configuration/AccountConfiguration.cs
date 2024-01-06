namespace Controle.Financas.Data.Configuration
{
    public class AccountConfiguration : UserEntityBaseConfiguration<Account>
    {
        public new virtual void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);
            builder.ToTable("Accounts");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.InitialBalance)
                .IsRequired();

            builder.Property(x => x.AccountTypeId)
                .IsRequired();

            builder.HasOne(x => x.AccountType)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.AccountTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
