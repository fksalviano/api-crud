
using Application.Commons.Repositories;
using MediatR;
using Application.Domain.Result;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherHandler : IRequestHandler<SaveWeatherCommand, IResult>
{
    private readonly IWeatherForecastRepository _repository;

    public SaveWeatherHandler(IWeatherForecastRepository repository) =>
        _repository = repository;

    public async Task<IResult> Handle(SaveWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecast = request.ToForecast(_repository.NextId);

        var forecastSaved = request.IsUpdate()
            ? await _repository.Update(forecast)
            : await _repository.Create(forecast);

        if (forecastSaved == null)
        {
            return Result.Problem("Error to Save Forecasts");
        }

        return Result.Ok(forecast);
    }
}
