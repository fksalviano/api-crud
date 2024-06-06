using Application.Handlers.GetWeatherForecast;
using MediatR;

namespace API.Endpoints.WeatherForecast;

public class WeatherForecastEndpoints
{
    private readonly IMediator _mediator;

    public WeatherForecastEndpoints(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> GetWeatherForecast()
    {
        return await _mediator.Send(new GetWeatherForecastCommand());
    }
}
