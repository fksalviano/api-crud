using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.GetWeatherHandler;

public class GetWeatherCommand : IRequest<IResult>
{    
    public int? Id { get; }

    public bool IsGetById => Id is not null;

    public GetWeatherCommand(int? id = null)
    {
        Id = id;
    }
}
