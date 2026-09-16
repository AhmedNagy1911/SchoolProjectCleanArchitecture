using AutoMapper;
using MediatR;
using SchoolProject.Core.Feature.Students.Qureies.Models;
using SchoolProject.Core.Feature.Students.Qureies.Results;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Feature.Students.Qureies.Handlers;

public class StudentHandler(IStudentService studentService , IMapper mapper) : IRequestHandler<GetStudentListQuery, List<GetStudentListRespones>>
{
    private readonly IStudentService _studentService = studentService;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetStudentListRespones>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    { 
        var studentList = await _studentService.GetAllStudentsAsync();

       var studentListMapper = _mapper.Map<List<GetStudentListRespones>>(studentList);

        return studentListMapper;
    }
}
