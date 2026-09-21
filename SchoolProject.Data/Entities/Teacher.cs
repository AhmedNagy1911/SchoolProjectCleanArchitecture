namespace SchoolProject.Data.Entities;

public class Teacher
{
    public string Id { get; set; } = string.Empty;
    public DateOnly HireDate { get; set; }
    public string Specialization { get; set; } = string.Empty;

    public virtual ApplicationUser User { get; set; } = default!;

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = [];
    public virtual ICollection<Attendance> Attendances { get; set; } = [];
    public virtual ICollection<TimetableSlot> TimetableSlots { get; set; } = [];
}
