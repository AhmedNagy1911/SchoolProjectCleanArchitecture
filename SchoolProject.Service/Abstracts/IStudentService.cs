using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts;

public interface IStudentService
{
    Task<List<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<string> AddAsync(Student student);
    Task<bool> IsNameExist(string name);
}
