using AccountService.EFConfiguration.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Tests.Repositories.Repositories.Base
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
