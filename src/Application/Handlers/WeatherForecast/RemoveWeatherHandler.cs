using Application.Handlers.WeatherForecast.Requests;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Handlers.WeatherForecast;

public class RemoveWeatherHandler(IWeatherForecastRepository repository) : IRequestHandler<RemoveWeatherRequest, IResult>
{
    public async Task<IResult> Handle(RemoveWeatherRequest request, CancellationToken cancellationToken)
    {
        var forecast = await repository.Get(request.Id);

        if (forecast is null)
            return NotFound("Id Not Found");

        var forecastRemoved = await repository.Delete(forecast);

        if (forecastRemoved == null)
            return Problem("Error to Remove Forecasts");

        return NoContent();
    }
}
