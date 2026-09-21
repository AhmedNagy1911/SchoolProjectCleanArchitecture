namespace SchoolProject.Data.Entities;

public class FeeType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public int AcademicYearId { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = default!;
    public virtual ICollection<Invoice> Invoices { get; set; } = [];
}