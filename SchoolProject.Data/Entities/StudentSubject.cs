namespace SchoolProject.Data.Entities;


public class StudentSubject
{
    public int StudSubID { get; set; }
    public int StudID { get; set; }
    public int SubID { get; set; }

    public virtual Student Student { get; set; } = default!;
    public virtual Subjects Subject { get; set; } = default!;
}
