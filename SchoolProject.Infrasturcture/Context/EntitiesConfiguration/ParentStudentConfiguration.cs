using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class ParentStudentConfiguration : IEntityTypeConfiguration<ParentStudent>
{
    public void Configure(EntityTypeBuilder<ParentStudent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ParentId).HasMaxLength(450);
        builder.Property(x => x.Relationship).IsRequired().HasMaxLength(50);

        builder.HasIndex(x => new { x.ParentId, x.StudID }).IsUnique();

        builder.HasOne(x => x.Parent)
            .WithMany(x => x.ParentStudents)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.ParentStudents)
            .HasForeignKey(x => x.StudID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}