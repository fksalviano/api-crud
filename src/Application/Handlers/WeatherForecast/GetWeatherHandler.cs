using AutoMapper;
using Domain.Responses.WeatherForecast;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Handlers.WeatherForecast.GetWeatherHandler;

public class GetWeatherHandler(IWeatherForecastRepository repository, IMapper mapper) : IRequestHandler<GetWeatherQuery, IResult>
{        
    public async Task<IResult> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
    {
        if (request.Id is not null)
        {            
            var forecast = await repository.Get(request.Id!.Value);
            
            if (forecast == null)
                return NotFound();

            var response = mapper.Map<WeatherForecastResponse>(forecast);
            return Ok(response);
        }
        else
        {        
            var forecasts = await repository.Get();

            if (forecasts == null)
                return Problem("Error to Get Forecasts");            

            if (!forecasts.Any())
                return NotFound();            
            
            var response = mapper.Map<IEnumerable<WeatherForecastResponse>>(forecasts);
            return Ok(response);
        }
    }
}
