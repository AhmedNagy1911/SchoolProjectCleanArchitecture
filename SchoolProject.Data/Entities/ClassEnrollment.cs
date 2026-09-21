namespace SchoolProject.Data.Entities;

//تسجيل طالب في فصل في سنة دراسية. بيتغير كل سنة، وده اللي بيخلّي الطالب يتنقل من فصل لفصل.
public class ClassEnrollment
{
    public int Id { get; set; }
    public int StudID { get; set; }
    public int ClassRoomId { get; set; }
    public int AcademicYearId { get; set; }

    public virtual Student Student { get; set; } = default!;
    public virtual ClassRoom ClassRoom { get; set; } = default!;
    public virtual AcademicYear AcademicYear { get; set; } = default!;
}
