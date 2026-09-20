using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Abstractions.Interfaces;
using SchoolProject.Data.Entities;
using System.Reflection;

namespace SchoolProject.Infrasturcture.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityUserContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Subjects> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
    public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
