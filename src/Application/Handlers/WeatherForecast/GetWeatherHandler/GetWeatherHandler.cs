using Microsoft.AspNetCore.Http;
using Application.Commons.Repositories;
using MediatR;

namespace Application.Handlers.WeatherForecast.GetWeatherHandler;

public class GetWeatherHandler : IRequestHandler<GetWeatherCommand, IResult>
{
    private readonly IWeatherForecastRepository _repository;

    public GetWeatherHandler(IWeatherForecastRepository repository) =>
        _repository = repository;

    public async Task<IResult> Handle(GetWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecasts = await _repository.GetAll();

        if (forecasts == null)
        {
            return Results.Problem("Error to Get Forecasts");
        }

        if (request.IsGetById)
        {
            forecasts = forecasts.Where(forecast => forecast.Id == request.Id);
        }

        if (!forecasts.Any())
        {
            return Results.NotFound();
        }

        if (request.IsGetById)
            return Results.Ok(forecasts.First());
        else        
            return Results.Ok(forecasts);
    }
}
