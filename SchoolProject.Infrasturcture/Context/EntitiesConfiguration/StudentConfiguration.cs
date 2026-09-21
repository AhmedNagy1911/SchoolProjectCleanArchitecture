using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudID);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(500);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.DID)
            .OnDelete(DeleteBehavior.Restrict);

        // optional login for the student; EF creates a unique index filtered on NOT NULL for this 1-to-0..1
        builder.HasOne(x => x.ApplicationUser)
            .WithOne()
            .HasForeignKey<Student>(x => x.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
