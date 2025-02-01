using Application.Handlers.WeatherForecast.Requests;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Handlers.WeatherForecast;

public class GetWeatherHandler(IWeatherForecastRepository repository, IMapper mapper) : IRequestHandler<GetWeatherRequest, IResult>
{        
    public async Task<IResult> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        if (request.Id is not null)
        {            
            var forecast = await repository.Get(request.Id!.Value);
            
            if (forecast == null)
                return NotFound();

            var response = mapper.Map<WeatherForecastModel>(forecast);
            
            return Ok(response);
        }
        else
        {        
            var forecasts = await repository.Get();

            if (forecasts == null)
                return Problem("Error to Get Forecasts");            

            if (!forecasts.Any())
                return NotFound();            
            
            var response = mapper.Map<IEnumerable<WeatherForecastModel>>(forecasts);

            return Ok(response);
        }
    }
}
