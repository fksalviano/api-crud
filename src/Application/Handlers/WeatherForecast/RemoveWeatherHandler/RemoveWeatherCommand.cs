using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.RemoveWeatherHandler;

public record RemoveWeatherCommand(int Id) : IRequest<IResult>;
    
