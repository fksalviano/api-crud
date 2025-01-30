using AutoMapper;
using Domain.Responses.WeatherForecast;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherHandler(IWeatherForecastRepository repository, IMapper mapper) : IRequestHandler<SaveWeatherCommand, IResult>
{
    public async Task<IResult> Handle(SaveWeatherCommand request, CancellationToken cancellationToken)
    {
        var forecast = mapper.Map<Domain.Models.WeatherForecast>(request);

        if (request.Id is null)
        {
            forecast.SetNewId();
            var forecastSaved = await repository.Create(forecast);

            if (forecastSaved == null || !forecastSaved.Value)
                return Problem("Error to save Forecast");

            var response = mapper.Map<WeatherForecastResponse>(forecast);
            return Created(forecast.Id, response);
        }
        else
        {
            var forecastUpdated = await repository.Update(forecast);

            if (forecastUpdated == null)
                return Problem("Error to update Forecast");

            if (!forecastUpdated.Value)
                return NotFound("Id not found to update Forecast");

            var response = mapper.Map<WeatherForecastResponse>(forecast);
            return Accepted(forecast.Id, response);
        }
    }
}
