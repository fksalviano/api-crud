using static Microsoft.AspNetCore.Http.StatusCodes;
using Application.Handlers.GetWeatherForecast;
using Application.Handlers.GetWeatherForecast.Domain;
using MediatR;
using API.Filters;

public static class WeatherForcastEndpoints
{
    public static IEndpointRouteBuilder MapWeatherForcastEndpoints (this IEndpointRouteBuilder app) =>

        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetWeatherForecastCommand()))
                .WithDescription("Get weather forecasts sample endpoint")
                .Produces<ResponseBase<IEnumerable<WeatherForecast>>>(Status200OK)
                .Produces<ResponseBase<object?>>(Status404NotFound);

            group.MapGet("/{id}", (IMediator mediator, int id) => mediator.Send(new GetWeatherForecastCommand(id)))
                .WithDescription("Get weather forecasts by Id")
                .Produces<ResponseBase<WeatherForecast>>(Status200OK)
                .Produces<ResponseBase<object?>>(Status404NotFound);
        });
}
