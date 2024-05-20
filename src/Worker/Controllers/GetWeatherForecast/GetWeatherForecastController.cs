using Application.UseCases.GetWeather.Ports;
using Application.UseCases.GetWeatherForecast.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Worker.Controllers.GetWeatherForecast;

[ApiController]
[Route("WeatherForecast")]
public class GetWeatherForecastController : ControllerBase, IGetWeatherForecastOutputPort
{
    private readonly IGetWeatherForecastUseCase _useCase;
    private readonly ILogger<GetWeatherForecastController> _logger;
    private IActionResult _viewModel = null!;

    public GetWeatherForecastController(IGetWeatherForecastUseCase useCase,
        ILogger<GetWeatherForecastController> logger)
    {
        _useCase = useCase;
        _logger = logger;

        _useCase.SetOutputPort(this);
    }

    /// <summary>
    /// Get weather forecasts sample endpoint
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType<GetWeatherForecastResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetWeatherForecast()
    {
        await _useCase.ExecuteAsync();

        return _viewModel;
    }

    void IGetWeatherForecastOutputPort.Ok(GetWeatherForecastOutput output) =>
        _viewModel = Ok(GetWeatherForecastResponse.Success(output));

    void IGetWeatherForecastOutputPort.NotFound() =>
        _viewModel = NotFound(GetWeatherForecastResponse.Error("Not Found"));

    void IGetWeatherForecastOutputPort.Error(string message) =>  
        _viewModel = StatusCode(StatusCodes.Status500InternalServerError, GetWeatherForecastResponse.Error(message));
}
