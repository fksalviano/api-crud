using Application.UseCases.GetWeatherForecast.Ports;
using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeatherForecast.Abstractions;

public interface IGetWeatherForecastOutputPort
{
    void Ok(GetWeatherForecastOutput output);    
    void NotFound();
    void Error(string message);
}
