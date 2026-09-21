using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(x => x.Id);

        // PK is also the FK to AspNetUsers
        builder.Property(x => x.Id).HasMaxLength(450).ValueGeneratedNever();

        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Parent>(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
