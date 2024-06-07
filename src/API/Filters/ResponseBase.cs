namespace API.Filters;

public class ResponseBase
{
    public object? Result { get; set; }
    public string? ErrorMessage { get; set; }

    public ResponseBase(object? result = null, string? errorMessage = null)
    {
        Result = result;
        ErrorMessage = errorMessage;
    }
}

public class ResponseBase<T>
{
    public T? Result { get; set; }
    public string? ErrorMessage { get; set; }
}
