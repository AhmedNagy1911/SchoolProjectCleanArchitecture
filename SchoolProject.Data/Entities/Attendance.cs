using SchoolProject.Data.Enums;

namespace SchoolProject.Data.Entities;

public class Attendance
{
    public int Id { get; set; }
    public int StudID { get; set; }
    public int ClassRoomId { get; set; }
    public DateOnly Date { get; set; }
    public AttendanceStatus Status { get; set; }

    /// <summary>Null when the record was created by an Admin.</summary>
    public string? RecordedByTeacherId { get; set; }

    public virtual Student Student { get; set; } = default!;
    public virtual ClassRoom ClassRoom { get; set; } = default!;
    public virtual Teacher? RecordedByTeacher { get; set; }
}
