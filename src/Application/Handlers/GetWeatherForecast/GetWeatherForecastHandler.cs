using Application.Commons.Domain.Result;
using Application.Handlers.GetWeatherForecast.Repositories;
using MediatR;

namespace Application.Handlers.GetWeatherForecast;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastCommand, Result>
{
    private readonly IWeatherForecastRepository _repository;

    public GetWeatherForecastHandler(IWeatherForecastRepository repository) =>
        _repository = repository;

    public async Task<Result> Handle(GetWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        var forecasts = await _repository.GetWeatherForecasts();

        if (forecasts == null)
        {
            return Result.Error("Error to Get Forecasts");
        }

        if (!forecasts.Any())
        {
            return Result.NotFound();
        }
        
        return Result.Ok(forecasts);
    }
}
