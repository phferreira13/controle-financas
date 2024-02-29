using AccountService.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AccountService.EFConfiguration.Startups
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var repositoryTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>)) && !t.IsAbstract && !t.IsInterface);

            foreach (var type in repositoryTypes)
            {
                var interfaceType = type.GetInterfaces().First(i => i.Name == $"I{type.Name}");
                services.AddScoped(interfaceType, type);
            }
        }
    }
}
