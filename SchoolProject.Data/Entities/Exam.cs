using SchoolProject.Data.Enums;

namespace SchoolProject.Data.Entities;

public class Exam
{
    public int Id { get; set; }
    public int SubID { get; set; }
    public int ClassRoomId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public decimal MaxDegree { get; set; }
    public ExamType Type { get; set; }

    public virtual Subjects Subject { get; set; } = default!;
    public virtual ClassRoom ClassRoom { get; set; } = default!;
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = [];
}
