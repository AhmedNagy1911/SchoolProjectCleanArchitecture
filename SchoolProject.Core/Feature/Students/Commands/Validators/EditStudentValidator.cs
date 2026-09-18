using FluentValidation;
using SchoolProject.Core.Feature.Students.Commands.Models;

namespace SchoolProject.Core.Feature.Students.Commands.Validators;

public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
{
    public EditStudentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Phone)
            .MaximumLength(500);

        RuleFor(x => x.DepartmentID)
            .GreaterThan(0);
    }
}

