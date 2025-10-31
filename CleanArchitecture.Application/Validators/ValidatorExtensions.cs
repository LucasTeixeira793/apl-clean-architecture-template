using CleanArchitecture.Domain.Abstractions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Validators;

public static class ValidatorExtensions
{
    public static Result ValidateResult<T>(this IValidator<T> validator, T instance)
    {
        ValidationResult validationResult = validator.Validate(instance);

        if (validationResult.IsValid)
            return Result.Success();

        // Monta uma lista de mensagens de erro unificadas
        var errors = string.Join("; ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));

        // Cria um Error de domínio
        var error = new Error("Validation.Error", errors);

        return Result.Failure(error);
    }

    public static Result<T> ValidateResult<T>(this IValidator<T> validator, T instance, Func<T, Result<T>> onSuccess)
    {
        var validationResult = validator.Validate(instance);

        if (validationResult.IsValid)
            return onSuccess(instance);

        var errors = string.Join("; ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
        var error = new Error("Validation.Error", errors);

        return Result<T>.Failure(error);
    }
}
