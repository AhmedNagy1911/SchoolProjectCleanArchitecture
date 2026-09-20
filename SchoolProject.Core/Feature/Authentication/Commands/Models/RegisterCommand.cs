using MediatR;
using SchoolProject.Core.Abstractions;

namespace SchoolProject.Core.Feature.Authentication.Commands.Models;

public record RegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string UserName) : IRequest<Result>;
