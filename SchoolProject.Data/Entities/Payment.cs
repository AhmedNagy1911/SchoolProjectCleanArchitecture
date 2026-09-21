using SchoolProject.Data.Enums;

namespace SchoolProject.Data.Entities;

public class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidOn { get; set; } = DateTime.UtcNow;
    public PaymentMethod Method { get; set; }

    public virtual Invoice Invoice { get; set; } = default!;
}
