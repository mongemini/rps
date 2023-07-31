using Microsoft.Extensions.DependencyInjection;
using RPS.Contracts.Repositories;
using RPS.Infrastructure.Repositories;

namespace RPS.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IGamesRepository, GamesRepository>();
        }
    }
}