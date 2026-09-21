using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
        builder.Property(x => x.RecordedByTeacherId).HasMaxLength(450);

        // one record per student per class per day
        builder.HasIndex(x => new { x.StudID, x.ClassRoomId, x.Date }).IsUnique();
        builder.HasIndex(x => new { x.ClassRoomId, x.Date });

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Attendances)
            .HasForeignKey(x => x.StudID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClassRoom)
            .WithMany(x => x.Attendances)
            .HasForeignKey(x => x.ClassRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RecordedByTeacher)
            .WithMany(x => x.Attendances)
            .HasForeignKey(x => x.RecordedByTeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
