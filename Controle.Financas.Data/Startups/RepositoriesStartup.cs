using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.EFConfiguration.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.EFConfiguration.Startups
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
