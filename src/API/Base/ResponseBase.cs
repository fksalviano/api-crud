namespace API.Base;

public class ResponseBase
{
    public virtual object? Result { get; set; }
    public string? ErrorMessage { get; set; }
}

public class ResponseBase<T>
{ 
    public T? Result { get; set; }
    public string? ErrorMessage { get; set; }
}