using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Application.Commons.Repositories;

namespace Application.Commons.Repositories.Extensions;

[ExcludeFromCodeCoverage]
public static class RepositoriesInstallerExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services            
            .AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();
}
