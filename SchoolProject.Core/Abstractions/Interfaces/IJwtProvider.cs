using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Abstractions.Interfaces;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user);

    /// <summary>Validates the signature only (lifetime is ignored) and returns the user id (sub claim).</summary>
    string? ValidateToken(string token);
}
