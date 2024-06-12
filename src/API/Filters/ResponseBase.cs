namespace API.Filters;

public class ResponseBase<T>
{
    public T? Result { get; }
    public string? ErrorMessage { get; }

    public ResponseBase(T? result) =>  Result = result;    
    public ResponseBase(string? errorMessage) => ErrorMessage = errorMessage;

}
