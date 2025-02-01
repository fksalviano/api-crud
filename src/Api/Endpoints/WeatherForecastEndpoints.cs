using Application.Handlers.WeatherForecast.Requests;
using MediatR;
using Domain.Models;
using static System.Net.HttpStatusCode;

namespace Api.Endpoints;

public static class WeatherForcastEndpoints
{
    public static IEndpointRouteBuilder MapWeatherForcastEndpoints (this IEndpointRouteBuilder app) =>

        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetWeatherRequest()))
                .WithDisplayName("Get Forecasts").WithDescription("Get weather forecasts")
                .ProducesResponse<IEnumerable<WeatherForecastModel>>(OK)
                .ProducesResponse(NotFound);

            group.MapGet("/{id}", (IMediator mediator, Guid id) => mediator.Send(new GetWeatherRequest(id)))
                .WithDisplayName("Get Forecast").WithDescription("Get weather forecasts by Id")
                .ProducesResponse<WeatherForecastModel>(OK)
                .ProducesResponse(NotFound);

            group.MapPost("/", (IMediator mediator, SaveWeatherRequest request) => mediator.Send(request))
                .WithDisplayName("Save Forecast").WithDescription("Save weather forecasts")
                .ProducesResponse<WeatherForecastModel>(Created)
                .ProducesResponse(BadRequest);

            group.MapPut("/{id}", (IMediator mediator, Guid id, SaveWeatherRequest request) => mediator.Send(request.SetId(id)))
                .WithDisplayName("Update Forecast").WithDescription("Update weather forecast")
                .ProducesResponse<WeatherForecastModel>(Accepted)
                .ProducesResponse(BadRequest)
                .ProducesResponse(NotFound);

            group.MapDelete("/{id}", (IMediator mediator, Guid id) => mediator.Send(new RemoveWeatherRequest(id)))
                .WithDisplayName("Delete Forecast").WithDescription("Delete weather forecast")
                .ProducesResponse(NoContent)
                .ProducesResponse(NotFound);
        });
}
