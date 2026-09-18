using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Abstractions;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Subjects> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
    public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }

}
