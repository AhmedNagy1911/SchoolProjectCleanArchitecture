using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Feature.Students.Commands.Handlers;

public class StudentCommandHandler(IApplicationDbContext context, IMapper mapper) :
    IRequestHandler<AddStudentCommand, Result<int>>,
    IRequestHandler<EditStudentCommand, Result>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<int>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var nameExists = await _context.Students
           .AnyAsync(x => x.Name == request.Name, cancellationToken);

        if (nameExists)
            return Result.Failure<int>(StudentErrors.DuplicatedName);

        var student = _mapper.Map<Student>(request);

        await _context.Students.AddAsync(student, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(student.StudID);
    }

    public async Task<Result> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(x => x.StudID == request.Id, cancellationToken);

        if (student is null)
            return Result.Failure(StudentErrors.NotFound);

        var nameExists = await _context.Students
            .AnyAsync(x => x.Name == request.Name && x.StudID != request.Id, cancellationToken);

        if (nameExists)
            return Result.Failure(StudentErrors.DuplicatedName);

        _mapper.Map(request, student);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
