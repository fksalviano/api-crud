using FluentValidation;
using System;

namespace Domain.Extensions;

public static class ValidationsExtension
{
    private static IServiceProvider _serviceProvider = null!;
    public static void SetProvider(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public static bool IsValid<T>(this T model, out string? errorMessage)
    {                
        var validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));
        
        var validator = _serviceProvider.GetService(validatorType) as IValidator<T>;
        if (validator is null)
        {
            errorMessage = "Validation not found for type " + typeof(T).Name;
            return false;
        }

        var validation = validator.ValidateAsync(model, default).Result;
        if (!validation.IsValid)
        {
            errorMessage = string.Join(", ", validation.Errors.Select(e => e.ErrorMessage));
            return false;
        }

        errorMessage = null;
        return true;        
    }
}
