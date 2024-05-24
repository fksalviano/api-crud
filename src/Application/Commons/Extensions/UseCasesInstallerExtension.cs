using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.GetWeatherForecast;

namespace Application.Commons.Extensions;

[ExcludeFromCodeCoverage]
public static class UseCasesInstallerExtension
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddGetWeatherForecastUseCase();

        return services;
    }
}