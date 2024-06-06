using System.Diagnostics.CodeAnalysis;
using Application.Handlers.GetWeatherForecast.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Handlers.GetWeatherForecast.Installers;

[ExcludeFromCodeCoverage]
public static class GetWeatherForecastInstaller
{
    public static IServiceCollection AddGetWeatherForecastDependencies(this IServiceCollection services) =>
        services            
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
}
