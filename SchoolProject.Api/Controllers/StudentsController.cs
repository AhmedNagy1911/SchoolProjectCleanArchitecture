using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Extensions;
using SchoolProject.Core.Abstractions.Consts;
using SchoolProject.Core.Feature.Students.Commands.Models;
using SchoolProject.Core.Feature.Students.Qureies.Models;

namespace SchoolProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StudentsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("")]
    [Authorize(Roles = $"{DefaultRoles.Admin},{DefaultRoles.Teacher}")]
    public async Task<IActionResult> GetStudents(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetStudentListQuery(), cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{DefaultRoles.Admin},{DefaultRoles.Teacher}")]
    public async Task<IActionResult> GetStudentById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetStudentByIdQuery(id), cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("")]
    [Authorize(Roles = DefaultRoles.Admin)]
    public async Task<IActionResult> Create([FromBody] AddStudentCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetStudentById), new { id = result.Value }, new { id = result.Value })
            : result.ToProblem();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = DefaultRoles.Admin)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EditStudentCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
