namespace Application.UseCases.GetWeatherForecast.Abstractions;

public interface IGetWeatherForecastUseCase
{
    Task ExecuteAsync();

    void SetOutputPort(IGetWeatherForecastOutputPort outputPort);
}
