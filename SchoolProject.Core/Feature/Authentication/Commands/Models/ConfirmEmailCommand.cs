using MediatR;
using SchoolProject.Core.Abstractions;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;

public record ConfirmEmailCommand(string UserId, string Code) : IRequest<Result>;