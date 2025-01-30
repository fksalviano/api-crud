using Domain.Requests;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.SaveWeatherHandler;

public class SaveWeatherCommand : SaveWeatherRequest, IRequest<IResult>
{    
    public Guid? Id { get; }            

    public SaveWeatherCommand(SaveWeatherRequest request, Guid? id = null) 
        : base(request.Date, request.TemperatureC, request.Summary)
    {
        Id = id;
    }
}
