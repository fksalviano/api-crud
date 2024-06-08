using Application.Domain;
using Microsoft.Extensions.Logging;

namespace Application.Commons.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{    
    private ILogger<WeatherForecastRepository> _logger;

    private IEnumerable<WeatherForecast>? _forecasts = null;    

    public WeatherForecastRepository(ILogger<WeatherForecastRepository> logger)
    {
        _logger = logger;
    }

    public int NextId => (_forecasts?.Max(forecast => forecast.Id) + 1) ?? new Random().Next();

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public async Task<IEnumerable<WeatherForecast>?> GetAll()
    {        
        try
        {
            _forecasts = _forecasts ?? await Task.Run(() => 
                Enumerable.Range(1, 5).Select(index => 
                    new WeatherForecast
                    {
                        Id = index,
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    })
                );
            return _forecasts.OrderBy(forecast => forecast.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to Get Forecasts");
            return null;
        }
    }

    public async Task<bool?> Create(WeatherForecast weatherforecast)
    {        
        _forecasts = _forecasts!.Append(weatherforecast);

        return await Task.FromResult(true);
    }

    public async Task<bool?> Update(WeatherForecast weatherforecast)
    {
        //returns new list without the actual and adding the new object
        
        _forecasts = _forecasts!
            .Where(forecast => forecast.Id != weatherforecast.Id)
            .Append(weatherforecast);

        return await Task.FromResult(true);
    }
}
