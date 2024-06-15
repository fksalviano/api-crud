using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.GetWeatherHandler;

public class GetWeatherCommand : IRequest<IResult>
{    
    public Guid? Id { get; }

    public bool IsGetById => Id is not null;

    public GetWeatherCommand(Guid? id = null)
    {
        Id = id;
    }
}
