using SchoolProject.Data.Entities;
using System.Security.Cryptography;

namespace SchoolProject.Core.Feature.Authentication;

internal static class AuthTokens
{
    private const int RefreshTokenExpiryDays = 14;

    public static RefreshToken NewRefreshToken() => new()
    {
        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        ExpiresOn = DateTime.UtcNow.AddDays(RefreshTokenExpiryDays)
    };
}
