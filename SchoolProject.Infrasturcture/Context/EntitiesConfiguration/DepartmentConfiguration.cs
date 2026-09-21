using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.DID);

        builder.Property(x => x.DName).IsRequired().HasMaxLength(500);

        builder.HasIndex(x => x.DName).IsUnique();
    }
}
