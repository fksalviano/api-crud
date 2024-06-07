using Application.Handlers.GetWeatherForecast.Domain;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.GetWeatherForecast.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{    
    private ILogger<WeatherForecastRepository> _logger;

    public WeatherForecastRepository(ILogger<WeatherForecastRepository> logger)
    {
        _logger = logger;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public async Task<IEnumerable<WeatherForecast>?> GetWeatherForecasts()
    {
        try
        {
            return await Task.Run(() => 
                Enumerable.Range(1, 5).Select(index => 
                    new WeatherForecast
                    {
                        Id = index,
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    })
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to Get Forecasts");
            return null;
        }
    }    
}
