using Application.UseCases.GetWeatherForecast.Domain;

namespace Application.UseCases.GetWeather.Ports;

public record GetWeatherForecastOutput
(
    IEnumerable<WeatherForecast> WeatherForecasts
);
