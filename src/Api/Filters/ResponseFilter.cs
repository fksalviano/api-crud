using System.Net;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Extensions;

namespace Api.Filters;

public class ResponseFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        var response = GetResponseBase(result, out var statusCode, out var location);

        var url = context.HttpContext.Request.GetDisplayUrl();

        result = statusCode switch
        {
            Status200OK => Results.Ok(response),
            Status201Created => Results.Created($"{url}/{location}", response),
            Status202Accepted => Results.Accepted(url, response),
            Status204NoContent => Results.NoContent(),
            Status400BadRequest => Results.BadRequest(response),
            Status404NotFound => Results.NotFound(response),
            Status500InternalServerError => Results.InternalServerError(response),
            _ => result
        };

        return result;
    }

    private ResponseBase<object?> GetResponseBase(object? result, out int? statusCode, out string? location)
    {
        object? value = null;

        if (typeof(IValueHttpResult<object?>).IsAssignableFrom(result?.GetType()))
        {
            if (result is ProblemHttpResult problemResult)
                value = problemResult.ProblemDetails.Detail;
            else
                value = (result as IValueHttpResult<object?>)?.Value;
        }

        statusCode = (result as IStatusCodeHttpResult)?.StatusCode;
        var isSuccesStatusCode = new HttpResponseMessage((HttpStatusCode)statusCode!).IsSuccessStatusCode;

        location = (statusCode == Status201Created || statusCode == Status202Accepted) ?
            result?.GetType().GetProperties().FirstOrDefault(p => p.Name == "Location")?.GetValue(result)?.ToString() : null;        

        if (!isSuccesStatusCode)        
        {
            var errorMessage = (value is not null) ? value.ToString() : ((HttpStatusCode)statusCode!).ToString();
            return new ResponseBase<object?>(errorMessage);
        }

        return new ResponseBase<object?>(value);
    }
}
