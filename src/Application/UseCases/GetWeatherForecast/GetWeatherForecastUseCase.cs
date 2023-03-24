using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Extensions;

namespace Application.UseCases.GetWeather;

public class GetWeatherForecastUseCase : IGetWeatherForecastUseCase
{
    private IGetWeatherForecastOutputPort? _outputPort;
    private readonly IWeatherForecastRepository _repository;

    public void SetOutputPort(IGetWeatherForecastOutputPort outputPort) =>
        _outputPort = outputPort;        

    public GetWeatherForecastUseCase(IWeatherForecastRepository repository)
    {
        _repository = repository;
    }    

    public async Task ExecuteAsync()
    {
        var forecasts = await _repository.GetWeatherForecasts();

        if (!forecasts.Any())
        {
            _outputPort!.NotFound();
            return;
        }
        
        _outputPort!.Ok(forecasts.ToOutput());
    }
}
