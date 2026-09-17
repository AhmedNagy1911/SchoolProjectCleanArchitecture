using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Feature.Students.Commands.Handlers;

public class StudentCommandHandler(IStudentService studentService,IMapper mapper) : ResponseHandler ,IRequestHandler<AddStudentCommand, Response<string>>
{
    private readonly IStudentService _studentService = studentService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);

      var result = await _studentService.AddAsync(student);

        if (result == "Exist")
            return UnprocessableEntity<string>("Name is exist");

        else if (result == "Success")
            return Created("Adding Succeeded");

        else
            return BadRequest<string>();
    }
}
