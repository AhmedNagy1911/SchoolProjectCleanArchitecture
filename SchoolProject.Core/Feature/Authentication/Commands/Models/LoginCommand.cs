using MediatR;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Feature.Authentication.Results;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<AuthResponse>>;
