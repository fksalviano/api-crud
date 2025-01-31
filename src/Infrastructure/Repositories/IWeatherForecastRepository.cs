using Domain.Models;

namespace Infrastructure.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecastModel>?> Get();
    Task<WeatherForecastModel?> Get(Guid id);
    Task<bool?> Create(WeatherForecastModel weatherforecast);
    Task<bool?> Update(WeatherForecastModel weatherforecast);
    Task<bool?> Delete(WeatherForecastModel weatherforecast);
}