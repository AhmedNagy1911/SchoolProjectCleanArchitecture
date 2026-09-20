using FluentValidation;
using SchoolProject.Core.Feature.Authentication.Commands.Models;

namespace SchoolProject.Core.Feature.Authentication.Commands.Validators;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
