using FluentValidation;
using SchoolProject.Core.Feature.Authentication.Commands.Models;

namespace SchoolProject.Core.Feature.Authentication.Commands.Validators;

public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
{
    public ForgetPasswordCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
