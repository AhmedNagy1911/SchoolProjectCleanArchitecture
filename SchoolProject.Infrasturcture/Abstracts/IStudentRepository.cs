using SchoolProject.Data.Entities;

namespace SchoolProject.Infrasturcture.Abstracts;

public interface IStudentRepository
{
    Task<List<Student>> GetAllStudentsAsync();
}
