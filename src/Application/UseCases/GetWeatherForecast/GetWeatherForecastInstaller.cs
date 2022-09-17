using Application.Commons.Abstractions;
using Application.UseCases.GetWeatherForecast.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.GetWeather;

public class GetWeatherForecastInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services) =>
        services
            .AddSingleton<IGetWeatherForecastUseCase, GetWeatherForecastUseCase>();
}
