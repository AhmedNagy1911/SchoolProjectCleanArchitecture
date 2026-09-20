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

public class RegisterCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : IRequestHandler<RegisterCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not null)
            return Result.Failure(UserErrors.DuplicatedEmail);

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var error = result.Errors.First();
            return Result.Failure(new Error(error.Code, error.Description, (int)HttpStatusCode.BadRequest));
        }

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = Base64Url.EncodeToString(Encoding.UTF8.GetBytes(code));

        await _emailService.SendConfirmationEmailAsync(user, code, cancellationToken);

        return Result.Success();
    }
}
