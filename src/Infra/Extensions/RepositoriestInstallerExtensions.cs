using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Infra.Data.Repositories;

namespace Infra.Extensions;

[ExcludeFromCodeCoverage]
public static class RepositoriesInstallerExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services            
            .AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
}
