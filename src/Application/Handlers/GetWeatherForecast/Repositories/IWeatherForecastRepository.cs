using Application.Handlers.GetWeatherForecast.Domain;

namespace Application.Handlers.GetWeatherForecast.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>?> GetWeatherForecasts();
}