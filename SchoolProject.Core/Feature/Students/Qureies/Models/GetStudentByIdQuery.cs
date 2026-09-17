using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Qureies.Results;

namespace SchoolProject.Core.Feature.Students.Qureies.Models;

public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
{
    public int Id { get; set; }
    public GetStudentByIdQuery(int id)
    {
        Id = id;
    }
}
