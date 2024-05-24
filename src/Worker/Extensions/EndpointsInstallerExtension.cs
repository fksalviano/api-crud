using Worker.Endpoints.GetWeatherForecast;

namespace Worker.Extensions;

public static class EndpointsInstallerExtension
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services
            .AddScoped<GetWeatherForecastEndpoint>();

        return services;
    }
}
