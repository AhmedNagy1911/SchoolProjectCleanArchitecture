using SchoolProject.Data.Enums;

namespace SchoolProject.Data.Entities;

public class Invoice
{
    public int Id { get; set; }
    public int StudID { get; set; }
    public int FeeTypeId { get; set; }
    public int AcademicYearId { get; set; }
    public decimal Amount { get; set; }
    public DateOnly DueDate { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;

    public virtual Student Student { get; set; } = default!;
    public virtual FeeType FeeType { get; set; } = default!;
    public virtual AcademicYear AcademicYear { get; set; } = default!;
    public virtual ICollection<Payment> Payments { get; set; } = [];
}