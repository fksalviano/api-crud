using Application.UseCases.GetWeather.Ports;
using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeatherForecast.Extensions;

public static class GetWeatherForecastExtensions
{
    public static GetWeatherForecastOutput ToOutput(this IEnumerable<WeatherForecast> weatherForecasts) =>
        new GetWeatherForecastOutput(weatherForecasts);
}