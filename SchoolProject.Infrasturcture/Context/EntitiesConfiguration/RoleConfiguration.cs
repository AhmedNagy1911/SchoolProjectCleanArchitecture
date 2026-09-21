using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Core.Abstractions.Consts;

namespace SchoolProject.Infrasturcture.Context.EntitiesConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = DefaultRoles.AdminRoleId,
                Name = DefaultRoles.Admin,
                NormalizedName = DefaultRoles.Admin.ToUpperInvariant(),
                ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp
            },
            new IdentityRole
            {
                Id = DefaultRoles.TeacherRoleId,
                Name = DefaultRoles.Teacher,
                NormalizedName = DefaultRoles.Teacher.ToUpperInvariant(),
                ConcurrencyStamp = DefaultRoles.TeacherRoleConcurrencyStamp
            },
            new IdentityRole
            {
                Id = DefaultRoles.ParentRoleId,
                Name = DefaultRoles.Parent,
                NormalizedName = DefaultRoles.Parent.ToUpperInvariant(),
                ConcurrencyStamp = DefaultRoles.ParentRoleConcurrencyStamp
            },
            new IdentityRole
            {
                Id = DefaultRoles.StudentRoleId,
                Name = DefaultRoles.Student,
                NormalizedName = DefaultRoles.Student.ToUpperInvariant(),
                ConcurrencyStamp = DefaultRoles.StudentRoleConcurrencyStamp
            });
    }
}
