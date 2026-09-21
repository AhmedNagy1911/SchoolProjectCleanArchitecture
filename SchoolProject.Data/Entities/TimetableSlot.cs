namespace SchoolProject.Data.Entities;

public class TimetableSlot
{
    public int Id { get; set; }
    public int ClassRoomId { get; set; }
    public int SubID { get; set; }
    public string TeacherId { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public virtual ClassRoom ClassRoom { get; set; } = default!;
    public virtual Subjects Subject { get; set; } = default!;
    public virtual Teacher Teacher { get; set; } = default!;
}