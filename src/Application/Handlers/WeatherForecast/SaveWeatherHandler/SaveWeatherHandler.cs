using Microsoft.AspNetCore.Http;
using MediatR;
using Application.Commons.Repositories;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherHandler(IWeatherForecastRepository repository) : IRequestHandler<SaveWeatherCommand, IResult>
{    
    public async Task<IResult> Handle(SaveWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecast = request.ToForecast(repository.NextId);

        var forecastSaved = request.IsUpdate()
            ? await repository.Update(forecast)
            : await repository.Create(forecast);

        if (forecastSaved == null)
        {
            return Results.Problem("Error to Save Forecasts");
        }

        var id = forecast.Id.ToString();

        if (request.IsUpdate())        
            return Results.Accepted(id, forecast);
        else
            return Results.Created(id, forecast);
    }
}
