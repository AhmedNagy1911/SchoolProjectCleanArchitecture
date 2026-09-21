using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Abstractions.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Department> Departments { get; }
    DbSet<Subjects> Subjects { get; }
    DbSet<StudentSubject> StudentSubjects { get; }
    DbSet<DepartmetSubject> DepartmetSubjects { get; }

    DbSet<AcademicYear> AcademicYears { get; }
    DbSet<ClassRoom> ClassRooms { get; }
    DbSet<ClassEnrollment> ClassEnrollments { get; }
    DbSet<Teacher> Teachers { get; }
    DbSet<TeacherSubject> TeacherSubjects { get; }
    DbSet<Parent> Parents { get; }
    DbSet<ParentStudent> ParentStudents { get; }
    DbSet<Attendance> Attendances { get; }
    DbSet<Exam> Exams { get; }
    DbSet<StudentGrade> StudentGrades { get; }
    DbSet<TimetableSlot> TimetableSlots { get; }
    DbSet<FeeType> FeeTypes { get; }
    DbSet<Invoice> Invoices { get; }
    DbSet<Payment> Payments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

