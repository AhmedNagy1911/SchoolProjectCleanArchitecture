namespace SchoolProject.Data.Entities;

public class DepartmetSubject
{
    public int DeptSubID { get; set; }
    public int DID { get; set; }
    public int SubID { get; set; }

    public virtual Department Department { get; set; } = default!;
    public virtual Subjects Subjects { get; set; } = default!;
}
