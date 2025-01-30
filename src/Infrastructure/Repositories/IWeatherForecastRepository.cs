using Domain.Models;

namespace Infrastructure.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>?> Get();
    Task<WeatherForecast?> Get(Guid id);
    Task<bool?> Create(WeatherForecast weatherforecast);
    Task<bool?> Update(WeatherForecast weatherforecast);
    Task<bool?> Delete(WeatherForecast weatherforecast);
}