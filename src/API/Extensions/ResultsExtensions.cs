using API.Base;
using Application.Commons.Domain.Result;

namespace API.Extensions;

public static class ResultsExtensions
{
    public static IResult ToResponse(this Result result)
    {        
        var response = new ResponseBase
        {
            Result = result.Value,
            ErrorMessage = result.Message
        };

        return result.Type switch
        {
            ResultType.Ok => Results.Ok(response),
            ResultType.NotFound => Results.NotFound(response.ErrorMessage),
            ResultType.Error => Results.Problem(response.ErrorMessage),
            _ => Results.InternalServerError()
        };
    }
}
