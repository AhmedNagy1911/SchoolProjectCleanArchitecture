using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Feature.Students.Commands.Models;

public class AddStudentCommand : IRequest<Response<string>>
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int DepartmentID { get; set; }
}
