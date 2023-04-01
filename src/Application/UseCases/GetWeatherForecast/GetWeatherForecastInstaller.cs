using System.Diagnostics.CodeAnalysis;
using Application.Commons.Abstractions;
using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.GetWeather;

[ExcludeFromCodeCoverage]
public class GetWeatherForecastInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services) =>
        services
            .AddScoped<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>()
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
}
