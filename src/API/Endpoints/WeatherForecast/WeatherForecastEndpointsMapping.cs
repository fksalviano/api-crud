using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;
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
                    .Produces<IEnumerable<WeatherForecast>>(Status200OK)
                    .Produces<NotFoundObjectResult>(Status404NotFound)
                    .Produces<BadRequestObjectResult>(Status400BadRequest);
        });
}
