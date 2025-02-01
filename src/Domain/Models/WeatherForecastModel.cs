namespace Domain.Models;

public class WeatherForecastModel
{        
    public Guid Id { get; }
    public DateTime Date { get; }
    public int TemperatureC { get; }
    public string? Summary { get; }

    public WeatherForecastModel(Guid id, DateTime date, int temperatureC, string? summary) 
    {
        Id = id;
        Date = date;        
        TemperatureC = temperatureC;        
        Summary = summary;
    }
}
