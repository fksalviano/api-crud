using Domain.Models;
using DapperExtensions.Mapper;

namespace Infrastructure.Database.Mappers;

public class WeatherForecastMapper : ClassMapper<WeatherForecastModel>
{
    public WeatherForecastMapper()
    {
        Table("WeatherForecast");
        AutoMap();
    }
}
