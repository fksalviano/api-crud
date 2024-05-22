using Application.Commons.Domain;
using Microsoft.AspNetCore.Mvc;
using Worker.Endpoints.GetWeatherForecast;

public static class EndpointsMapping
{
    public static void MapEndpoints (this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", ([FromServices] GetWeatherForecastEndpoint endpoint) => endpoint.GetWeatherForecast())
            .Produces<GetWeatherForecastResponse>(StatusCodes.Status200OK)
            .Produces<Response<object>>(StatusCodes.Status404NotFound)
            .WithDescription("Get weather forecasts sample endpoint")
            .WithOpenApi();
    }
}
