using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementation;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllStudentsAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetTableNoTracking()
                                              .Include(x => x.Department)
                                              .Where(x => x.StudID == id)
                                              .FirstOrDefaultAsync();
        return student;
    }
}
