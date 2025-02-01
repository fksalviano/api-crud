using FluentValidation;
using Application.Handlers.WeatherForecast.Requests;

namespace Application.Handlers.WeatherForecast.Validations;

public class SaveWeatherValidator : AbstractValidator<SaveWeatherRequest>
{
    public SaveWeatherValidator()
    {
        RuleFor(request => request.Date).NotEmpty();
        RuleFor(request => request.TemperatureC).NotEmpty();        
    }
}
