using SchoolProject.Core.Feature.Students.Qureies.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void GetStudentListMapping()
    {
        CreateMap<Student, GetStudentListRespones>()
           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
    }
}
