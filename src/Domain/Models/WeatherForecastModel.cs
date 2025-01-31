namespace Domain.Models;

public class WeatherForecastModel
{
    public string Id { get => _id.ToString(); }
    public DateTime Date { get; }
    public int TemperatureC { get; }
    public string? Summary { get; }

    private Guid _id;
    public void SetNewId() => _id = Guid.NewGuid();

    public WeatherForecastModel(string id, DateTime date, int temperatureC, string? summary)
    {
        _id = Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
}
