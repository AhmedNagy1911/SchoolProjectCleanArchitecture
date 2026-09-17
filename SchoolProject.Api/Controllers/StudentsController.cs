using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Feature.Students.Commands.Models;
using SchoolProject.Core.Feature.Students.Qureies.Models;

namespace SchoolProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : AppControllerBase
{

    [HttpGet("")]
    public async Task<ActionResult> GetStudents()
    {
        var response = await Mediator.Send(new GetStudentListQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetStudentById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetStudentByIdQuery(id));
        return NewResult(response);
    }

    [HttpPost("")]
    public async Task<ActionResult> Create([FromBody] AddStudentCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}
