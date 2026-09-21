namespace SchoolProject.Data.Entities;

public partial class Department
{
    public int DID { get; set; }
    public string DName { get; set; } = string.Empty;

    public virtual ICollection<Student> Students { get; set; } = [];
    public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; } = [];
    public virtual ICollection<ClassRoom> ClassRooms { get; set; } = [];
}
