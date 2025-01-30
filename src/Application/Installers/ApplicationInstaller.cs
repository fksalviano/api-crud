using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Application.Mappers;
using Application.Handlers.WeatherForecast.SaveWeatherHandler;

namespace Application.Installers;

[ExcludeFromCodeCoverage]
public static class ApplicationInstaller
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatR(configuration => configuration
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                .AddOpenBehavior(typeof(RequestValidationBehavior<,>), ServiceLifetime.Scoped));

        services            
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies(), ServiceLifetime.Scoped);

        services
            .AddAutoMapper(
                typeof(ModelProfile));

        return services;    
    }

}
