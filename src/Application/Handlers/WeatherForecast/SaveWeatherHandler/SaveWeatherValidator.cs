using FluentValidation;
using MediatR;
using Application.Commons.Repositories;
using Application.Commons.Extensions;
using Application.Domain.Result;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherValidator<TRequest, TResponse> : AbstractValidator<TRequest>, IPipelineBehavior<TRequest, TResponse>
        where TRequest : SaveWeatherCommand 
        where TResponse : class, IResult
{
    private readonly IWeatherForecastRepository _repository;

    public SaveWeatherValidator(IWeatherForecastRepository repository)
    {
        _repository = repository;

        RuleFor(request => request.Date).NotEmpty();
        RuleFor(request => request.TemperatureC).NotEmpty();
        RuleFor(request => request.Summary).NotEmpty();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validation = await ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {            
            return (Result.BadRequest(validation.Errors.ToStrings()) as TResponse)!;
        }
    
        if (request.IsUpdate())
        {
            var existsId = (await _repository.GetAll())!.Any(forecast => forecast.Id == request.GetId());
            if (!existsId)
            {
                return (Result.BadRequest("Id not found to update") as TResponse)!;
            }
        }

        return await next();
    }
}
