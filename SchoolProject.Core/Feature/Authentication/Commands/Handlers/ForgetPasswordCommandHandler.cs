using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Authentication.Commands.Models;
using SchoolProject.Data.Entities;
using System.Buffers.Text;
using System.Net;
using System.Text;

namespace SchoolProject.Core.Feature.Authentication.Commands.Handlers;

public class ForgetPasswordCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : IRequestHandler<ForgetPasswordCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        // don't reveal whether the email exists
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Success();

        if (!user.EmailConfirmed)
            return Result.Failure(UserErrors.EmailNotConfirmed with { StatusCode = (int)HttpStatusCode.BadRequest });

        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = Base64Url.EncodeToString(Encoding.UTF8.GetBytes(code));

        await _emailService.SendResetPasswordEmailAsync(user, code, cancellationToken);

        return Result.Success();
    }
}
