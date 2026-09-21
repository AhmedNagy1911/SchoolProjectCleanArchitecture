namespace SchoolProject.Data.Entities;

public class StudentGrade
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int StudID { get; set; }
    public decimal Degree { get; set; }
    public string? Notes { get; set; }

    public virtual Exam Exam { get; set; } = default!;
    public virtual Student Student { get; set; } = default!;
}