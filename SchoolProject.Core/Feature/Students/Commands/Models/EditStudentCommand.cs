using MediatR;
using SchoolProject.Core.Abstractions;

namespace SchoolProject.Core.Feature.Students.Commands.Models;

public class EditStudentCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public int DepartmentID { get; set; }
}
