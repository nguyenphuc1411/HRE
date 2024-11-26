using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using HRE.Infrastructure.Repositories;
using HRE.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRE.Infrastructure.Extentions;

public static class ServiceCollectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MyDB");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IDataSeeder, DataSeeder>();

        services.AddScoped<IRobotRepository, RobotRepository>();
        services.AddScoped<IRMRepository, RMRepository>();
        services.AddScoped<IAreaRepository, AreaRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IGiftRepository, GiftRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<ICampaignRepository, CampaignRepository>();
    }
}
