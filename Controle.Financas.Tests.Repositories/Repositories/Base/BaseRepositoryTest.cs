using Controle.Financas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Tests.Repositories.Repositories.Base
{
    public abstract class BaseRepositoryTest
    {
        protected ControleFinancasContext _controleFinancasContext;
        
        public void ConfigureContext()
        {
            var options = new DbContextOptionsBuilder<ControleFinancasContext>()
                .UseInMemoryDatabase("DataSource=:memory:")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .Options;
            _controleFinancasContext = new ControleFinancasContext(options);
            _controleFinancasContext.Database.EnsureDeleted();
            _controleFinancasContext.Database.EnsureCreated();
        }
    }
}
