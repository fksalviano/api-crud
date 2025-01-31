using DapperExtensions.Mapper;
using Domain.Models;

namespace Infrastructure.Database.Mappers;

public class CustomPluralizedMapper<T> : PluralizedAutoClassMapper<T> where T : class 
{
    public override void Table(string tableName)
    {
        if(tableName.Equals(nameof(WeatherForecastModel)))
        {
            TableName = "WeatherForecast";
        }

        base.Table(tableName);
    }
}
