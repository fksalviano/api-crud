using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Domain;
using Application.UseCases.GetWeatherForecast.Extensions;

namespace Application.UseCases.GetWeather;

public class GetWeatherForecastUseCase : IGetWeatherForecastUseCase
{
    private IGetWeatherForecastOutputPort? _outputPort;

    public void SetOutputPort(IGetWeatherForecastOutputPort outputPort) =>
        _outputPort = outputPort;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task ExecuteAsync()
    {
        var weatherForecasts = await Task.Run(() => 
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
        );

        if (!weatherForecasts.Any())
        {
            _outputPort!.NotFound();
            return;
        }

        var output = weatherForecasts.ToOutput();
        _outputPort!.Ok(output);
    }
}
