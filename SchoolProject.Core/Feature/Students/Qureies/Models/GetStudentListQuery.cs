using MediatR;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Feature.Students.Qureies.Results;

namespace SchoolProject.Core.Feature.Students.Qureies.Models;

public class GetStudentListQuery : IRequest<Result<List<GetStudentListRespones>>>
{
}
