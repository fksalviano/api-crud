using Microsoft.AspNetCore.Http;
using FluentValidation;
using MediatR;
using Application.Commons.Repositories;
using Application.Commons.Extensions;

namespace Application.Handlers.WeatherForecast.RemoveWeatherHandler;

public class RemoveWeatherValidator<TRequest, TResponse>(IWeatherForecastRepository repository) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : RemoveWeatherCommand 
        where TResponse : class, IResult
{    

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {       

        var existsId = (await repository.GetAll())!.Any(forecast => forecast.Id == request.Id);
        if (!existsId)
        {
            return (Results.NotFound("Id not found to update") as TResponse)!;
        }
    
        return await next();
    }
}
