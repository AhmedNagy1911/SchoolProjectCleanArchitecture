using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities;

public partial class Department
{

    [Key]
    public int DID { get; set; }
    [StringLength(500)]
    public string DName { get; set; } = string.Empty;
    public virtual ICollection<Student> Students { get; set; } = [];
    public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = [];
}