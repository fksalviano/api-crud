using System.Diagnostics.CodeAnalysis;
using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.GetWeatherForecast;

[ExcludeFromCodeCoverage]
public static class GetWeatherForecastInstaller
{
    public static void AddGetWeatherForecastUseCase(this IServiceCollection services) =>
        services
            .AddScoped<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>()
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
}
