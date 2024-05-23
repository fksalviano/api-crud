using Application.Commons.Domain;
using Microsoft.AspNetCore.Mvc;
using Worker.Endpoints.GetWeatherForecast;
using Worker.Extensions;

public static class EndpointsMapping
{
    public static void MapEndpoints (this IEndpointRouteBuilder app)
    {
        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", ([FromServices] GetWeatherForecastEndpoint endpoint) => endpoint.GetWeatherForecast())
                .WithDescription("Get weather forecasts sample endpoint")
                .Produces<GetWeatherForecastResponse>(StatusCodes.Status200OK)
                .Produces<Response<object>>(StatusCodes.Status404NotFound);            
        });
    }    
}
