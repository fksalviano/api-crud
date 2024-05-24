using Application.UseCases.GetWeatherForecast.Ports;
using Application.UseCases.GetWeatherForecast.Abstractions;

namespace Worker.Endpoints.GetWeatherForecast;

public class GetWeatherForecastEndpoint : IGetWeatherForecastOutputPort
{
    private readonly IGetWeatherForecastUseCase _useCase;    
    private IResult _result = null!;

    public GetWeatherForecastEndpoint(IGetWeatherForecastUseCase useCase)
    {
        _useCase = useCase;        
        _useCase.SetOutputPort(this);
    }
    
    public async Task<IResult> GetWeatherForecast()
    {
        await _useCase.ExecuteAsync();
        return _result;
    }

    void IGetWeatherForecastOutputPort.Ok(GetWeatherForecastOutput output) =>
        _result = Results.Ok(GetWeatherForecastResponse.Success(output));

    void IGetWeatherForecastOutputPort.NotFound() =>
        _result = Results.NotFound(GetWeatherForecastResponse.Error("Not Found"));

    void IGetWeatherForecastOutputPort.Error(string message) =>  
        _result = Results.Problem(message);
}
