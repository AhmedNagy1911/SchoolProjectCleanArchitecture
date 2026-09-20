using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Extensions;
using SchoolProject.Core.Feature.Authentication.Commands.Models;

namespace SchoolProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : result.ToProblem();
    }
}
