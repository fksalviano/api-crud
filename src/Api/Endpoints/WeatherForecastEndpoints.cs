using static System.Net.HttpStatusCode;
using Application.Handlers.WeatherForecast.GetWeatherHandler;
using Application.Handlers.WeatherForecast.SaveWeatherHandler;
using Application.Handlers.WeatherForecast.RemoveWeatherHandler;
using MediatR;
using Domain.Models;
using Domain.Requests;
using Domain.Responses.WeatherForecast;

namespace Api.Endpoints;

public static class WeatherForcastEndpoints
{
    public static IEndpointRouteBuilder MapWeatherForcastEndpoints (this IEndpointRouteBuilder app) =>

        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetWeatherQuery()))
                .WithDisplayName("Get Forecasts").WithDescription("Get weather forecasts")
                .ProducesResponse<IEnumerable<WeatherForecastResponse>>(OK)
                .ProducesResponse(NotFound);

            group.MapGet("/{id}", (IMediator mediator, Guid id) => mediator.Send(new GetWeatherQuery(id)))
                .WithDisplayName("Get Forecast").WithDescription("Get weather forecasts by Id")
                .ProducesResponse<WeatherForecastResponse>(OK)
                .ProducesResponse(NotFound);

            group.MapPost("/", (IMediator mediator, SaveWeatherRequest request) => mediator.Send(new SaveWeatherCommand(request)))
                .WithDisplayName("Save Forecast").WithDescription("Save weather forecasts")
                .ProducesResponse<WeatherForecastResponse>(Created)
                .ProducesResponse(BadRequest);

            group.MapPut("/{id}", (IMediator mediator, Guid id, SaveWeatherRequest request) => mediator.Send(new SaveWeatherCommand(request, id)))
                .WithDisplayName("Update Forecast").WithDescription("Update weather forecast")
                .ProducesResponse<WeatherForecastResponse>(Accepted)
                .ProducesResponse(BadRequest)
                .ProducesResponse(NotFound);

            group.MapDelete("/{id}", (IMediator mediator, Guid id) => mediator.Send(new RemoveWeatherCommand(id)))
                .WithDisplayName("Delete Forecast").WithDescription("Delete weather forecast")
                .ProducesResponse(NoContent)
                .ProducesResponse(NotFound);
        });
}
