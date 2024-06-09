using static Microsoft.AspNetCore.Http.StatusCodes;
using Application.Handlers.WeatherForecast.GetWeatherHandler;
using Application.Handlers.WeatherForecast.SaveWeatherHandler;
using Application.Domain;
using MediatR;

namespace API.Endpoints;

public static class WeatherForcastEndpoints
{
    public static IEndpointRouteBuilder MapWeatherForcastEndpoints (this IEndpointRouteBuilder app) =>

        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetWeatherCommand()))
                .WithDescription("Get weather forecasts sample endpoint")
                .Produces<IEnumerable<WeatherForecast>>(Status200OK)
                .Produces(Status404NotFound);

            group.MapGet("/{id}", (IMediator mediator, int id) => mediator.Send(new GetWeatherCommand(id)))
                .WithDescription("Get weather forecasts by Id")
                .Produces<WeatherForecast>(Status200OK)
                .Produces(Status404NotFound);

            group.MapPost("/", (IMediator mediator, SaveWeatherCommand request) => mediator.Send(request))
                .WithDescription("Save weather forecasts")
                .Produces<WeatherForecast>(Status201Created)
                .Produces(Status400BadRequest);
            
            group.MapPut("/{id}", (IMediator mediator, int id, SaveWeatherCommand request) => mediator.Send(request.WithId(id)))
                .WithDescription("Update weather forecasts")
                .Produces<WeatherForecast>(Status202Accepted)
                .Produces(Status400BadRequest)
                .Produces(Status404NotFound);
        });
}
