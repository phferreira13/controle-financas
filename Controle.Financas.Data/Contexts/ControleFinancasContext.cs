using AccountService.Domain.DTOs.AccountTypes;
using AccountService.Domain.Models;

namespace AccountService.EFConfiguration.Contexts
{
    public class ControleFinancasContext(DbContextOptions<ControleFinancasContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AccountType> AccountsTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleFinancasContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        //Load AccountTypes seed data
        public void LoadAccountTypes()
        {
            //check if not exists
            if (AccountsTypes.Any())
                return;

            AccountsTypes.Add(new AccountType(new AddDefaultAccountTypeDto { Name = "Conta Corrente" }));
            AccountsTypes.Add(new AccountType(new AddDefaultAccountTypeDto { Name = "Conta Poupança" }));
            AccountsTypes.Add(new AccountType(new AddDefaultAccountTypeDto { Name = "Conta Salário" }));

            SaveChanges();
        }

    }
}
