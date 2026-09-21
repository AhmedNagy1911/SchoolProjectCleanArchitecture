namespace SchoolProject.Data.Entities;

public class ClassRoom
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;          // e.g. 1A
    public int DID { get; set; }
    public int AcademicYearId { get; set; }
    public int Capacity { get; set; }

    public virtual Department Department { get; set; } = default!;
    public virtual AcademicYear AcademicYear { get; set; } = default!;

    public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; } = [];
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = [];
    public virtual ICollection<Attendance> Attendances { get; set; } = [];
    public virtual ICollection<Exam> Exams { get; set; } = [];
    public virtual ICollection<TimetableSlot> TimetableSlots { get; set; } = [];
}