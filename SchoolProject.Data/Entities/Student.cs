namespace SchoolProject.Data.Entities;

public class Student
{
    public int StudID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int? DID { get; set; }

    /// <summary>Optional: only set if the student has his own login.</summary>
    public string? ApplicationUserId { get; set; }

    public virtual Department? Department { get; set; }
    public virtual ApplicationUser? ApplicationUser { get; set; }

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = [];
    public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; } = [];
    public virtual ICollection<ParentStudent> ParentStudents { get; set; } = [];
    public virtual ICollection<Attendance> Attendances { get; set; } = [];
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = [];
    public virtual ICollection<Invoice> Invoices { get; set; } = [];
}
