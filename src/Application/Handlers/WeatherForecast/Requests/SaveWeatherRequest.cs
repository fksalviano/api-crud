using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Application.Handlers.WeatherForecast.Requests;

public class SaveWeatherRequest : IRequest<IResult>
{
    [JsonIgnore]
    public Guid? Id { get; private set; }

    public DateTime Date { get; }
    public int TemperatureC { get; }
    public string? Summary { get; }

    public SaveWeatherRequest(DateTime date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public SaveWeatherRequest SetId(Guid id)
    {
        Id = id;
        return this;
    }
}
