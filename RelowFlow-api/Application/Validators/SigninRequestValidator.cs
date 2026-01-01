using FluentValidation;
using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Validators;

public class SigninRequestValidator: AbstractValidator<SigninRequest>
{
    public SigninRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória");
    }
}