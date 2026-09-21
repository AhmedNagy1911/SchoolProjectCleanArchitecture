using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class StudentGradeConfiguration : IEntityTypeConfiguration<StudentGrade>
{
    public void Configure(EntityTypeBuilder<StudentGrade> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Degree).HasPrecision(5, 2);
        builder.Property(x => x.Notes).HasMaxLength(500);

        // one grade per student per exam
        builder.HasIndex(x => new { x.ExamId, x.StudID }).IsUnique();

        builder.HasOne(x => x.Exam)
            .WithMany(x => x.StudentGrades)
            .HasForeignKey(x => x.ExamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.StudentGrades)
            .HasForeignKey(x => x.StudID)
            .OnDelete(DeleteBehavior.Restrict);

        // Degree <= Exam.MaxDegree can't be a CHECK (cross-table): it is validated in the handler
        builder.ToTable(t => t.HasCheckConstraint("CK_StudentGrades_Degree", "[Degree] >= 0"));
    }
}
