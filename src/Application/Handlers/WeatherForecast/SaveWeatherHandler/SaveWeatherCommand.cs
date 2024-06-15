using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherCommand : IRequest<IResult>
{    
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

    private Guid? Id { get; set; }
    public bool IsUpdate() => Id is not null;
    public Guid? GetId() => Id;

    public SaveWeatherCommand WithId(Guid value)
    { 
        this.Id = value;
        return this;
    }

    public Domain.Model.WeatherForecast ToForecast() => new()
    {
        Id = this.Id?.ToString() ?? Guid.NewGuid().ToString(),
        Date = this.Date,
        TemperatureC = this.TemperatureC,
        Summary = this.Summary
    };
}
