using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Authentication.Commands.Models;
using SchoolProject.Data.Entities;
using System.Buffers.Text;
using System.Text;

namespace SchoolProject.Core.Feature.Authentication.Commands.Handlers;

public class ResendConfirmationEmailCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : IRequestHandler<ResendConfirmationEmailCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
    {
        // don't reveal whether the email exists
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Success();

        if (user.EmailConfirmed)
            return Result.Failure(UserErrors.DuplicatedConfirmation);

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = Base64Url.EncodeToString(Encoding.UTF8.GetBytes(code));

        await _emailService.SendConfirmationEmailAsync(user, code, cancellationToken);

        return Result.Success();
    }
}
