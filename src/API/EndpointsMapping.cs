using Microsoft.AspNetCore.Mvc;
using API.Base;
using API.Endpoints.GetWeatherForecast;

public static class EndpointsMapping
{
    public static void MapEndpoints (this IEndpointRouteBuilder app)
    {
        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", ([FromServices] GetWeatherForecastEndpoint endpoint) => endpoint.GetWeatherForecast())
                .WithDescription("Get weather forecasts sample endpoint")
                .Produces<GetWeatherForecastResponse>(StatusCodes.Status200OK)
                .Produces<ResponseBase<object>>(StatusCodes.Status404NotFound);            
        });
    }    
}
