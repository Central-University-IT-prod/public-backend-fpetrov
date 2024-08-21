using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnoTrip.Application.Common.Interfaces.Persistence;

namespace UnoTrip.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        //var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        var postgresPort = configuration["POSTGRES_PORT"];
        var postgresHost = configuration["POSTGRES_HOST"];
        var postgresUser = configuration["POSTGRES_USERNAME"];
        var postgresPassword = configuration["POSTGRES_PASSWORD"];
        var postgresDatabase = configuration["POSTGRES_DATABASE"];
        
        var connectionString = $"Host={postgresHost};Port={postgresPort};Database={postgresDatabase};Username={postgresUser};Password={postgresPassword};";

        services
            .AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITripRepository, TripRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        
        return services;
    }
}