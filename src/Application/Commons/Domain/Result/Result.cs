namespace Application.Commons.Domain.Result;

public class Result
{    
    public ResultType Type { get; set; }
    public virtual object? Value { get; }
    public string? Message { get; }

    public Result(ResultType type, object? value = null, string? message = null)
    {
        Type = type;
        Value = value;
        Message = message;
    }

    public static Result Ok(object? value) => new(ResultType.Ok, value);
    public static Result NotFound(string? message = null) => new(ResultType.NotFound, message);
    public static Result Error(string message) => new(ResultType.Error, message);
}
