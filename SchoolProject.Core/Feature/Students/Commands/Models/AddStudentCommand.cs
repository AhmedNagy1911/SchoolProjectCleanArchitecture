using MediatR;
using SchoolProject.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Core.Feature.Students.Commands.Models;

public class AddStudentCommand : IRequest<Response<string>>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int DepartmentID { get; set; }
}
