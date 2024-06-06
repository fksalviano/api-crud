using Microsoft.AspNetCore.Mvc;
using API.Base;
using API.Endpoints.WeatherForecast;
using Application.Handlers.GetWeatherForecast.Domain;

public static class WeatherForcastEndpointsMapping
{
    public static IEndpointRouteBuilder MapWeatherForcastEndpoints (this IEndpointRouteBuilder app) =>    

        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", ([FromServices] WeatherForecastEndpoints endpoint) => endpoint
                .GetWeatherForecast())
                    .WithDescription("Get weather forecasts sample endpoint")
                    .Produces<ResponseBase<IEnumerable<WeatherForecast>>>(StatusCodes.Status200OK)
                    .Produces<ResponseBase<object>>(StatusCodes.Status404NotFound);            
        });
}
