using HRE.Infrastructure.Seeders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRE.Infrastructure.Extentions;

internal static class ServiceCollectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddScoped<IDataSeeder, DataSeeder>();
    }
}
