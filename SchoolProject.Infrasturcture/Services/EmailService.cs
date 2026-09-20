using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Options;
using System.Net;


namespace SchoolProject.Infrasturcture.Services;

public class EmailService(
    IOptions<MailSettings> mailSettings,
    IHttpContextAccessor httpContextAccessor,
    ILogger<EmailService> logger) : IEmailService
{
    private readonly MailSettings _mailSettings = mailSettings.Value;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly ILogger<EmailService> _logger = logger;

    public async Task SendConfirmationEmailAsync(ApplicationUser user, string code, CancellationToken cancellationToken = default)
    {
        var body = await BuildBodyAsync("EmailConfirmation", new Dictionary<string, string>
        {
            { "{{name}}", WebUtility.HtmlEncode(user.FirstName) },
            { "{{action_url}}", $"{GetOrigin()}/auth/emailConfirmation?userId={user.Id}&code={code}" }
        }, cancellationToken);

        await SendAsync(user.Email!, "✅ SchoolProject: Email Confirmation", body, cancellationToken);
    }

    public async Task SendResetPasswordEmailAsync(ApplicationUser user, string code, CancellationToken cancellationToken = default)
    {
        var body = await BuildBodyAsync("ForgetPassword", new Dictionary<string, string>
        {
            { "{{name}}", WebUtility.HtmlEncode(user.FirstName) },
            { "{{action_url}}", $"{GetOrigin()}/auth/forgetPassword?email={Uri.EscapeDataString(user.Email!)}&code={code}" }
        }, cancellationToken);

        await SendAsync(user.Email!, "✅ SchoolProject: Change Password", body, cancellationToken);
    }

    // Frontend origin (sent by the browser). Falls back to the API host if the header is missing.
    private string GetOrigin()
    {
        var request = _httpContextAccessor.HttpContext?.Request;

        if (request is null)
            return string.Empty;

        var origin = request.Headers.Origin.ToString();

        return string.IsNullOrWhiteSpace(origin) ? $"{request.Scheme}://{request.Host}" : origin;
    }

    private static async Task<string> BuildBodyAsync(string template, Dictionary<string, string> model, CancellationToken cancellationToken)
    {
        var templatePath = Path.Combine(AppContext.BaseDirectory, "Templates", $"{template}.html");

        var body = await File.ReadAllTextAsync(templatePath, cancellationToken);

        foreach (var item in model)
            body = body.Replace(item.Key, item.Value);

        return body;
    }

    private async Task SendAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken)
    {
        var message = new MimeMessage
        {
            Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail),
            Subject = subject
        };

        message.To.Add(MailboxAddress.Parse(email));
        message.Body = new BodyBuilder { HtmlBody = htmlMessage }.ToMessageBody();

        using var smtp = new SmtpClient();

        _logger.LogInformation("Sending email to {Email}", email);

        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls, cancellationToken);
        await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password, cancellationToken);
        await smtp.SendAsync(message, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }
}
