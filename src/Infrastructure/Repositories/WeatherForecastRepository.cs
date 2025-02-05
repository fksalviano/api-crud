using Microsoft.Extensions.Logging;
using System.Data;
using Domain.Entities;
using DapperExtensions;

namespace Infrastructure.Repositories;

public class WeatherForecastRepository(ILogger<WeatherForecastRepository> logger, IDbConnection connection) : IWeatherForecastRepository
{    
    public async Task<IEnumerable<WeatherForecastEntity>?> Get()
    {
        try
        {
            return await connection.GetListAsync<WeatherForecastEntity>();                    
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Get Forecasts: {Message}", ex.Message);
            return null;
        }
    }

    public async Task<WeatherForecastEntity?> Get(Guid id)
    {
        try
        {            
            return await connection.GetAsync<WeatherForecastEntity>(id.ToString());            
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Get Forecast: {Message}", ex.Message);
            return null;
        }
    }

    public async Task<bool?> Create(WeatherForecastEntity weatherforecast)
    {
        try
        {
            await connection.InsertAsync(weatherforecast);            
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Create Forecast: {Message}", ex.Message);
            return null;
        }        
    }

    public async Task<bool?> Update(WeatherForecastEntity weatherforecast)
    {
        try
        {
            return await connection.UpdateAsync(weatherforecast);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Update Forecast: {Message}", ex.Message);
            return null;
        }
    }

    public async Task<bool?> Delete(WeatherForecastEntity weatherforecast)
    {
        try
        {            
            return await connection.DeleteAsync(weatherforecast);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Delete Forecast: {Message}", ex.Message);
            return null;
        }
    }
}
