using FluentValidation.Results;

namespace Application.Commons.Extensions;

public static class ValidationExtensions
{
    public static string ToStrings(this IEnumerable<ValidationFailure> errors) =>
        string.Join(", ", errors.Select(error => error.ErrorMessage));
}
