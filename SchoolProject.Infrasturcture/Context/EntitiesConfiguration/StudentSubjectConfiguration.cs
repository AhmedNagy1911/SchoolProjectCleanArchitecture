using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
{
    public void Configure(EntityTypeBuilder<StudentSubject> builder)
    {
        builder.HasKey(x => x.StudSubID);

        builder.HasIndex(x => new { x.StudID, x.SubID }).IsUnique();

        builder.HasOne(x => x.Student)
            .WithMany(x => x.StudentSubjects)
            .HasForeignKey(x => x.StudID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Subject)
            .WithMany(x => x.StudentsSubjects)
            .HasForeignKey(x => x.SubID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
