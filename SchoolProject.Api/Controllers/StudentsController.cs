using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Feature.Students.Qureies.Models;

namespace SchoolProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult> GetStudents()
    {
        var response = await _mediator.Send(new GetStudentListQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetStudentById(int id)
    {
        var response = await _mediator.Send(new GetStudentByIdQuery(id));
        return Ok(response);
    }
}
