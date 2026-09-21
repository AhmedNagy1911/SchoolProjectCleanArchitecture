using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class SubjectsConfiguration : IEntityTypeConfiguration<Subjects>
{
    public void Configure(EntityTypeBuilder<Subjects> builder)
    {
        builder.HasKey(x => x.SubID);

        builder.Property(x => x.SubjectName).IsRequired().HasMaxLength(500);
    }
}
