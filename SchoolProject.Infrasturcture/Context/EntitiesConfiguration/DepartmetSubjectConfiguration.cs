using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class DepartmetSubjectConfiguration : IEntityTypeConfiguration<DepartmetSubject>
{
    public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
    {
        builder.HasKey(x => x.DeptSubID);

        builder.HasIndex(x => new { x.DID, x.SubID }).IsUnique();

        builder.HasOne(x => x.Department)
            .WithMany(x => x.DepartmentSubjects)
            .HasForeignKey(x => x.DID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Subjects)
            .WithMany(x => x.DepartmetsSubjects)
            .HasForeignKey(x => x.SubID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
