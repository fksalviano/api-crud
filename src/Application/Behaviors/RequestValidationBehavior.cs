using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Http.Results;

namespace Application.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse>(IServiceProvider serviceProvider) : IPipelineBehavior<TRequest, IResult> where TRequest : notnull
{
    public async Task<IResult> Handle(TRequest request, RequestHandlerDelegate<IResult> next, CancellationToken cancellationToken)
    {
        var requestType = request.GetType().BaseType ?? request.GetType();
        var validatorType = typeof(IValidator<>).MakeGenericType(requestType);

        var validator = serviceProvider.GetService(validatorType) as IValidator<TRequest>;
        if (validator is not null)
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
