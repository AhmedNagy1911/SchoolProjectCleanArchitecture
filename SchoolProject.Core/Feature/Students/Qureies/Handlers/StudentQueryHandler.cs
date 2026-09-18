using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Abstractions;
using SchoolProject.Core.Errors;
using SchoolProject.Core.Feature.Students.Qureies.Models;
using SchoolProject.Core.Feature.Students.Qureies.Results;

namespace SchoolProject.Core.Feature.Students.Qureies.Handlers;

public class StudentQueryHandler(IApplicationDbContext context, IMapper mapper) :
    IRequestHandler<GetStudentListQuery, Result<List<GetStudentListRespones>>>,
    IRequestHandler<GetStudentByIdQuery, Result<GetSingleStudentResponse>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<List<GetStudentListRespones>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
    {
        var students = await _context.Students
           .AsNoTracking()
           .ProjectTo<GetStudentListRespones>(_mapper.ConfigurationProvider)
           .ToListAsync(cancellationToken);

        return Result.Success(students);
    }

    public async Task<Result<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students
            .AsNoTracking()
            .Where(x => x.StudID == request.Id)
            .ProjectTo<GetSingleStudentResponse>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return student is null
            ? Result.Failure<GetSingleStudentResponse>(StudentErrors.NotFound)
            : Result.Success(student);
    }
}
