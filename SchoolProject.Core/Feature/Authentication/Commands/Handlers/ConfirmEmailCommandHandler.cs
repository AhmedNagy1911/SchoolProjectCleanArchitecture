using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Authentication.Commands.Models;
using SchoolProject.Data.Entities;
using System.Buffers.Text;
using System.Net;
using System.Text;

namespace SchoolProject.Core.Feature.Authentication.Commands.Handlers;

public class ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<ConfirmEmailCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByIdAsync(request.UserId) is not { } user)
            return Result.Failure(UserErrors.InvalidCode);

        if (user.EmailConfirmed)
            return Result.Failure(UserErrors.DuplicatedConfirmation);

        string code;

        try
        {
            code = Encoding.UTF8.GetString(Base64Url.DecodeFromChars(request.Code));
        }
        catch (FormatException)
        {
            return Result.Failure(UserErrors.InvalidCode);
        }

        var result = await _userManager.ConfirmEmailAsync(user, code);

        if (result.Succeeded)
            return Result.Success();

        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, (int)HttpStatusCode.BadRequest));
    }
}
