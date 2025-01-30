using FluentValidation;
using Domain.Models;

namespace Domain.Requests.Validations;

public class SaveWeatherValidator : AbstractValidator<Domain.Requests.SaveWeatherRequest>
{
    public SaveWeatherValidator()
    {
        RuleFor(forecast => forecast.Date).NotEmpty();
        RuleFor(forecast => forecast.TemperatureC).NotEmpty();
        RuleFor(forecast => forecast.Summary).NotEmpty();
    }
}
