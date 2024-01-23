using Controle.Financas.Infra.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Controle.Financas.EFConfiguration.Startups
{
    public static class EntityFrameworkStartup
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ControleFinancasContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddRepositories();
        }
    }
}
