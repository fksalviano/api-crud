using Microsoft.AspNetCore.Http;
using MediatR;
using Infra.Data.Repositories;

namespace Application.Handlers.WeatherForecast.GetWeatherHandler;

public class GetWeatherHandler(IWeatherForecastRepository repository) : IRequestHandler<GetWeatherCommand, IResult>
{        
    public async Task<IResult> Handle(GetWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecasts = await repository.Get();

        if (forecasts == null)
        {
            return Results.Problem("Error to Get Forecasts");
        }

        if (request.IsGetById)
        {
            forecasts = forecasts.Where(forecast => forecast.Id == request.Id.ToString());
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
