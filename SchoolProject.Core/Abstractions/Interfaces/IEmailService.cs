using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Abstractions.Interfaces;

public interface IEmailService
{
    Task SendConfirmationEmailAsync(ApplicationUser user, string code, CancellationToken cancellationToken = default);
    Task SendResetPasswordEmailAsync(ApplicationUser user, string code, CancellationToken cancellationToken = default);
}
