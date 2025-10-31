using CleanArchitecture.Application.UseCases.Login.Dto;
using CleanArchitecture.Domain.Exceptions.Base;
using FluentValidation;

namespace CleanArchitecture.Application.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty().WithErrorCode(ErrorCodes.CampoObrigatorio.Code).WithMessage("O campo Email é obrigatório.")
            .EmailAddress().WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("O campo Email deve ser um endereço de e-mail válido.");

        RuleFor(c => c.Password)
            .NotEmpty().WithErrorCode(ErrorCodes.CampoObrigatorio.Code).WithMessage("O campo Senha é obrigatório.")
            .MinimumLength(6).WithErrorCode(ErrorCodes.CampoInvalido.Code).WithMessage("O campo Senha deve ter no mínimo 6 caracteres.");
    }
}
