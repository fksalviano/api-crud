using API.Endpoints.WeatherForecast;

namespace API.Extensions;

public static class EndpointsInstallerExtension
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services
            .AddScoped<WeatherForecastEndpoints>();

        return services;
    }
}
