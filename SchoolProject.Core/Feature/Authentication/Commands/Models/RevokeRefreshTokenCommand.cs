using MediatR;
using SchoolProject.Core.Abstractions;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;


public record RevokeRefreshTokenCommand(string Token, string RefreshToken) : IRequest<Result>;
