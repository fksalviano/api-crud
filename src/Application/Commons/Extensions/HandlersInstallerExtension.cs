using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Application.Commons.Repositories.Installers;
using Application.Handlers.WeatherForecast.SaveWeatherHandler;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class HandlersInstallerExtension
{
    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddRepositories();

    public static MediatRServiceConfiguration AddOpenBehaviors(this MediatRServiceConfiguration configuration)
    {
        return configuration
            .AddOpenBehavior(typeof(SaveWeatherValidator<,>));        
    }        

}
