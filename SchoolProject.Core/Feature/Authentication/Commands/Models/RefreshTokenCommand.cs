using MediatR;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Feature.Authentication.Results;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;

public record RefreshTokenCommand(string Token, string RefreshToken) : IRequest<Result<AuthResponse>>;
