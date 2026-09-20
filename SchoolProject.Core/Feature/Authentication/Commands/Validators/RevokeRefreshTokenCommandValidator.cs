using FluentValidation;
using SchoolProject.Core.Feature.Authentication.Commands.Models;

namespace SchoolProject.Core.Feature.Authentication.Commands.Validators;

public class RevokeRefreshTokenCommandValidator : AbstractValidator<RevokeRefreshTokenCommand>
{
    public RevokeRefreshTokenCommandValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}
