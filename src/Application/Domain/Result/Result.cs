global using IResult = Microsoft.AspNetCore.Http.IResult;
using Microsoft.AspNetCore.Http;

namespace Application.Domain.Result;

public class Result
{    
    public static IResult Ok<T>(T value) => Results.Ok(new ResponseBase<T>(value));
    public static IResult Ok() => Results.Ok(new ResponseBase<object>(string.Empty));

    public static IResult Created<T>(T value, string? uri = null) => Results.Created(uri, new ResponseBase<T>(value));
    public static IResult Created(string? uri = null) => Results.Created(uri, new ResponseBase<object>(string.Empty));

    public static IResult Accepted<T>(T value, string? uri = null) => Results.Accepted(uri, new ResponseBase<T>(value));
    public static IResult Accepted(string? uri = null) => Results.Accepted(uri, new ResponseBase<object>(string.Empty));    

    public static IResult NotFound(string message) => Results.NotFound(new ResponseBase<object>(message));
    public static IResult NotFound() => Results.NotFound(new ResponseBase<object>(nameof(NotFound)));

    public static IResult BadRequest(string message) => Results.BadRequest(new ResponseBase<object>(message));
    public static IResult BadRequest() => Results.BadRequest(new ResponseBase<object>(nameof(BadRequest)));

    public static IResult NoContent() => Results.NoContent();

    public static IResult Problem(string error) => Results.InternalServerError(new ResponseBase<object>(error));
    public static IResult InternalServerError(string error) => Results.InternalServerError(new ResponseBase<object>(error));
}
