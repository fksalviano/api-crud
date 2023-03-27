using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeatherForecast.Abstractions;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>?> GetWeatherForecasts();
}