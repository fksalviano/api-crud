using FluentValidation;
using Domain.Models;

namespace Domain.Models.Validations;

public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
{
    public WeatherForecastValidator()
    {        
        RuleFor(forecast => forecast.Id).NotEmpty();
        RuleFor(forecast => forecast.Date).NotEmpty();
        RuleFor(forecast => forecast.TemperatureC).NotEmpty();
        RuleFor(forecast => forecast.Summary).NotEmpty();
    }
}
