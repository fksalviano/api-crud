
using Application.Commons.Repositories;
using MediatR;
using Application.Domain.Result;

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
            return Result.Problem("Error to Get Forecasts");
        }

        if (request.IsGetById)
        {
            forecasts = forecasts.Where(forecast => forecast.Id == request.Id);
        }

        if (!forecasts.Any())
        {
            return Result.NotFound();
        }

        if (request.IsGetById)
            return Result.Ok(forecasts.First());
        else        
            return Result.Ok(forecasts);
    }
}
