using MediatR;
using SchoolProject.Core.Abstractions;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;

public record ResetPasswordCommand(string Email, string Code, string NewPassword) : IRequest<Result>;
