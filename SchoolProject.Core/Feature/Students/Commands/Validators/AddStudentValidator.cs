using FluentValidation;
using SchoolProject.Core.Feature.Students.Commands.Models;

namespace SchoolProject.Core.Feature.Students.Commands.Validators;

public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
    public AddStudentValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(500);
    }
}
