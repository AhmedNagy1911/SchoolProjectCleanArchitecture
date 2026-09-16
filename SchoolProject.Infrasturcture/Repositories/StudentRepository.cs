using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Bases;
using SchoolProject.Infrasturcture.Context;

namespace SchoolProject.Infrasturcture.Repositories;

public class StudentRepository(ApplicationDbContext context) 
    : GenericRepositoryAsync<Student>(context), IStudentRepository

{
    private readonly DbSet<Student> _students = context.Set<Student>();

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _students.Include(x => x.Department).ToListAsync();
    }
}
