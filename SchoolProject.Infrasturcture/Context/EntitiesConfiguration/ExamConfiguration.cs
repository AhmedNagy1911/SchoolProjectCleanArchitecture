using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.MaxDegree).HasPrecision(5, 2);
        builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);

        builder.HasIndex(x => new { x.ClassRoomId, x.SubID });

        builder.HasOne(x => x.Subject)
            .WithMany(x => x.Exams)
            .HasForeignKey(x => x.SubID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClassRoom)
            .WithMany(x => x.Exams)
            .HasForeignKey(x => x.ClassRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_Exams_MaxDegree", "[MaxDegree] > 0"));
    }
}
