using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Students.Qureies.Results;

namespace SchoolProject.Core.Feature.Students.Qureies.Models;

public class GetStudentListQuery : IRequest<Response<List<GetStudentListRespones>>>
{
}
