using Microsoft.Extensions.Logging;
using System.Data;
using Domain.Models;
using Dapper;
using DapperExtensions;

namespace Infrastructure.Repositories;

public class WeatherForecastRepository(ILogger<WeatherForecastRepository> logger, IDbConnection connection) : IWeatherForecastRepository
{    
    public async Task<IEnumerable<WeatherForecast>?> Get()
    {
        try
        {
            return await connection.GetListAsync<WeatherForecast>();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Get Forecasts");
            return null;
        }
    }

    public async Task<WeatherForecast?> Get(Guid id)
    {
        try
        {
            return await connection.GetAsync<WeatherForecast>(id.ToString());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error to Get Forecast");
            return null;
        }
    }

    public async Task<bool?> Create(WeatherForecast weatherforecast)
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

    public async Task<bool?> Update(WeatherForecast weatherforecast)
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

    public async Task<bool?> Delete(WeatherForecast weatherforecast)
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
