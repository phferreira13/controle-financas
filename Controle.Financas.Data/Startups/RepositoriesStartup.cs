using AccountService.Domain.Interfaces.Repositories;
using AccountService.EFConfiguration.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.EFConfiguration.Startups
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
