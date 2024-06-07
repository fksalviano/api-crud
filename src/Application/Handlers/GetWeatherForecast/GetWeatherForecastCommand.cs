using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.GetWeatherForecast;

public class GetWeatherForecastCommand : IRequest<IResult>
{    
    public int? Id { get; }

    public bool IsGetById => Id is not null;

    public GetWeatherForecastCommand(int? id = null)
    {
        Id = id;
    }
}
