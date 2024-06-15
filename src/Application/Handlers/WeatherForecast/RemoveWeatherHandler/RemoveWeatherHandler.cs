using Microsoft.AspNetCore.Http;
using MediatR;
using Infra.Data.Repositories;

namespace Application.Handlers.WeatherForecast.RemoveWeatherHandler;

public class RemoveWeatherHandler(IWeatherForecastRepository repository) : IRequestHandler<RemoveWeatherCommand, IResult>
{
    public async Task<IResult> Handle(RemoveWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecastRemoved = await repository.Delete(request.Id);

        if (forecastRemoved == null)
        {
            return Results.Problem("Error to Remove Forecasts");
        }

        if (!forecastRemoved.Value)
        {
            return Results.Problem("Id not found to delete");
        }        

        return Results.NoContent();
    }
}
