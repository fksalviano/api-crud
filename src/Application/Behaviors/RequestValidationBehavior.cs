using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, IResult> where TRequest : notnull
{
    public async Task<IResult> Handle(TRequest request, RequestHandlerDelegate<IResult> next, CancellationToken cancellationToken)
    {        
        if (!validators.Any())
        {
            return await next();
        }

        foreach (var validator in validators)
        {                    
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return BadRequest(string.Join(", ", validation.Errors.Select(e => e.ErrorMessage)));
            }
        }

        return await next();
    }    
}
