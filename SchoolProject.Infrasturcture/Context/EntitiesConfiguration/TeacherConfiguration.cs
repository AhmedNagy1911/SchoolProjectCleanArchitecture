using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(x => x.Id);

        // PK is also the FK to AspNetUsers
        builder.Property(x => x.Id).HasMaxLength(450).ValueGeneratedNever();

        builder.Property(x => x.Specialization).IsRequired().HasMaxLength(200);

        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Teacher>(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
