using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class AcademicYearConfiguration : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

        builder.HasIndex(x => x.Name).IsUnique();

        // only one active academic year at any time (enforced by the database)
        builder.HasIndex(x => x.IsActive)
            .IsUnique()
            .HasFilter("[IsActive] = 1");

        builder.ToTable(t => t.HasCheckConstraint("CK_AcademicYears_Dates", "[EndDate] > [StartDate]"));
    }
}
