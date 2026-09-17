using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Qureies.Models;
using SchoolProject.Core.Feature.Students.Qureies.Results;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Feature.Students.Qureies.Handlers;

public class StudentQueryHandler(IStudentService studentService , IMapper mapper) : ResponseHandler,
    IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRespones>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
{
    private readonly IStudentService _studentService = studentService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<List<GetStudentListRespones>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    { 
        var studentList = await _studentService.GetAllStudentsAsync();

       var studentListMapper = _mapper.Map<List<GetStudentListRespones>>(studentList);

        return Success(studentListMapper);
    }

    public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);
        if (student is null)
            return NotFound<GetSingleStudentResponse>();

        var result = _mapper.Map<GetSingleStudentResponse>(student);

        return Success(result);
    }
}
