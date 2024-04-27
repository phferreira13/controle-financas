using AccountService.Domain.Models;

namespace AccountService.Infrastructure.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Value)
                .IsRequired();

            builder.Property(e => e.IsPaid)
                .IsRequired();

            builder.Property(e => e.RegisterDate)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.HasOne(e => e.Account)
                .WithMany(a => a.Expenses)
                .HasForeignKey(e => e.AccountId);

            builder.HasOne(e => e.ExpenseType)
                .WithMany(et => et.Expenses)
                .HasForeignKey(e => e.ExpenseTypeId);
        }
    }
}
