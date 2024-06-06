
using Microsoft.AspNetCore.Http;
using Application.Handlers.GetWeatherForecast.Repositories;
using MediatR;

namespace Application.Handlers.GetWeatherForecast;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastCommand, IResult>
{
    private readonly IWeatherForecastRepository _repository;

    public GetWeatherForecastHandler(IWeatherForecastRepository repository) =>
        _repository = repository;

    public async Task<IResult> Handle(GetWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        var forecasts = await _repository.GetWeatherForecasts();

        if (forecasts == null)
        {
            return Results.Problem("Error to Get Forecasts");
        }

        if (!forecasts.Any())
        {
            return Results.NotFound();
        }
        
        return Results.Ok(forecasts);
    }
}
