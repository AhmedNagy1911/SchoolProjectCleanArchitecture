using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Authentication.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Feature.Authentication.Commands.Handlers;

public class RevokeRefreshTokenCommandHandler(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
    : IRequestHandler<RevokeRefreshTokenCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userId = _jwtProvider.ValidateToken(request.Token);

        if (userId is null)
            return Result.Failure(UserErrors.InvalidJwtToken);

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return Result.Failure(UserErrors.InvalidJwtToken);

        var hash = AuthTokens.Hash(request.RefreshToken);

        var userRefreshToken = user.RefreshTokens
            .SingleOrDefault(x => x.Token == hash && x.IsActive);

        if (userRefreshToken is null)
            return Result.Failure(UserErrors.InvalidRefreshToken);

        userRefreshToken.RevokedOn = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        return Result.Success();
    }
}
