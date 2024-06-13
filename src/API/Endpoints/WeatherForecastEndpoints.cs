using Microsoft.AspNetCore.Mvc;
using static System.Net.HttpStatusCode;
using Application.Handlers.WeatherForecast.GetWeatherHandler;
using Application.Handlers.WeatherForecast.SaveWeatherHandler;
using Application.Handlers.WeatherForecast.RemoveWeatherHandler;
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
                .ProducesResponse<IEnumerable<WeatherForecast>>(OK)
                .ProducesResponse(NotFound);

            group.MapGet("/{id}", (IMediator mediator, int id) => mediator.Send(new GetWeatherCommand(id)))
                .WithDescription("Get weather forecasts by Id")
                .ProducesResponse<WeatherForecast>(OK)
                .ProducesResponse(NotFound);

            group.MapPost("/", (IMediator mediator, SaveWeatherCommand request) => mediator.Send(request))
                .WithDescription("Save weather forecasts")
                .ProducesResponse<WeatherForecast>(Created)
                .ProducesResponse(BadRequest);

            group.MapPut("/{id}", (IMediator mediator, int id, SaveWeatherCommand request) => mediator.Send(request.WithId(id)))
                .WithDescription("Update weather forecasts")
                .ProducesResponse<WeatherForecast>(Accepted)
                .ProducesResponse(BadRequest)
                .ProducesResponse(NotFound);

            group.MapDelete("/{id}", (IMediator mediator, int id) => mediator.Send(new RemoveWeatherCommand(id)))
                .WithDescription("Delete weather forecasts")
                .ProducesResponse(NoContent)
                .ProducesResponse(NotFound);
        });
}
