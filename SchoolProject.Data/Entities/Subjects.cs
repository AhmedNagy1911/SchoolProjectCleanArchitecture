using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public class Subjects
{

    [Key]
    public int SubID { get; set; }
    [StringLength(500)]
    public string SubjectName { get; set; } = string.Empty;
    public DateTime Period { get; set; }
    public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = [];
    public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; } = [];
}