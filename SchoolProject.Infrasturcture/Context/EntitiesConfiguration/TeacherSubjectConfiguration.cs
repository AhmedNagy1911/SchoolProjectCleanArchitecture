using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
{
    public void Configure(EntityTypeBuilder<TeacherSubject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TeacherId).HasMaxLength(450);

        builder.HasIndex(x => new { x.TeacherId, x.SubID, x.ClassRoomId }).IsUnique();

        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.TeacherSubjects)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Subject)
            .WithMany(x => x.TeacherSubjects)
            .HasForeignKey(x => x.SubID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClassRoom)
            .WithMany(x => x.TeacherSubjects)
            .HasForeignKey(x => x.ClassRoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
