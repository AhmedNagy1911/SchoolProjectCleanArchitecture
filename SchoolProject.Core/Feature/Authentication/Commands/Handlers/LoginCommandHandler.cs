using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Authentication.Commands.Models;
using SchoolProject.Core.Feature.Authentication.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Feature.Authentication.Commands.Handlers;

public class LoginCommandHandler(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
    : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        if (await _userManager.IsLockedOutAsync(user))
            return Result.Failure<AuthResponse>(UserErrors.LockedUser);

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            await _userManager.AccessFailedAsync(user);
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);
        }

        if (user.IsDisabled)
            return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

        if (!user.EmailConfirmed)
            return Result.Failure<AuthResponse>(UserErrors.EmailNotConfirmed);

        await _userManager.ResetAccessFailedCountAsync(user);

        var roles = await _userManager.GetRolesAsync(user);
        var (token, expiresIn) = _jwtProvider.GenerateToken(user, roles);

        var (refreshToken, rawRefreshToken) = AuthTokens.NewRefreshToken();
        AuthTokens.RemoveStale(user);
        user.RefreshTokens.Add(refreshToken);
        await _userManager.UpdateAsync(user);

        return Result.Success(AuthResponse.From(user, token, expiresIn, rawRefreshToken, refreshToken.ExpiresOn));

    }
}
