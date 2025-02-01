using Microsoft.Extensions.Logging;
using System.Data;
using Domain.Entities;
using Dapper;
using DapperExtensions;
using Infrastructure.Database.Mappers;

namespace Infrastructure.Repositories;

public class WeatherForecastRepository(ILogger<WeatherForecastRepository> logger, IDbConnection connection) : IWeatherForecastRepository
{    
    public async Task<IEnumerable<WeatherForecastEntity>?> Get()
    {
        try
        {
            // TODO: Checar como usar  Dapper.Extensions propriedades readonly, usando o constructor para mapear
            // return await connection.GetListAsync<WeatherForecastEntity>();
            
            return await connection.QueryAsync<WeatherForecastEntity>("select * from WeatherForecast");
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
            // TODO: Checar como usar  Dapper.Extensions propriedades readonly, usando o constructor para mapear
            //return await connection.GetAsync<WeatherForecastEntity>(id.ToString());

            return await connection.QueryFirstOrDefaultAsync<WeatherForecastEntity>($"select * from WeatherForecast where Id = @id", new { id = id.ToString() });
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
