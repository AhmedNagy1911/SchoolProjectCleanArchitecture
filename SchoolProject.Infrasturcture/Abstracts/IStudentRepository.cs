using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Bases;

namespace SchoolProject.Infrasturcture.Abstracts;

public interface IStudentRepository : IGenericRepositoryAsync<Student>
{
    Task<List<Student>> GetAllStudentsAsync();
}
