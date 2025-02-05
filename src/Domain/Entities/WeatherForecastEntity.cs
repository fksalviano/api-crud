using FluentValidation;

namespace Domain.Entities;

public class WeatherForecastEntity
{
    public string? Id { get; set; }
    public DateTime? Date { get; set; }
    public int? TemperatureC { get; set; }
    public string? Summary { get; set; }

    public void SetNewId() => Id = Guid.NewGuid().ToString();    
}
