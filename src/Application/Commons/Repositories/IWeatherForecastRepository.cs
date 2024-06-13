using Application.Domain;

namespace Application.Commons.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>?> GetAll();
    Task<bool?> Create(WeatherForecast weatherforecast);
    Task<bool?> Update(WeatherForecast weatherforecast);
    Task<bool?> Delete(int id);
    
    public int NextId { get; }
}