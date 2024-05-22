using Application.Commons.Abstractions;
using Worker.Endpoints.GetWeatherForecast;

namespace Worker.Endpoints;

public class GetWeatherForecastInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services) => 
        services
            .AddScoped<GetWeatherForecastEndpoint>();    
}
