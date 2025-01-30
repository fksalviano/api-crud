using System.Text.Json.Serialization;

namespace Domain.Requests;

public class SaveWeatherRequest
{
    public DateTime Date { get; }
    public int TemperatureC { get; }
    public string? Summary { get; }

    public SaveWeatherRequest(DateTime date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }    
}
