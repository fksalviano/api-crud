using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecastEntity>?> Get();
    Task<WeatherForecastEntity?> Get(Guid id);
    Task<bool?> Create(WeatherForecastEntity weatherforecast);
    Task<bool?> Update(WeatherForecastEntity weatherforecast);
    Task<bool?> Delete(WeatherForecastEntity weatherforecast);
}