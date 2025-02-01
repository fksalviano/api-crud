using FluentValidation;
using Domain.Entities;

namespace Domain.Entities.Validations;

public class WeatherForecastEntityValidator : AbstractValidator<WeatherForecastEntity>
{
    public WeatherForecastEntityValidator()
    {
        RuleFor(entity => entity.Id).NotEmpty();
        RuleFor(entity => entity.Date).NotEmpty();
        RuleFor(entity => entity.TemperatureC).NotEmpty();
    }
}
