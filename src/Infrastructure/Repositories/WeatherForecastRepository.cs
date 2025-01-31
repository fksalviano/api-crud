using Microsoft.Extensions.Logging;
using System.Data;
using Domain.Models;
using DapperExtensions;
using Infrastructure.Database.Mappers;

namespace Infrastructure.Repositories;

public class WeatherForecastRepository(ILogger<WeatherForecastRepository> logger, IDbConnection connection) : IWeatherForecastRepository
{    
    public async Task<IEnumerable<WeatherForecastModel>?> Get()
    {
        try
        {
            return await connection.GetListAsync<WeatherForecastModel>();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Get Forecasts");
            return null;
        }
    }

    public async Task<WeatherForecastModel?> Get(Guid id)
    {
        try
        {
            return await connection.GetAsync<WeatherForecastModel>(id.ToString());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Get Forecast");
            return null;
        }
    }

    public async Task<bool?> Create(WeatherForecastModel weatherforecast)
    {
        try
        {
            await connection.InsertAsync(weatherforecast);            
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Create Forecast");
            return null;
        }        
    }

    public async Task<bool?> Update(WeatherForecastModel weatherforecast)
    {
        try
        {
            return await connection.UpdateAsync(weatherforecast);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Update Forecast");
            return null;
        }
    }

    public async Task<bool?> Delete(WeatherForecastModel weatherforecast)
    {
        try
        {            
            return await connection.DeleteAsync(weatherforecast);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Delete Forecast");
            return null;
        }
    }
}
