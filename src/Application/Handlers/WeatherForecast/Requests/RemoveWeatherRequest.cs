using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.Requests;

public record RemoveWeatherRequest(Guid Id) : IRequest<IResult>;
    
