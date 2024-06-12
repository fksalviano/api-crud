using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherCommand : IRequest<IResult>
{    
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

    private int? Id { get; set; }
    public bool IsUpdate() => Id is not null;
    public int? GetId() => Id;

    public SaveWeatherCommand WithId(int value)
    { 
        this.Id = value;
        return this;
    }

    public Domain.WeatherForecast ToForecast(int nextId = int.MaxValue) => new()
    {
        Id = this.Id ?? nextId,
        Date = this.Date,
        TemperatureC = this.TemperatureC,
        Summary = this.Summary
    };
}
