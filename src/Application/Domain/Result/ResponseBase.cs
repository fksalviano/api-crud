namespace Application.Domain.Result;

public class ResponseBase<T>
{
    public T? Result { get; set; }
    public string? ErrorMessage { get; set; }

    public ResponseBase(T? result) =>  Result = result;
    
    public  ResponseBase(string errorMessage) => ErrorMessage = errorMessage;    
}
