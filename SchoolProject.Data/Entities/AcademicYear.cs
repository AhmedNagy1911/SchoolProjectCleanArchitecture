namespace SchoolProject.Data.Entities;

public class AcademicYear
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;          // e.g. 2026/2027
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<ClassRoom> ClassRooms { get; set; } = [];
    public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; } = [];
    public virtual ICollection<FeeType> FeeTypes { get; set; } = [];
    public virtual ICollection<Invoice> Invoices { get; set; } = [];
}
