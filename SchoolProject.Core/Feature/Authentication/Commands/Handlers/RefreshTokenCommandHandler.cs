using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Authentication.Commands.Models;
using SchoolProject.Core.Feature.Authentication.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Feature.Authentication.Commands.Handlers;

public class RefreshTokenCommandHandler(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
    : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userId = _jwtProvider.ValidateToken(request.Token);

        if (userId is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidJwtToken);

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidJwtToken);

        if (user.IsDisabled)
            return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

        if (await _userManager.IsLockedOutAsync(user))
            return Result.Failure<AuthResponse>(UserErrors.LockedUser);

        var hash = AuthTokens.Hash(request.RefreshToken);

        var userRefreshToken = user.RefreshTokens
            .SingleOrDefault(x => x.Token == hash && x.IsActive);

        if (userRefreshToken is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidRefreshToken);

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        var roles = await _userManager.GetRolesAsync(user);
        var (newToken, expiresIn) = _jwtProvider.GenerateToken(user, roles);

        var (newRefreshToken, rawRefreshToken) = AuthTokens.NewRefreshToken();
        AuthTokens.RemoveStale(user);
        user.RefreshTokens.Add(newRefreshToken);
        await _userManager.UpdateAsync(user);

        return Result.Success(AuthResponse.From(user, newToken, expiresIn, rawRefreshToken, newRefreshToken.ExpiresOn));
    }
}
