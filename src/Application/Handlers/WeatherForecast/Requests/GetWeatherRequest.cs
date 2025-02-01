using Microsoft.AspNetCore.Http;
using MediatR;

namespace Application.Handlers.WeatherForecast.Requests;

public record GetWeatherRequest(Guid? Id = null) : IRequest<IResult>;
