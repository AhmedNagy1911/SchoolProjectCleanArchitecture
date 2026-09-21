using SchoolProject.Data.Entities;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Core.Feature.Authentication;

internal static class AuthTokens
{
    private const int RefreshTokenExpiryDays = 14;
    private const int StaleAfterDays = 30;

    // entity holds the hash (goes to DB), raw token goes to the client
    public static (RefreshToken Entity, string RawToken) NewRefreshToken()
    {
        var raw = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        var entity = new RefreshToken
        {
            Token = Hash(raw),
            ExpiresOn = DateTime.UtcNow.AddDays(RefreshTokenExpiryDays)
        };

        return (entity, raw);
    }

    public static string Hash(string token)
        => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

    public static void RemoveStale(ApplicationUser user)
        => user.RefreshTokens.RemoveAll(x => !x.IsActive && x.CreatedOn < DateTime.UtcNow.AddDays(-StaleAfterDays));
}