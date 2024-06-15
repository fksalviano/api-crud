namespace Domain.Model;

public class WeatherForecast
{
    public string Id { get => _id.ToString(); set => _id = Guid.Parse(value); }
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }    
    public string? Summary { get; set; }

    private Guid _id;
}
