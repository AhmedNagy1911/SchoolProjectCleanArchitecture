namespace SchoolProject.Data.Entities;

public class TeacherSubject
{
    public int Id { get; set; }
    public string TeacherId { get; set; } = string.Empty;
    public int SubID { get; set; }
    public int ClassRoomId { get; set; }

    public virtual Teacher Teacher { get; set; } = default!;
    public virtual Subjects Subject { get; set; } = default!;
    public virtual ClassRoom ClassRoom { get; set; } = default!;
}
