using Controle.Financas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Infra.Contexts
{
    public class ControleFinancasContext(DbContextOptions<ControleFinancasContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AccountType> AccountsTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControleFinancasContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
