using Microsoft.AspNetCore.Http;
using MediatR;
using Infra.Data.Repositories;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherHandler(IWeatherForecastRepository repository) : IRequestHandler<SaveWeatherCommand, IResult>
{    
    public async Task<IResult> Handle(SaveWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecast = request.ToForecast();

        var forecastSaved = request.IsUpdate()
            ? await repository.Update(forecast)
            : await repository.Create(forecast);

        if (forecastSaved == null)
        {
            return Results.Problem("Error to Save Forecasts");
        }

        if (request.IsUpdate() && !forecastSaved.Value)
        {
            return Results.Problem("Id not found to update");
        }     

        var id = forecast.Id.ToString();

        if (request.IsUpdate())        
            return Results.Accepted(id, forecast);
        else
            return Results.Created(id, forecast);
    }
}
