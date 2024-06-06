using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Application.Handlers.GetWeatherForecast.Installers;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class HandlersInstallerExtension
{
    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddGetWeatherForecastDependencies();
}