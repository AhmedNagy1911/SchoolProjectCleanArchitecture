using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Abstractions;


namespace SchoolProject.Core.Errors;

public static class StudentErrors
{
    public static readonly Error NotFound =
        new("Student.NotFound", "No student was found with the given id.", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedName =
        new("Student.DuplicatedName", "Another student with the same name already exists.", StatusCodes.Status409Conflict);
}
