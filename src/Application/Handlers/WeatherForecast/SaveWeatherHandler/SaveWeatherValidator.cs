using Microsoft.AspNetCore.Http;
using FluentValidation;
using MediatR;
using Application.Commons.Repositories;
using Application.Commons.Extensions;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherValidator<TRequest, TResponse>(IWeatherForecastRepository repository, IValidator<Domain.WeatherForecast> validator) 
    : IPipelineBehavior<TRequest, TResponse>
        where TRequest : SaveWeatherCommand where TResponse : class, IResult
{    

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var forecast = request.ToForecast();

        // domain validations

        var validation = await validator.ValidateAsync(forecast, cancellationToken);
        if (!validation.IsValid)
        {            
            return (Results.BadRequest(validation.Errors.ToStrings()) as TResponse)!;
        }

        // business validations

        if (request.IsUpdate())
        {
            var existsId = (await repository.GetAll())!.Any(forecast => forecast.Id == request.GetId());
            if (!existsId)
            {
                return (Results.NotFound("Id not found to update") as TResponse)!;
            }
        }

        return await next();
    }
}
