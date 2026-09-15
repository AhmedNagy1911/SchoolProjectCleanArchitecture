using MediatR;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Models;

public class GetStudentListQuery : IRequest<List<Student>>
{
}
