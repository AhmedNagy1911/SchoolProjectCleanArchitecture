using MediatR;
using SchoolProject.Core.Abstractions;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;


public record ResendConfirmationEmailCommand(string Email) : IRequest<Result>;
