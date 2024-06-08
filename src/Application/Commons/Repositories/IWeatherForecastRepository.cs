using Application.Domain;

namespace Application.Commons.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>?> GetAll();
    Task<bool?> Create(WeatherForecast weatherforecast);
    Task<bool?> Update(WeatherForecast weatherforecast);
    public int NextId { get; }
}