namespace SchoolProject.Data.Entities;

public class Subjects
{
    public int SubID { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public DateTime Period { get; set; }

    public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = [];
    public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; } = [];
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = [];
    public virtual ICollection<Exam> Exams { get; set; } = [];
    public virtual ICollection<TimetableSlot> TimetableSlots { get; set; } = [];
}
