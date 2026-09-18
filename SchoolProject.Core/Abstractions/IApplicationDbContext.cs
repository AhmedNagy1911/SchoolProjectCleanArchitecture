using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Department> Departments { get; }
    DbSet<Subjects> Subjects { get; }
    DbSet<StudentSubject> StudentSubjects { get; }
    DbSet<DepartmetSubject> DepartmetSubjects { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

