using FluentValidation;
using SchoolProject.Core.Feature.Authentication.Commands.Models;

namespace SchoolProject.Core.Feature.Authentication.Commands.Validators;

public class ResendConfirmationEmailCommandValidator : AbstractValidator<ResendConfirmationEmailCommand>
{
    public ResendConfirmationEmailCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
