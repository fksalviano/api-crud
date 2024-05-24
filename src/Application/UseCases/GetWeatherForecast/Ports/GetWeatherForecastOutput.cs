using System.Collections;
using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeatherForecast.Ports;

public class GetWeatherForecastOutput : IEnumerable<WeatherForecast>
{

    private readonly IEnumerable<WeatherForecast> _weatherForecasts;

    public GetWeatherForecastOutput(IEnumerable<WeatherForecast> weatherForecasts) =>
        _weatherForecasts = weatherForecasts;

    public IEnumerator<WeatherForecast> GetEnumerator() =>
        _weatherForecasts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}