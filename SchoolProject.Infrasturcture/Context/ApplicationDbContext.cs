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

    public DbSet<AcademicYear> AcademicYears { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<ClassEnrollment> ClassEnrollments { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<ParentStudent> ParentStudents { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<StudentGrade> StudentGrades { get; set; }
    public DbSet<TimetableSlot> TimetableSlots { get; set; }
    public DbSet<FeeType> FeeTypes { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Payment> Payments { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
