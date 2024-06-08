using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Application.Commons.Repositories;

namespace Application.Commons.Repositories.Installers;

[ExcludeFromCodeCoverage]
public static class RepositoriesForecastInstaller
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services            
            .AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();
}
