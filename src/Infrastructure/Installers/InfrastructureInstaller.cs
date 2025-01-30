using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Installers;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase();

        services            
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

        return services;
    }
}
