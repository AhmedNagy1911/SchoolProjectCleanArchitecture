using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class TimetableSlotConfiguration : IEntityTypeConfiguration<TimetableSlot>
{
    public void Configure(EntityTypeBuilder<TimetableSlot> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TeacherId).HasMaxLength(450);
        builder.Property(x => x.DayOfWeek).HasConversion<string>().HasMaxLength(10);

        // exact duplicates only; overlapping ranges are checked in the handler
        builder.HasIndex(x => new { x.ClassRoomId, x.DayOfWeek, x.StartTime }).IsUnique();
        builder.HasIndex(x => new { x.TeacherId, x.DayOfWeek, x.StartTime }).IsUnique();

        builder.HasOne(x => x.ClassRoom)
            .WithMany(x => x.TimetableSlots)
            .HasForeignKey(x => x.ClassRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Subject)
            .WithMany(x => x.TimetableSlots)
            .HasForeignKey(x => x.SubID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.TimetableSlots)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(t => t.HasCheckConstraint("CK_TimetableSlots_Time", "[EndTime] > [StartTime]"));
    }
}
