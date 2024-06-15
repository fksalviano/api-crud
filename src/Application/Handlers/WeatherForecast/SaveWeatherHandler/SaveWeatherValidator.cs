using Microsoft.AspNetCore.Http;
using FluentValidation;
using MediatR;
using Infra.Data.Repositories;
using Domain.Extensions;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherValidator<TRequest, TResponse>(IValidator<Domain.Model.WeatherForecast> validator) 
    : IPipelineBehavior<TRequest, TResponse>
        where TRequest : SaveWeatherCommand where TResponse : class, IResult
{    

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var forecast = request.ToForecast();        

        var validation = await validator.ValidateAsync(forecast, cancellationToken);
        if (!validation.IsValid)
        {            
            return (Results.BadRequest(validation.Errors.ToStrings()) as TResponse)!;
        }

        return await next();
    }
}
