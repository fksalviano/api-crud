using API.Endpoints.GetWeatherForecast;

namespace API.Extensions;

public static class EndpointsInstallerExtension
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services
            .AddScoped<GetWeatherForecastEndpoint>();

        return services;
    }
}
