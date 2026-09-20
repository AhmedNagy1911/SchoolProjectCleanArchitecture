using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Feature.Authentication.Results;

public record AuthResponse(
    string Id,
    string? Email,
    string? PhoneNumber,
    string? UserName,
    string FirstName,
    string LastName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiration)
{
    public static AuthResponse From(ApplicationUser user, string token, int expiresIn, string refreshToken, DateTime refreshTokenExpiration)
        => new(user.Id, user.Email, user.PhoneNumber, user.UserName, user.FirstName, user.LastName,
               token, expiresIn, refreshToken, refreshTokenExpiration);
}
