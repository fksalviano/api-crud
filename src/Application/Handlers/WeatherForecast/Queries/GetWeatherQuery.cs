using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.GetWeatherHandler;

public record GetWeatherQuery(Guid? Id = null) : IRequest<IResult>;
