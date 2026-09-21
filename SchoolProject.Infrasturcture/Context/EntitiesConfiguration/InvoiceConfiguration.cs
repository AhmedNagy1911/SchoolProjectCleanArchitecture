using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);

        // bulk generation can't create the same fee twice for a student
        builder.HasIndex(x => new { x.StudID, x.FeeTypeId }).IsUnique();
        builder.HasIndex(x => new { x.StudID, x.AcademicYearId });

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.StudID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FeeType)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.FeeTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AcademicYear)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_Invoices_Amount", "[Amount] > 0"));
    }
}
