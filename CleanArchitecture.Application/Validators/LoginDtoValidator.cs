using CleanArchitecture.Application.UseCases.Login.Dto;
using CleanArchitecture.Domain.Exceptions.Base;
using FluentValidation;

namespace CleanArchitecture.Application.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty().WithErrorCode(ErrorCodes.CampoObrigatorio.Code).WithMessage("{PropertyName} - É obrigatório.")
            .EmailAddress().WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve ser um endereço de e-mail válido.");

        RuleFor(c => c.Password)
            .NotEmpty().WithErrorCode(ErrorCodes.CampoObrigatorio.Code).WithMessage("{PropertyName} - É obrigatório.")
            .MinimumLength(8).WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve ter no mínimo 8 caracteres.")
            .MaximumLength(16).WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve ter até 16 caracteres.")
            .Matches(@"[A-Z]+").WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve ter pelo menos uma letra maiuscula.")
            .Matches(@"[a-z]+").WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve ter pelo menos uma letra minuscula.")
            .Matches(@"[0-9]+").WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve conter pelo menos um número.")
            .Matches(@"[\!\?\*\.\#]+").WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("{PropertyName} - Deve conter pelo menos um caracter especial.")
            ;
    }
}
