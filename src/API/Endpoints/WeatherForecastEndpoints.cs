using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Application.Handlers.WeatherForecast.GetWeatherHandler;
using Application.Handlers.WeatherForecast.SaveWeatherHandler;
using Application.Domain;
using API.Filters;
using MediatR;

namespace API.Endpoints;

public static class WeatherForcastEndpoints
{
    public static IEndpointRouteBuilder MapWeatherForcastEndpoints (this IEndpointRouteBuilder app) =>

        app.MapGroup("WeatherForecast", "/api/weatherforecast", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetWeatherCommand()))
                .WithDescription("Get weather forecasts sample endpoint")
                .Produces<ResponseBase<IEnumerable<WeatherForecast>>>(Status200OK)
                .Produces<ResponseBase<object?>>(Status404NotFound);

            group.MapGet("/{id}", (IMediator mediator, int id) => mediator.Send(new GetWeatherCommand(id)))
                .WithDescription("Get weather forecasts by Id")
                .Produces<ResponseBase<WeatherForecast>>(Status200OK)
                .Produces<ResponseBase<object?>>(Status404NotFound);

            group.MapPost("/", (IMediator mediator, [FromBody] SaveWeatherCommand request) => mediator.Send(request))
                .WithDescription("Save weather forecasts")
                .Produces<ResponseBase<WeatherForecast>>(Status200OK)
                .Produces<ResponseBase<object?>>(Status400BadRequest);
            
            group.MapPut("/{id}", (IMediator mediator, [FromRoute] int id, [FromBody] SaveWeatherCommand request) => mediator.Send(request.SetId(id)))
                .WithDescription("Update weather forecasts")
                .Produces<ResponseBase<WeatherForecast>>(Status200OK)
                .Produces<ResponseBase<object?>>(Status400BadRequest);
        });
}
