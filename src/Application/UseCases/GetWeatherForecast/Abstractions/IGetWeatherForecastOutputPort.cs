using Application.UseCases.GetWeather.Ports;
using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeatherForecast.Abstractions;

public interface IGetWeatherForecastOutputPort
{
    void Ok(GetWeatherForecastOutput output);
    
    void NotFound();
}
