using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeatherForecast.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
    {
        return await Task.Run(() => 
            Enumerable.Range(1, 5).Select(index => 
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
        );
    }    
}
