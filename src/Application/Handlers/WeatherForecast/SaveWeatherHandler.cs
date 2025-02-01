using Application.Handlers.WeatherForecast.Requests;
using AutoMapper;
using Domain.Models;
using Domain.Extensions;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Handlers.WeatherForecast;

public class SaveWeatherHandler(IWeatherForecastRepository repository, IMapper mapper) : IRequestHandler<SaveWeatherRequest, IResult>
{
    public async Task<IResult> Handle(SaveWeatherRequest request, CancellationToken cancellationToken)
    {
        var forecast = mapper.Map<WeatherForecastEntity>(request);

        if (request.Id is null)
        {
            forecast.SetNewId();

            if (!forecast.IsValid(out var error))
            {
                return BadRequest(error);
            }

            var forecastSaved = await repository.Create(forecast);

            if (forecastSaved == null || !forecastSaved.Value)
                return Problem("Error to save Forecast");

            var response = mapper.Map<WeatherForecastModel>(forecast);

            return Created(forecast.Id, response);
        }
        else
        {
            if (!forecast.IsValid(out var error))
            {
                return BadRequest(error);
            }
            
            var forecastUpdated = await repository.Update(forecast);

            if (forecastUpdated == null)
                return Problem("Error to update Forecast");

            if (!forecastUpdated.Value)
                return NotFound("Id not found to update Forecast");

            var response = mapper.Map<WeatherForecastModel>(forecast);
            
            return Accepted(forecast.Id, response);
        }
    }
}
