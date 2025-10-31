using CleanArchitecture.Domain.Abstractions;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Validators;

public static class ValidatorExtensions
{
    public static Result ValidateResult<T>(this IValidator<T> validator, T instance)
    {
        ValidationResult validation = validator.Validate(instance);

        if (validation.IsValid)
            return Result.Success();

        var errors = validation.Errors
            .Select(e => new Error(e.ErrorCode, e.ErrorMessage))
            .ToList();

        return Result.Failure([.. errors]);
    }

    public static Result<T> ValidateResult<T>(this IValidator<T> validator, T instance, T data)
    {
        ValidationResult validation = validator.Validate(instance);

        if (validation.IsValid)
            return Result<T>.Success(data);

        var errors = validation.Errors
            .Select(e => new Error(e.ErrorCode, e.ErrorMessage))
            .ToList();

        return Result<T>.Failure([.. errors]);
    }
}
