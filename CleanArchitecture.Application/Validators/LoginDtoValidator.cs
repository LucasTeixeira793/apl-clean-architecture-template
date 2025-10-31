using CleanArchitecture.Application.Login.Dto;
using FluentValidation;

namespace CleanArchitecture.Application.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("O campo E-mail é obrigatório.")
            .EmailAddress().WithMessage("O campo E-mail deve ser um endereço de e-mail válido.");

        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("O campo Senha é obrigatório.")
            .MinimumLength(6).WithMessage("O campo Senha deve ter no mínimo 6 caracteres.");
    }
}
