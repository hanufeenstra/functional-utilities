using FluentValidation.Results;
using FunctionalUtilities.Errors;

namespace FunctionalUtilities.Extensions;

public static class FluentValidationResultExtensions
{
    public static Error ToError(this ValidationResult validationResult)
    {
        var errors = new Dictionary<string, string[]>();

        foreach (var validationError in validationResult.Errors)
        {
            errors.Add(
                validationError.PropertyName, 
                [validationError.ErrorMessage]
            );
        }

        return Error.FromValidationResult(errors);
    }
}