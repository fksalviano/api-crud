using Application.UseCases.GetWeatherForecast.Abstractions;
using Application.UseCases.GetWeatherForecast.Extensions;

namespace Application.UseCases.GetWeatherForecast;

public class GetWeatherForecastUseCase : IGetWeatherForecastUseCase
{
    private IGetWeatherForecastOutputPort _outputPort = null!;
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

        if (forecasts == null)
        {
            _outputPort.Error("Error to Get Forecasts");
            return;
        }

        if (!forecasts.Any())
        {
            _outputPort.NotFound();
            return;
        }
        
        var output = forecasts.ToOutput();
        _outputPort.Ok(output);
    }
}
