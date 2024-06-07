
using Application.Handlers.GetWeatherForecast.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Filters;

public class ResponseFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        // creates a new result based on result type and put it value in a base response
        result = result switch
        {
            Ok<IEnumerable<WeatherForecast>> => Results.Ok(new ResponseBase((result as Ok<IEnumerable<WeatherForecast>>)?.Value)),
            Ok<WeatherForecast> => Results.Ok(new ResponseBase((result as Ok<WeatherForecast>)?.Value)),

            NotFound => Results.NotFound(new ResponseBase(errorMessage: nameof(NotFound))),
            NotFound<string> => Results.NotFound(new ResponseBase(errorMessage: (result as NotFound<string>)?.Value)),

            BadRequest => Results.BadRequest(new ResponseBase(errorMessage: nameof(BadRequest))),
            BadRequest<string> => Results.BadRequest(new ResponseBase(errorMessage: (result as BadRequest<string>)?.Value)),

            ProblemHttpResult => Results.InternalServerError(new ResponseBase(errorMessage: (result as ProblemHttpResult)?.ProblemDetails.Detail)),
            InternalServerError => Results.InternalServerError(new ResponseBase(errorMessage: nameof(InternalServerError))),
            
            _ => result
        };

        return result;
    }
}
